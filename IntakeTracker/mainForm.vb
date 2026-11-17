Imports System.IO
Imports System.Text
Imports System.Linq
Imports System.Windows.Forms
Imports System.Drawing


Public Class mainForm

    Private Const StatusWindowDays As Integer = 60
    Private Const PrePactWindowDays As Integer = 180
    Private Const FieldCount As Integer = 13
    Private Const DateFmt As String = "yyyy-MM-dd"
    Private Const IdPrefix As String = "JV-"

    Private Const DATA_FOLDER As String = "D:\Temp\Intake"
    Private Const DATA_FILE As String = DATA_FOLDER & "\IntakeCases.txt"

    ' Data file layout: tab-separated, header row first, dotted line after the header.
    ' Columns are padded so every record lines up under the header. The child ID is
    ' not written to the file. Age and Days Pending are calculated when the file is
    ' written and are not read back.
    Private Const PadColumns As Integer = FieldCount - 1   ' every column except Notes
    Private Const TabSize As Integer = 8
    Private Const SeparatorChar As Char = "-"c
    Private Const SeparatorExtra As Integer = 20           ' dotted line runs this far under the notes column

    Private ReadOnly FileHeaders() As String = {
        "Child Name", "LE Agency", "Case No.", "Offense", "Case Status",
        "Intake Comp", "Pre-PACT Date", "Date of Birth", "Age", "Initial Sub Date",
        "Days Pending", "Last Case Stat", "Notes"
    }

    Private Const CaseGroupTitle As String = "Case Information"

    Private ReadOnly rng As New Random()

    Private Class CaseRecord
        Public ChildId As String
        Public CaseNo As String
        Public ChildName As String
        Public LEAgency As String
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
    ' Never displayed and not written to the data file; it is generated at first Save
    ' (or when a record is loaded from the file) and only identifies the record in memory.
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

        ' Current age in years (orange at 17 or older, red when over 18)
        Dim dob As Date = dtpDob.Value.Date
        Dim age As Integer = CalcAge(dob, today)
        lblAge.Text = If(age < 0, "-", age.ToString() & If(age = 1, " year", " years"))
        lblAge.ForeColor = AgeColor(age, SystemColors.ControlText)

        ' 18th birthday
        lbl18Birthday.Text = dob.AddYears(18).ToString("MM/dd/yyyy")

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

    ' Whole years between the date of birth and the given date.
    Private Function CalcAge(dob As Date, onDate As Date) As Integer
        Dim age As Integer = onDate.Year - dob.Year
        If dob > onDate.AddYears(-age) Then age -= 1
        Return age
    End Function

    ' Age 17 = orange; 18 or older = red; otherwise the normal color.
    Private Function AgeColor(age As Integer, normal As Color) As Color
        If age >= 18 Then Return Color.Red
        If age >= 17 Then Return Color.DarkOrange
        Return normal
    End Function

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
            .LEAgency = txbLEAgency.Text.Trim(),
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

        ' Saved: show it in the list and get the form ready for the next child,
        ' so the next Save creates a new record instead of updating this one.
        RefreshList()
        ClearForm()
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
        txbLEAgency.Clear()
        txtOffense.Clear()
        txtCaseNo.Clear()
        txtStatus.Clear()
        txtNotes.Clear()
        chkIntake.Checked = False
        dtpPrePact.Value = Date.Today
        dtpDob.Value = Date.Today
        dtpInitialSubmit.Value = Date.Today
        dtpLastStatus.Value = Date.Today

        For Each lbl In {lblPrePactDays, lblAge, lblPending, lblThreshold, lblStaffing, lbl18Birthday}
            lbl.Text = "-"
            lbl.ForeColor = SystemColors.ControlText
        Next

        UpdateModeCue()
        txtChildName.Focus()
    End Sub

    Private Sub PopulateForm(rec As CaseRecord)
        currentChildId = rec.ChildId
        txtCaseNo.Text = rec.CaseNo
        txtChildName.Text = rec.ChildName
        txbLEAgency.Text = rec.LEAgency
        txtOffense.Text = rec.Offense
        txtStatus.Text = rec.Status
        dtpPrePact.Value = rec.PrePact
        dtpDob.Value = rec.Dob
        dtpInitialSubmit.Value = rec.InitialSubmit
        dtpLastStatus.Value = rec.LastStatus
        chkIntake.Checked = rec.IntakeCompleted
        txtNotes.Text = rec.Notes
        UpdateModeCue()
        Calculate()
    End Sub

    ' Title of the Case Information box shows whether Save will add a new record
    ' or update the saved record that is loaded on the form.
    Private Sub UpdateModeCue()
        If String.IsNullOrEmpty(currentChildId) Then
            grpCase.Text = CaseGroupTitle & " - New Record"
        Else
            grpCase.Text = CaseGroupTitle & " - Editing Saved Record (press Clear for a new child)"
        End If
    End Sub

#End Region

#Region "Records list"

    ' Columns must match the designer (subitems are added in column order):
    ' Child Name, LEA, Case No., Offense, Status, Intake, Age, Days Pending, Threshold.
    ' The child ID is kept in the item's Tag only.
    Private Sub RefreshList()
        Dim today As Date = Date.Today

        loadingSelection = True
        lvRecords.BeginUpdate()
        lvRecords.Items.Clear()
        For Each r In records.OrderBy(Function(x) x.ChildName)
            Dim age As Integer = CalcAge(r.Dob, today)
            Dim pending As Integer = Math.Max(0, (today - r.InitialSubmit).Days)

            Dim item As New ListViewItem(r.ChildName)
            item.UseItemStyleForSubItems = False   ' lets the Age cell have its own color
            item.Tag = r.ChildId
            item.SubItems.Add(r.LEAgency)
            item.SubItems.Add(r.CaseNo)
            item.SubItems.Add(r.Offense)
            item.SubItems.Add(r.Status)
            item.SubItems.Add(If(r.IntakeCompleted, "Yes", "No"))
            Dim ageCell As ListViewItem.ListViewSubItem = item.SubItems.Add(If(age < 0, "", age.ToString()))
            ageCell.ForeColor = AgeColor(age, lvRecords.ForeColor)
            item.SubItems.Add(pending.ToString())
            item.SubItems.Add(r.LastStatus.AddDays(StatusWindowDays).ToString("MM/dd/yyyy"))
            lvRecords.Items.Add(item)
        Next
        lvRecords.EndUpdate()
        loadingSelection = False
    End Sub

#End Region

#Region "Sequential file persistence"

    Private Sub LoadRecords()
        records.Clear()
        If Not File.Exists(DATA_FILE) Then Return

        Dim skipped As Integer = 0

        Try
            Using sr As New StreamReader(DATA_FILE, Encoding.UTF8)
                Do While Not sr.EndOfStream
                    Dim line As String = sr.ReadLine()
                    If String.IsNullOrWhiteSpace(line) Then Continue Do

                    ' Dotted separator lines are ignored
                    If IsSeparatorLine(line) Then Continue Do

                    Dim f() As String = SplitLine(line)
                    If f Is Nothing Then
                        skipped += 1
                        Continue Do
                    End If

                    ' Remove the alignment padding (every column except Notes)
                    For i As Integer = 0 To PadColumns - 1
                        f(i) = f(i).TrimEnd(" "c)
                    Next

                    ' Header row is ignored
                    If IsHeaderLine(f) Then Continue Do

                    Dim rec As CaseRecord = ParseRecord(f)
                    If rec Is Nothing Then
                        skipped += 1
                        Continue Do
                    End If

                    ' The child ID is not in the file, so each record is given one when loaded
                    rec.ChildId = GenerateChildId()
                    records.Add(rec)
                Loop
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not read the data file:" & vbCrLf & DATA_FILE & vbCrLf & vbCrLf & ex.Message,
                            "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If skipped > 0 Then
            MessageBox.Show(skipped.ToString() & " line(s) in the data file could not be read and were skipped." &
                            vbCrLf & vbCrLf & "They will be permanently removed from the file the next time you save. " &
                            "Copy the file now if you need to keep them:" & vbCrLf & DATA_FILE,
                            "Data File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Builds a record from a split line (FieldCount fields, padding already removed).
    ' Returns Nothing if the line is not a valid record. Age (f(8)) and Days Pending (f(10))
    ' are calculated values, so they are not read back. The child ID is assigned by the caller.
    Private Function ParseRecord(f() As String) As CaseRecord
        Dim rec As New CaseRecord
        rec.ChildName = Unescape(f(0))
        If rec.ChildName.Length = 0 Then Return Nothing

        rec.LEAgency = Unescape(f(1))
        rec.CaseNo = Unescape(f(2))
        rec.Offense = Unescape(f(3))
        rec.Status = Unescape(f(4))

        Dim intake As String = f(5).Trim()
        rec.IntakeCompleted = intake.Equals("Yes", StringComparison.OrdinalIgnoreCase) OrElse
                              intake.Equals("True", StringComparison.OrdinalIgnoreCase) OrElse
                              intake = "1"

        If Not TryParseDate(f(6), rec.PrePact) Then Return Nothing
        If Not TryParseDate(f(7), rec.Dob) Then Return Nothing
        If Not TryParseDate(f(9), rec.InitialSubmit) Then Return Nothing
        If Not TryParseDate(f(11), rec.LastStatus) Then Return Nothing

        rec.Notes = Unescape(f(12))
        Return rec
    End Function

    Private Function IsSeparatorLine(line As String) As Boolean
        Dim t As String = line.Trim()
        Return t.Length > 0 AndAlso t.All(Function(ch) ch = SeparatorChar)
    End Function

    ' The header row is recognized by its first two column titles.
    Private Function IsHeaderLine(f() As String) As Boolean
        Return f(0).Trim().Equals(FileHeaders(0), StringComparison.OrdinalIgnoreCase) AndAlso
               f(1).Trim().Equals(FileHeaders(1), StringComparison.OrdinalIgnoreCase)
    End Function

    ' Splits a data line on tabs. Returns Nothing if it has fewer than FieldCount fields.
    Private Function SplitLine(line As String) As String()
        Dim f() As String = line.Split(ControlChars.Tab)
        If f.Length < FieldCount Then Return Nothing
        Return f
    End Function

    Private Function WriteRecords() As Boolean
        Try
            ' Create the directory and the data file on first save if they don't exist
            If Not Directory.Exists(DATA_FOLDER) Then Directory.CreateDirectory(DATA_FOLDER)
            If Not File.Exists(DATA_FILE) Then File.Create(DATA_FILE).Dispose()

            ' Build every row first so the column widths can be measured
            Dim today As Date = Date.Today
            Dim rows As New List(Of String())
            For Each r In records
                Dim age As Integer = CalcAge(r.Dob, today)
                Dim pending As Integer = Math.Max(0, (today - r.InitialSubmit).Days)

                rows.Add(New String() {
                    Escape(r.ChildName),
                    Escape(r.LEAgency),
                    Escape(r.CaseNo),
                    Escape(r.Offense),
                    Escape(r.Status),
                    If(r.IntakeCompleted, "Yes", "No"),
                    r.PrePact.ToString(DateFmt),
                    r.Dob.ToString(DateFmt),
                    If(age < 0, "", age.ToString()),
                    r.InitialSubmit.ToString(DateFmt),
                    pending.ToString(),
                    r.LastStatus.ToString(DateFmt),
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
                sw.WriteLine(separator)
                For Each row In rows
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

    ' Pads each column to its width, ends it with a tab, and appends Notes unpadded.
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