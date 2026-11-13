Imports System.IO
Imports System.Text
Imports System.Linq
Imports System.Windows.Forms
Imports System.Drawing


Public Class mainForm

    Private Const StatusWindowDays As Integer = 60
    Private Const PrePactWindowDays As Integer = 180
    Private Const FieldCount As Integer = 11
    Private Const DateFmt As String = "yyyy-MM-dd"
    Private Const IdPrefix As String = "JV-"

    Private Const DATA_FOLDER As String = "D:\Temp\Intake"
    Private Const DATA_FILE As String = DATA_FOLDER & "\IntakeCases.txt"

    ' Data file layout: tab-separated, header row first, dotted line after the header
    ' and between records. Columns are padded so every record lines up under the header.
    Private Const HeaderFirstField As String = "Child ID"
    Private Const PadColumns As Integer = FieldCount - 1   ' every column except Progress Notes
    Private Const TabSize As Integer = 8
    Private Const SeparatorChar As Char = "-"c
    Private Const SeparatorExtra As Integer = 30           ' dotted line runs this far under the notes column

    Private ReadOnly FileHeaders() As String = {
        "Child ID", "Case No.", "Child Name", "Offense", "Case Status",
        "Pre-PACT Date", "Date of Birth", "Initial Submit Date", "Last Case Status",
        "Intake Completed", "Progress Notes"
    }

    Private ReadOnly rng As New Random()

    Private Class CaseRecord
        Public ChildId As String
        Public CaseNo As String
        Public ChildName As String
        Public Offense As String
        Public Status As String
        Public PrePact As Date
        Public Dob As Date
        Public InitialSubmit As Date
        Public LastStatus As Date
        Public IntakeCompleted As Boolean
        Public Notes As String
    End Class

    Private records As New List(Of CaseRecord)
    Private loadingSelection As Boolean = False

    ' Child ID of the record currently on the form. Empty = new, unsaved child.
    ' Never displayed; it is generated at first Save and stored in the data file only.
    Private currentChildId As String = ""

#Region "Form events"

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecords()
        RefreshList()
        ClearForm()
        Calculate()
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Calculate()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveCurrent()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteCurrent()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub lvRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRecords.SelectedIndexChanged
        If loadingSelection OrElse lvRecords.SelectedItems.Count = 0 Then Return
        Dim childId As String = CStr(lvRecords.SelectedItems(0).Tag)
        Dim rec = records.FirstOrDefault(Function(r) r.ChildId = childId)
        If rec IsNot Nothing Then PopulateForm(rec)
    End Sub

#End Region

#Region "Child ID"

    ' Random six-digit number (100000-999999) prefixed with "JV-".
    ' Re-rolls until the ID is not already in use.
    Private Function GenerateChildId() As String
        Dim id As String
        Do
            id = IdPrefix & rng.Next(100000, 1000000).ToString()
        Loop While records.Any(Function(r) r.ChildId = id)
        Return id
    End Function

#End Region

#Region "Calculations"

    Private Sub Calculate()
        Dim today As Date = Date.Today

        ' Pre-PACT countdown: starts at 180 days on the Pre-PACT date and counts down
        Dim prePactDeadline As Date = dtpPrePact.Value.Date.AddDays(PrePactWindowDays)
        Dim prePactDays As Integer = Math.Min((prePactDeadline - today).Days, PrePactWindowDays)
        lblPrePactDays.Text = PrePactCountdownText(prePactDays)
        lblPrePactDays.ForeColor = If(prePactDays < 0, Color.Firebrick, SystemColors.ControlText)

        ' Current age in years
        Dim dob As Date = dtpDob.Value.Date
        Dim age As Integer = today.Year - dob.Year
        If dob > today.AddYears(-age) Then age -= 1
        lblAge.Text = If(age < 0, "-", age.ToString() & If(age = 1, " year", " years"))

        ' Days pending since intake submission
        Dim pending As Integer = (today - dtpInitialSubmit.Value.Date).Days
        lblPending.Text = If(pending < 0, "0 days", pending.ToString() & If(pending = 1, " day", " days"))

        ' Threshold date and staffing countdown (threshold minus today)
        Dim threshold As Date = dtpLastStatus.Value.Date.AddDays(StatusWindowDays)
        lblThreshold.Text = threshold.ToString("MM/dd/yyyy")

        Dim staffingDays As Integer = (threshold - today).Days
        lblStaffing.Text = CountdownText(staffingDays)
        lblStaffing.ForeColor = If(staffingDays < 0, Color.Firebrick, SystemColors.ControlText)
    End Sub

    ' Pre-PACT countdown text: never shows "Today"; zero is "0 days".
    Private Function PrePactCountdownText(days As Integer) As String
        If days >= 0 Then Return days.ToString() & If(days = 1, " day", " days")
        Dim past As Integer = Math.Abs(days)
        Return past.ToString() & If(past = 1, " day past", " days past")
    End Function

    Private Function CountdownText(days As Integer) As String
        If days = 0 Then Return "Today"
        If days > 0 Then Return days.ToString() & If(days = 1, " day", " days")
        Dim past As Integer = Math.Abs(days)
        Return past.ToString() & If(past = 1, " day past", " days past")
    End Function

#End Region

#Region "Save / Delete / Clear"

    Private Sub SaveCurrent()
        If txtCaseNo.Text.Trim().Length = 0 Then
            MessageBox.Show("Please enter the case number.", "Missing Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCaseNo.Focus()
            Return
        End If

        If txtChildName.Text.Trim().Length = 0 Then
            MessageBox.Show("Please enter the child's name.", "Missing Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtChildName.Focus()
            Return
        End If

        Calculate()

        ' Keep a copy so a failed write leaves the in-memory list unchanged
        Dim backup As New List(Of CaseRecord)(records)
        Dim isNew As Boolean = String.IsNullOrEmpty(currentChildId)
        If isNew Then currentChildId = GenerateChildId()

        Dim rec As New CaseRecord With {
            .ChildId = currentChildId,
            .CaseNo = txtCaseNo.Text.Trim(),
            .ChildName = txtChildName.Text.Trim(),
            .Offense = txtOffense.Text.Trim(),
            .Status = txtStatus.Text.Trim(),
            .PrePact = dtpPrePact.Value.Date,
            .Dob = dtpDob.Value.Date,
            .InitialSubmit = dtpInitialSubmit.Value.Date,
            .LastStatus = dtpLastStatus.Value.Date,
            .IntakeCompleted = chkIntake.Checked,
            .Notes = txtNotes.Text
        }

        Dim idx As Integer = records.FindIndex(Function(r) r.ChildId = rec.ChildId)
        If idx >= 0 Then
            records(idx) = rec
        Else
            records.Add(rec)
        End If

        If Not WriteRecords() Then
            records = backup
            If isNew Then currentChildId = ""
            Return
        End If

        RefreshList()
        SelectInList(rec.ChildId)
        MessageBox.Show("Record saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeleteCurrent()
        Dim childId As String = currentChildId
        If lvRecords.SelectedItems.Count > 0 Then childId = CStr(lvRecords.SelectedItems(0).Tag)

        Dim idx As Integer = -1
        If Not String.IsNullOrEmpty(childId) Then
            idx = records.FindIndex(Function(r) r.ChildId = childId)
        End If

        If idx < 0 Then
            MessageBox.Show("Select a saved record to delete.", "Nothing to Delete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim answer = MessageBox.Show("Delete the record for " & records(idx).ChildName &
                                     " (Case No. " & records(idx).CaseNo & ")?", "Confirm Delete",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer <> DialogResult.Yes Then Return

        Dim backup As New List(Of CaseRecord)(records)
        records.RemoveAt(idx)
        If Not WriteRecords() Then
            records = backup
            Return
        End If
        RefreshList()
        ClearForm()
    End Sub

    Private Sub ClearForm()
        loadingSelection = True
        lvRecords.SelectedItems.Clear()
        loadingSelection = False

        currentChildId = ""
        txtChildName.Clear()
        txtOffense.Clear()
        txtCaseNo.Clear()
        txtStatus.Clear()
        txtNotes.Clear()
        chkIntake.Checked = False
        dtpPrePact.Value = Date.Today
        dtpDob.Value = Date.Today
        dtpInitialSubmit.Value = Date.Today
        dtpLastStatus.Value = Date.Today

        For Each lbl In {lblPrePactDays, lblAge, lblPending, lblThreshold, lblStaffing}
            lbl.Text = "-"
            lbl.ForeColor = SystemColors.ControlText
        Next
        txtChildName.Focus()
    End Sub

    Private Sub PopulateForm(rec As CaseRecord)
        currentChildId = rec.ChildId
        txtCaseNo.Text = rec.CaseNo
        txtChildName.Text = rec.ChildName
        txtOffense.Text = rec.Offense
        txtStatus.Text = rec.Status
        dtpPrePact.Value = rec.PrePact
        dtpDob.Value = rec.Dob
        dtpInitialSubmit.Value = rec.InitialSubmit
        dtpLastStatus.Value = rec.LastStatus
        chkIntake.Checked = rec.IntakeCompleted
        txtNotes.Text = rec.Notes
        Calculate()
    End Sub

#End Region

#Region "Records list"

    Private Sub RefreshList()
        loadingSelection = True
        lvRecords.BeginUpdate()
        lvRecords.Items.Clear()
        For Each r In records.OrderBy(Function(x) x.ChildName)
            Dim item As New ListViewItem(r.ChildId)
            item.Tag = r.ChildId
            item.SubItems.Add(r.CaseNo)
            item.SubItems.Add(r.ChildName)
            item.SubItems.Add(r.Offense)
            item.SubItems.Add(r.Status)
            item.SubItems.Add(r.PrePact.ToString("MM/dd/yyyy"))
            item.SubItems.Add(r.LastStatus.AddDays(StatusWindowDays).ToString("MM/dd/yyyy"))
            item.SubItems.Add(If(r.IntakeCompleted, "Yes", "No"))
            lvRecords.Items.Add(item)
        Next
        lvRecords.EndUpdate()
        loadingSelection = False
    End Sub

    Private Sub SelectInList(childId As String)
        loadingSelection = True
        For Each item As ListViewItem In lvRecords.Items
            If CStr(item.Tag) = childId Then
                item.Selected = True
                item.EnsureVisible()
                Exit For
            End If
        Next
        loadingSelection = False
    End Sub

#End Region

#Region "Sequential file persistence"

    Private Sub LoadRecords()
        records.Clear()
        If Not File.Exists(DATA_FILE) Then Return

        Try
            Using sr As New StreamReader(DATA_FILE, Encoding.UTF8)
                Do While Not sr.EndOfStream
                    Dim line As String = sr.ReadLine()
                    If String.IsNullOrWhiteSpace(line) Then Continue Do

                    ' Dotted separator lines are ignored
                    If IsSeparatorLine(line) Then Continue Do

                    Dim f() As String = SplitLine(line)
                    If f Is Nothing Then Continue Do

                    ' Remove the alignment padding (every column except Progress Notes)
                    For i As Integer = 0 To PadColumns - 1
                        f(i) = f(i).TrimEnd(" "c)
                    Next

                    ' Header row is ignored
                    If f(0).Trim().Equals(HeaderFirstField, StringComparison.OrdinalIgnoreCase) Then Continue Do

                    Dim rec As New CaseRecord
                    rec.ChildId = Unescape(f(0))
                    rec.CaseNo = Unescape(f(1))
                    rec.ChildName = Unescape(f(2))
                    rec.Offense = Unescape(f(3))
                    rec.Status = Unescape(f(4))
                    If Not TryParseDate(f(5), rec.PrePact) Then Continue Do
                    If Not TryParseDate(f(6), rec.Dob) Then Continue Do
                    If Not TryParseDate(f(7), rec.InitialSubmit) Then Continue Do
                    If Not TryParseDate(f(8), rec.LastStatus) Then Continue Do
                    rec.IntakeCompleted = (f(9) = "1")
                    rec.Notes = Unescape(f(10))
                    records.Add(rec)
                Loop
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not read the data file:" & vbCrLf & DATA_FILE & vbCrLf & vbCrLf & ex.Message,
                            "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsSeparatorLine(line As String) As Boolean
        Dim t As String = line.Trim()
        Return t.Length > 0 AndAlso t.All(Function(ch) ch = SeparatorChar)
    End Function

    ' Splits a data line into fields. Tab-separated is the current format;
    ' lines in the old "|"-separated format are still readable and are
    ' converted to the current layout the next time the file is saved.
    Private Function SplitLine(line As String) As String()
        Dim f() As String = line.Split(ControlChars.Tab)
        If f.Length >= FieldCount Then Return f

        f = line.Split("|"c)
        If f.Length >= FieldCount Then Return f

        Return Nothing
    End Function

    Private Function WriteRecords() As Boolean
        Try
            ' Create the directory and the data file on first save if they don't exist
            If Not Directory.Exists(DATA_FOLDER) Then Directory.CreateDirectory(DATA_FOLDER)
            If Not File.Exists(DATA_FILE) Then File.Create(DATA_FILE).Dispose()

            ' Build every row first so the column widths can be measured
            Dim rows As New List(Of String())
            For Each r In records
                rows.Add(New String() {
                    Escape(r.ChildId),
                    Escape(r.CaseNo),
                    Escape(r.ChildName),
                    Escape(r.Offense),
                    Escape(r.Status),
                    r.PrePact.ToString(DateFmt),
                    r.Dob.ToString(DateFmt),
                    r.InitialSubmit.ToString(DateFmt),
                    r.LastStatus.ToString(DateFmt),
                    If(r.IntakeCompleted, "Yes", "No"),
                    Escape(r.Notes)
                })
            Next

            ' Each column is as wide as its longest entry (header included),
            ' rounded up to a tab stop so the columns line up on every line.
            Dim cellWidth(PadColumns - 1) As Integer
            For i As Integer = 0 To PadColumns - 1
                Dim maxLen As Integer = FileHeaders(i).Length
                For Each row In rows
                    If row(i).Length > maxLen Then maxLen = row(i).Length
                Next
                cellWidth(i) = (maxLen \ TabSize + 1) * TabSize
            Next

            Dim separator As String = New String(SeparatorChar, cellWidth.Sum() + SeparatorExtra)

            Using sw As New StreamWriter(DATA_FILE, False, Encoding.UTF8)
                sw.WriteLine(FormatRow(FileHeaders, cellWidth))
                For Each row In rows
                    sw.WriteLine(separator)
                    sw.WriteLine(FormatRow(row, cellWidth))
                Next
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Could not write the data file:" & vbCrLf & DATA_FILE & vbCrLf & vbCrLf & ex.Message,
                            "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Pads each column to its width, ends it with a tab, and appends Progress Notes unpadded.
    Private Function FormatRow(cells() As String, cellWidth() As Integer) As String
        Dim sb As New StringBuilder()
        For i As Integer = 0 To PadColumns - 1
            sb.Append(cells(i).PadRight(cellWidth(i) - 1))
            sb.Append(ControlChars.Tab)
        Next
        sb.Append(cells(PadColumns))
        Return sb.ToString()
    End Function

    Private Function TryParseDate(text As String, ByRef result As Date) As Boolean
        Return Date.TryParseExact(text, DateFmt, Globalization.CultureInfo.InvariantCulture,
                                  Globalization.DateTimeStyles.None, result)
    End Function

    ' Tabs and line breaks inside a field are escaped so they can't break the file layout.
    Private Function Escape(s As String) As String
        If s Is Nothing Then Return ""
        Return s.Replace("\", "\\").Replace(vbTab, "\t") _
                .Replace(vbCrLf, "\n").Replace(vbCr, "\n").Replace(vbLf, "\n")
    End Function

    Private Function Unescape(s As String) As String
        Dim sb As New StringBuilder()
        Dim i As Integer = 0
        Do While i < s.Length
            Dim c As Char = s(i)
            If c = "\"c AndAlso i + 1 < s.Length Then
                i += 1
                Select Case s(i)
                    Case "n"c : sb.Append(vbCrLf)
                    Case "t"c : sb.Append(vbTab)
                    Case "p"c : sb.Append("|"c)   ' old pipe-format files
                    Case "\"c : sb.Append("\"c)
                    Case Else : sb.Append(s(i))
                End Select
            Else
                sb.Append(c)
            End If
            i += 1
        Loop
        Return sb.ToString()
    End Function



#End Region

End Class