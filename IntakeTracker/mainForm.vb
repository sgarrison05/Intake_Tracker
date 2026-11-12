Imports System.IO
Imports System.Text
Imports System.Linq
Imports System.Windows.Forms
Imports System.Drawing


Public Class mainForm

    Private Const StatusWindowDays As Integer = 60
    Private Const FieldCount As Integer = 11
    Private Const DateFmt As String = "yyyy-MM-dd"
    Private Const IdPrefix As String = "JV-"

    Private Const DATA_FOLDER As String = "C:\Intake"
    Private Const DATA_FILE As String = DATA_FOLDER & "\IntakeCases.txt"

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

#Region "Form events"

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecords()
        RefreshList()
        ClearForm()
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

    Private Sub lvRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRecords.SelectedIndexChanged
        If loadingSelection OrElse lvRecords.SelectedItems.Count = 0 Then Return
        Dim childId As String = lvRecords.SelectedItems(0).Text
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

        ' Pre-PACT countdown
        Dim prePactDays As Integer = (dtpPrePact.Value.Date - today).Days
        lblPrePactDays.Text = CountdownText(prePactDays)
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

        If txtChildId.Text.Trim().Length = 0 Then txtChildId.Text = GenerateChildId()

        Calculate()

        Dim rec As New CaseRecord With {
            .ChildId = txtChildId.Text,
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

        If Not WriteRecords() Then Return
        RefreshList()
        SelectInList(rec.ChildId)
        MessageBox.Show("Record saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeleteCurrent()
        Dim childId As String = txtChildId.Text
        If lvRecords.SelectedItems.Count > 0 Then childId = lvRecords.SelectedItems(0).Text

        Dim idx As Integer = records.FindIndex(Function(r) r.ChildId = childId)
        If idx < 0 Then
            MessageBox.Show("Select a saved record to delete.", "Nothing to Delete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim answer = MessageBox.Show("Delete the record for " & records(idx).ChildName &
                                     " (" & childId & ")?", "Confirm Delete",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer <> DialogResult.Yes Then Return

        records.RemoveAt(idx)
        If Not WriteRecords() Then Return
        RefreshList()
        ClearForm()
    End Sub

    Private Sub ClearForm()
        loadingSelection = True
        lvRecords.SelectedItems.Clear()
        loadingSelection = False

        txtChildId.Text = GenerateChildId()
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
        txtChildId.Text = rec.ChildId
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
            If item.Text = childId Then
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

                    Dim f() As String = line.Split("|"c)
                    If f.Length < FieldCount Then Continue Do

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
            MessageBox.Show("Could not read the data file: " & ex.Message, "File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function WriteRecords() As Boolean
        Try
            Using sw As New StreamWriter(DATA_FILE, False, Encoding.UTF8)
                For Each r In records
                    sw.WriteLine(String.Join("|", {
                        Escape(r.ChildId),
                        Escape(r.CaseNo),
                        Escape(r.ChildName),
                        Escape(r.Offense),
                        Escape(r.Status),
                        r.PrePact.ToString(DateFmt),
                        r.Dob.ToString(DateFmt),
                        r.InitialSubmit.ToString(DateFmt),
                        r.LastStatus.ToString(DateFmt),
                        If(r.IntakeCompleted, "1", "0"),
                        Escape(r.Notes)
                    }))
                Next
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Could not write the data file: " & ex.Message, "File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function TryParseDate(text As String, ByRef result As Date) As Boolean
        Return Date.TryParseExact(text, DateFmt, Globalization.CultureInfo.InvariantCulture,
                                  Globalization.DateTimeStyles.None, result)
    End Function

    Private Function Escape(s As String) As String
        If s Is Nothing Then Return ""
        Return s.Replace("\", "\\").Replace("|", "\p") _
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
                    Case "p"c : sb.Append("|"c)
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
