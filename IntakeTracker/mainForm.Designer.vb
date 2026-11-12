<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpCase = New System.Windows.Forms.GroupBox()
        Me.lblChild = New System.Windows.Forms.Label()
        Me.txtChildName = New System.Windows.Forms.TextBox()
        Me.lblOffense = New System.Windows.Forms.Label()
        Me.txtOffense = New System.Windows.Forms.TextBox()
        Me.lblCaseNo = New System.Windows.Forms.Label()
        Me.txtCaseNo = New System.Windows.Forms.TextBox()
        Me.lblChildId = New System.Windows.Forms.Label()
        Me.txtChildId = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblPrePact = New System.Windows.Forms.Label()
        Me.dtpPrePact = New System.Windows.Forms.DateTimePicker()
        Me.lblDob = New System.Windows.Forms.Label()
        Me.dtpDob = New System.Windows.Forms.DateTimePicker()
        Me.lblInitial = New System.Windows.Forms.Label()
        Me.dtpInitialSubmit = New System.Windows.Forms.DateTimePicker()
        Me.lblLastStatus = New System.Windows.Forms.Label()
        Me.dtpLastStatus = New System.Windows.Forms.DateTimePicker()
        Me.chkIntake = New System.Windows.Forms.CheckBox()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.lblPrePactCap = New System.Windows.Forms.Label()
        Me.lblPrePactDays = New System.Windows.Forms.Label()
        Me.lblAgeCap = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblPendingCap = New System.Windows.Forms.Label()
        Me.lblPending = New System.Windows.Forms.Label()
        Me.lblThresholdCap = New System.Windows.Forms.Label()
        Me.lblThreshold = New System.Windows.Forms.Label()
        Me.lblStaffingCap = New System.Windows.Forms.Label()
        Me.lblStaffing = New System.Windows.Forms.Label()
        Me.grpNotes = New System.Windows.Forms.GroupBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.grpRecords = New System.Windows.Forms.GroupBox()
        Me.lvRecords = New System.Windows.Forms.ListView()
        Me.colChildId = New System.Windows.Forms.ColumnHeader()
        Me.colCaseNo = New System.Windows.Forms.ColumnHeader()
        Me.colChild = New System.Windows.Forms.ColumnHeader()
        Me.colOffense = New System.Windows.Forms.ColumnHeader()
        Me.colStatus = New System.Windows.Forms.ColumnHeader()
        Me.colPrePact = New System.Windows.Forms.ColumnHeader()
        Me.colThreshold = New System.Windows.Forms.ColumnHeader()
        Me.colIntake = New System.Windows.Forms.ColumnHeader()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpCase.SuspendLayout()
        Me.grpResults.SuspendLayout()
        Me.grpNotes.SuspendLayout()
        Me.grpRecords.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCase
        '
        Me.grpCase.Controls.Add(Me.lblChild)
        Me.grpCase.Controls.Add(Me.txtChildName)
        Me.grpCase.Controls.Add(Me.lblOffense)
        Me.grpCase.Controls.Add(Me.txtOffense)
        Me.grpCase.Controls.Add(Me.lblCaseNo)
        Me.grpCase.Controls.Add(Me.txtCaseNo)
        Me.grpCase.Controls.Add(Me.lblChildId)
        Me.grpCase.Controls.Add(Me.txtChildId)
        Me.grpCase.Controls.Add(Me.lblStatus)
        Me.grpCase.Controls.Add(Me.txtStatus)
        Me.grpCase.Controls.Add(Me.lblPrePact)
        Me.grpCase.Controls.Add(Me.dtpPrePact)
        Me.grpCase.Controls.Add(Me.lblDob)
        Me.grpCase.Controls.Add(Me.dtpDob)
        Me.grpCase.Controls.Add(Me.lblInitial)
        Me.grpCase.Controls.Add(Me.dtpInitialSubmit)
        Me.grpCase.Controls.Add(Me.lblLastStatus)
        Me.grpCase.Controls.Add(Me.dtpLastStatus)
        Me.grpCase.Controls.Add(Me.chkIntake)
        Me.grpCase.Location = New System.Drawing.Point(12, 12)
        Me.grpCase.Name = "grpCase"
        Me.grpCase.Size = New System.Drawing.Size(540, 305)
        Me.grpCase.TabIndex = 0
        Me.grpCase.TabStop = False
        Me.grpCase.Text = "Case Information"
        '
        'lblChild
        '
        Me.lblChild.AutoSize = True
        Me.lblChild.Location = New System.Drawing.Point(12, 31)
        Me.lblChild.Name = "lblChild"
        Me.lblChild.Text = "Child Name:"
        '
        'txtChildName
        '
        Me.txtChildName.Location = New System.Drawing.Point(150, 28)
        Me.txtChildName.Name = "txtChildName"
        Me.txtChildName.Size = New System.Drawing.Size(370, 23)
        Me.txtChildName.TabIndex = 0
        '
        'lblOffense
        '
        Me.lblOffense.AutoSize = True
        Me.lblOffense.Location = New System.Drawing.Point(12, 61)
        Me.lblOffense.Name = "lblOffense"
        Me.lblOffense.Text = "Offense:"
        '
        'txtOffense
        '
        Me.txtOffense.Location = New System.Drawing.Point(150, 58)
        Me.txtOffense.Name = "txtOffense"
        Me.txtOffense.Size = New System.Drawing.Size(370, 23)
        Me.txtOffense.TabIndex = 1
        '
        'lblCaseNo
        '
        Me.lblCaseNo.AutoSize = True
        Me.lblCaseNo.Location = New System.Drawing.Point(12, 91)
        Me.lblCaseNo.Name = "lblCaseNo"
        Me.lblCaseNo.Text = "Case No.:"
        '
        'txtCaseNo
        '
        Me.txtCaseNo.Location = New System.Drawing.Point(150, 88)
        Me.txtCaseNo.MaxLength = 30
        Me.txtCaseNo.Name = "txtCaseNo"
        Me.txtCaseNo.Size = New System.Drawing.Size(150, 23)
        Me.txtCaseNo.TabIndex = 2
        '
        'lblChildId
        '
        Me.lblChildId.AutoSize = True
        Me.lblChildId.Location = New System.Drawing.Point(316, 91)
        Me.lblChildId.Name = "lblChildId"
        Me.lblChildId.Text = "Child ID:"
        '
        'txtChildId
        '
        Me.txtChildId.BackColor = System.Drawing.SystemColors.Control
        Me.txtChildId.Location = New System.Drawing.Point(380, 88)
        Me.txtChildId.Name = "txtChildId"
        Me.txtChildId.ReadOnly = True
        Me.txtChildId.Size = New System.Drawing.Size(140, 23)
        Me.txtChildId.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 121)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Text = "Status:"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(150, 118)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(370, 23)
        Me.txtStatus.TabIndex = 3
        '
        'lblPrePact
        '
        Me.lblPrePact.AutoSize = True
        Me.lblPrePact.Location = New System.Drawing.Point(12, 156)
        Me.lblPrePact.Name = "lblPrePact"
        Me.lblPrePact.Text = "Pre-PACT Date:"
        '
        'dtpPrePact
        '
        Me.dtpPrePact.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpPrePact.Location = New System.Drawing.Point(150, 152)
        Me.dtpPrePact.Name = "dtpPrePact"
        Me.dtpPrePact.Size = New System.Drawing.Size(130, 23)
        Me.dtpPrePact.TabIndex = 4
        '
        'lblDob
        '
        Me.lblDob.AutoSize = True
        Me.lblDob.Location = New System.Drawing.Point(12, 186)
        Me.lblDob.Name = "lblDob"
        Me.lblDob.Text = "Date of Birth:"
        '
        'dtpDob
        '
        Me.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDob.Location = New System.Drawing.Point(150, 182)
        Me.dtpDob.Name = "dtpDob"
        Me.dtpDob.Size = New System.Drawing.Size(130, 23)
        Me.dtpDob.TabIndex = 5
        '
        'lblInitial
        '
        Me.lblInitial.AutoSize = True
        Me.lblInitial.Location = New System.Drawing.Point(12, 216)
        Me.lblInitial.Name = "lblInitial"
        Me.lblInitial.Text = "Initial Submit Date:"
        '
        'dtpInitialSubmit
        '
        Me.dtpInitialSubmit.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpInitialSubmit.Location = New System.Drawing.Point(150, 212)
        Me.dtpInitialSubmit.Name = "dtpInitialSubmit"
        Me.dtpInitialSubmit.Size = New System.Drawing.Size(130, 23)
        Me.dtpInitialSubmit.TabIndex = 6
        '
        'lblLastStatus
        '
        Me.lblLastStatus.AutoSize = True
        Me.lblLastStatus.Location = New System.Drawing.Point(12, 246)
        Me.lblLastStatus.Name = "lblLastStatus"
        Me.lblLastStatus.Text = "Last Case Status:"
        '
        'dtpLastStatus
        '
        Me.dtpLastStatus.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpLastStatus.Location = New System.Drawing.Point(150, 242)
        Me.dtpLastStatus.Name = "dtpLastStatus"
        Me.dtpLastStatus.Size = New System.Drawing.Size(130, 23)
        Me.dtpLastStatus.TabIndex = 7
        '
        'chkIntake
        '
        Me.chkIntake.AutoSize = True
        Me.chkIntake.Location = New System.Drawing.Point(150, 275)
        Me.chkIntake.Name = "chkIntake"
        Me.chkIntake.TabIndex = 8
        Me.chkIntake.Text = "Intake Completed"
        Me.chkIntake.UseVisualStyleBackColor = True
        '
        'grpResults
        '
        Me.grpResults.Controls.Add(Me.lblPrePactCap)
        Me.grpResults.Controls.Add(Me.lblPrePactDays)
        Me.grpResults.Controls.Add(Me.lblAgeCap)
        Me.grpResults.Controls.Add(Me.lblAge)
        Me.grpResults.Controls.Add(Me.lblPendingCap)
        Me.grpResults.Controls.Add(Me.lblPending)
        Me.grpResults.Controls.Add(Me.lblThresholdCap)
        Me.grpResults.Controls.Add(Me.lblThreshold)
        Me.grpResults.Controls.Add(Me.lblStaffingCap)
        Me.grpResults.Controls.Add(Me.lblStaffing)
        Me.grpResults.Location = New System.Drawing.Point(564, 12)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(314, 305)
        Me.grpResults.TabIndex = 1
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Results"
        '
        'lblPrePactCap
        '
        Me.lblPrePactCap.AutoSize = True
        Me.lblPrePactCap.Location = New System.Drawing.Point(14, 28)
        Me.lblPrePactCap.Name = "lblPrePactCap"
        Me.lblPrePactCap.Text = "Pre-PACT Countdown:"
        '
        'lblPrePactDays
        '
        Me.lblPrePactDays.AutoSize = True
        Me.lblPrePactDays.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrePactDays.Location = New System.Drawing.Point(14, 48)
        Me.lblPrePactDays.Name = "lblPrePactDays"
        Me.lblPrePactDays.Text = "-"
        '
        'lblAgeCap
        '
        Me.lblAgeCap.AutoSize = True
        Me.lblAgeCap.Location = New System.Drawing.Point(14, 82)
        Me.lblAgeCap.Name = "lblAgeCap"
        Me.lblAgeCap.Text = "Current Age:"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAge.Location = New System.Drawing.Point(14, 102)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Text = "-"
        '
        'lblPendingCap
        '
        Me.lblPendingCap.AutoSize = True
        Me.lblPendingCap.Location = New System.Drawing.Point(14, 136)
        Me.lblPendingCap.Name = "lblPendingCap"
        Me.lblPendingCap.Text = "Days Pending:"
        '
        'lblPending
        '
        Me.lblPending.AutoSize = True
        Me.lblPending.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPending.Location = New System.Drawing.Point(14, 156)
        Me.lblPending.Name = "lblPending"
        Me.lblPending.Text = "-"
        '
        'lblThresholdCap
        '
        Me.lblThresholdCap.AutoSize = True
        Me.lblThresholdCap.Location = New System.Drawing.Point(14, 190)
        Me.lblThresholdCap.Name = "lblThresholdCap"
        Me.lblThresholdCap.Text = "Threshold Date (Last Status + 60):"
        '
        'lblThreshold
        '
        Me.lblThreshold.AutoSize = True
        Me.lblThreshold.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblThreshold.Location = New System.Drawing.Point(14, 210)
        Me.lblThreshold.Name = "lblThreshold"
        Me.lblThreshold.Text = "-"
        '
        'lblStaffingCap
        '
        Me.lblStaffingCap.AutoSize = True
        Me.lblStaffingCap.Location = New System.Drawing.Point(14, 244)
        Me.lblStaffingCap.Name = "lblStaffingCap"
        Me.lblStaffingCap.Text = "Countdown to Next Staffing:"
        '
        'lblStaffing
        '
        Me.lblStaffing.AutoSize = True
        Me.lblStaffing.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblStaffing.Location = New System.Drawing.Point(14, 264)
        Me.lblStaffing.Name = "lblStaffing"
        Me.lblStaffing.Text = "-"
        '
        'grpNotes
        '
        Me.grpNotes.Controls.Add(Me.txtNotes)
        Me.grpNotes.Location = New System.Drawing.Point(12, 324)
        Me.grpNotes.Name = "grpNotes"
        Me.grpNotes.Size = New System.Drawing.Size(866, 112)
        Me.grpNotes.TabIndex = 2
        Me.grpNotes.TabStop = False
        Me.grpNotes.Text = "Progress Notes"
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = True
        Me.txtNotes.Location = New System.Drawing.Point(10, 22)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(846, 78)
        Me.txtNotes.TabIndex = 9
        '
        'grpRecords
        '
        Me.grpRecords.Controls.Add(Me.lvRecords)
        Me.grpRecords.Location = New System.Drawing.Point(12, 444)
        Me.grpRecords.Name = "grpRecords"
        Me.grpRecords.Size = New System.Drawing.Size(866, 210)
        Me.grpRecords.TabIndex = 3
        Me.grpRecords.TabStop = False
        Me.grpRecords.Text = "Records"
        '
        'lvRecords
        '
        Me.lvRecords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colChildId, Me.colCaseNo, Me.colChild, Me.colOffense, Me.colStatus, Me.colPrePact, Me.colThreshold, Me.colIntake})
        Me.lvRecords.FullRowSelect = True
        Me.lvRecords.GridLines = True
        Me.lvRecords.HideSelection = False
        Me.lvRecords.Location = New System.Drawing.Point(10, 22)
        Me.lvRecords.MultiSelect = False
        Me.lvRecords.Name = "lvRecords"
        Me.lvRecords.Size = New System.Drawing.Size(846, 178)
        Me.lvRecords.TabIndex = 10
        Me.lvRecords.UseCompatibleStateImageBehavior = False
        Me.lvRecords.View = System.Windows.Forms.View.Details
        '
        'colChildId
        '
        Me.colChildId.Text = "Child ID"
        Me.colChildId.Width = 80
        '
        'colCaseNo
        '
        Me.colCaseNo.Text = "Case No."
        Me.colCaseNo.Width = 100
        '
        'colChild
        '
        Me.colChild.Text = "Child Name"
        Me.colChild.Width = 150
        '
        'colOffense
        '
        Me.colOffense.Text = "Offense"
        Me.colOffense.Width = 140
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        Me.colStatus.Width = 120
        '
        'colPrePact
        '
        Me.colPrePact.Text = "Pre-PACT Date"
        Me.colPrePact.Width = 85
        '
        'colThreshold
        '
        Me.colThreshold.Text = "Threshold"
        Me.colThreshold.Width = 85
        '
        'colIntake
        '
        Me.colIntake.Text = "Intake"
        Me.colIntake.Width = 50
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(12, 664)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(100, 34)
        Me.btnCalculate.TabIndex = 11
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(122, 664)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 34)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(232, 664)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 34)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(342, 664)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 34)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 710)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.grpRecords)
        Me.Controls.Add(Me.grpNotes)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.grpCase)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pre-PACT Case Tracker"
        Me.grpCase.ResumeLayout(False)
        Me.grpCase.PerformLayout()
        Me.grpResults.ResumeLayout(False)
        Me.grpResults.PerformLayout()
        Me.grpNotes.ResumeLayout(False)
        Me.grpNotes.PerformLayout()
        Me.grpRecords.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents grpCase As System.Windows.Forms.GroupBox
    Friend WithEvents lblChild As System.Windows.Forms.Label
    Friend WithEvents txtChildName As System.Windows.Forms.TextBox
    Friend WithEvents lblOffense As System.Windows.Forms.Label
    Friend WithEvents txtOffense As System.Windows.Forms.TextBox
    Friend WithEvents lblCaseNo As System.Windows.Forms.Label
    Friend WithEvents txtCaseNo As System.Windows.Forms.TextBox
    Friend WithEvents lblChildId As System.Windows.Forms.Label
    Friend WithEvents txtChildId As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblPrePact As System.Windows.Forms.Label
    Friend WithEvents dtpPrePact As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDob As System.Windows.Forms.Label
    Friend WithEvents dtpDob As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInitial As System.Windows.Forms.Label
    Friend WithEvents dtpInitialSubmit As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLastStatus As System.Windows.Forms.Label
    Friend WithEvents dtpLastStatus As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkIntake As System.Windows.Forms.CheckBox
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrePactCap As System.Windows.Forms.Label
    Friend WithEvents lblPrePactDays As System.Windows.Forms.Label
    Friend WithEvents lblAgeCap As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblPendingCap As System.Windows.Forms.Label
    Friend WithEvents lblPending As System.Windows.Forms.Label
    Friend WithEvents lblThresholdCap As System.Windows.Forms.Label
    Friend WithEvents lblThreshold As System.Windows.Forms.Label
    Friend WithEvents lblStaffingCap As System.Windows.Forms.Label
    Friend WithEvents lblStaffing As System.Windows.Forms.Label
    Friend WithEvents grpNotes As System.Windows.Forms.GroupBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents grpRecords As System.Windows.Forms.GroupBox
    Friend WithEvents lvRecords As System.Windows.Forms.ListView
    Friend WithEvents colChildId As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCaseNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChild As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOffense As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrePact As System.Windows.Forms.ColumnHeader
    Friend WithEvents colThreshold As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIntake As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
