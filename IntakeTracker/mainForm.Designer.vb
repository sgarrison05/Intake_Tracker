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
        grpCase = New System.Windows.Forms.GroupBox()
        lblLEA = New System.Windows.Forms.Label()
        txbLEAgency = New System.Windows.Forms.TextBox()
        lblChild = New System.Windows.Forms.Label()
        txtChildName = New System.Windows.Forms.TextBox()
        lblOffense = New System.Windows.Forms.Label()
        txtOffense = New System.Windows.Forms.TextBox()
        lblCaseNo = New System.Windows.Forms.Label()
        txtCaseNo = New System.Windows.Forms.TextBox()
        lblStatus = New System.Windows.Forms.Label()
        txtStatus = New System.Windows.Forms.TextBox()
        lblPrePact = New System.Windows.Forms.Label()
        dtpPrePact = New System.Windows.Forms.DateTimePicker()
        lblDob = New System.Windows.Forms.Label()
        dtpDob = New System.Windows.Forms.DateTimePicker()
        lblInitial = New System.Windows.Forms.Label()
        dtpInitialSubmit = New System.Windows.Forms.DateTimePicker()
        lblLastStatus = New System.Windows.Forms.Label()
        dtpLastStatus = New System.Windows.Forms.DateTimePicker()
        chkIntake = New System.Windows.Forms.CheckBox()
        grpResults = New System.Windows.Forms.GroupBox()
        lbl18BirthdayCap = New System.Windows.Forms.Label()
        lbl18Birthday = New System.Windows.Forms.Label()
        lblPrePactCap = New System.Windows.Forms.Label()
        lblPrePactDays = New System.Windows.Forms.Label()
        lblAgeCap = New System.Windows.Forms.Label()
        lblAge = New System.Windows.Forms.Label()
        lblPendingCap = New System.Windows.Forms.Label()
        lblPending = New System.Windows.Forms.Label()
        lblThresholdCap = New System.Windows.Forms.Label()
        lblThreshold = New System.Windows.Forms.Label()
        lblStaffingCap = New System.Windows.Forms.Label()
        lblStaffing = New System.Windows.Forms.Label()
        grpNotes = New System.Windows.Forms.GroupBox()
        txtNotes = New System.Windows.Forms.TextBox()
        grpRecords = New System.Windows.Forms.GroupBox()
        lvRecords = New System.Windows.Forms.ListView()
        colChild = New System.Windows.Forms.ColumnHeader()
        colLEA = New System.Windows.Forms.ColumnHeader()
        colCaseNo = New System.Windows.Forms.ColumnHeader()
        colOffense = New System.Windows.Forms.ColumnHeader()
        colStatus = New System.Windows.Forms.ColumnHeader()
        colIntake = New System.Windows.Forms.ColumnHeader()
        colAge = New System.Windows.Forms.ColumnHeader()
        colPending = New System.Windows.Forms.ColumnHeader()
        colRemaining = New System.Windows.Forms.ColumnHeader()
        btnCalculate = New System.Windows.Forms.Button()
        btnSave = New System.Windows.Forms.Button()
        btnClear = New System.Windows.Forms.Button()
        btnDelete = New System.Windows.Forms.Button()
        btnClose = New System.Windows.Forms.Button()
        lblRecordCount = New System.Windows.Forms.Label()
        grpCase.SuspendLayout()
        grpResults.SuspendLayout()
        grpNotes.SuspendLayout()
        grpRecords.SuspendLayout()
        SuspendLayout()
        ' 
        ' grpCase
        ' 
        grpCase.Controls.Add(lblLEA)
        grpCase.Controls.Add(txbLEAgency)
        grpCase.Controls.Add(lblChild)
        grpCase.Controls.Add(txtChildName)
        grpCase.Controls.Add(lblOffense)
        grpCase.Controls.Add(txtOffense)
        grpCase.Controls.Add(lblCaseNo)
        grpCase.Controls.Add(txtCaseNo)
        grpCase.Controls.Add(lblStatus)
        grpCase.Controls.Add(txtStatus)
        grpCase.Controls.Add(lblPrePact)
        grpCase.Controls.Add(dtpPrePact)
        grpCase.Controls.Add(lblDob)
        grpCase.Controls.Add(dtpDob)
        grpCase.Controls.Add(lblInitial)
        grpCase.Controls.Add(dtpInitialSubmit)
        grpCase.Controls.Add(lblLastStatus)
        grpCase.Controls.Add(dtpLastStatus)
        grpCase.Controls.Add(chkIntake)
        grpCase.Location = New System.Drawing.Point(12, 12)
        grpCase.Name = "grpCase"
        grpCase.Size = New System.Drawing.Size(494, 305)
        grpCase.TabIndex = 0
        grpCase.TabStop = False
        grpCase.Text = "Case Information"
        ' 
        ' lblLEA
        ' 
        lblLEA.AutoSize = True
        lblLEA.Location = New System.Drawing.Point(12, 62)
        lblLEA.Name = "lblLEA"
        lblLEA.Size = New System.Drawing.Size(69, 15)
        lblLEA.TabIndex = 10
        lblLEA.Text = "LE Angency"
        ' 
        ' txbLEAgency
        ' 
        txbLEAgency.Location = New System.Drawing.Point(150, 59)
        txbLEAgency.Name = "txbLEAgency"
        txbLEAgency.Size = New System.Drawing.Size(235, 23)
        txbLEAgency.TabIndex = 1
        ' 
        ' lblChild
        ' 
        lblChild.AutoSize = True
        lblChild.Location = New System.Drawing.Point(12, 31)
        lblChild.Name = "lblChild"
        lblChild.Size = New System.Drawing.Size(73, 15)
        lblChild.TabIndex = 0
        lblChild.Text = "Child Name:"
        ' 
        ' txtChildName
        ' 
        txtChildName.Location = New System.Drawing.Point(150, 28)
        txtChildName.Name = "txtChildName"
        txtChildName.Size = New System.Drawing.Size(235, 23)
        txtChildName.TabIndex = 0
        ' 
        ' lblOffense
        ' 
        lblOffense.AutoSize = True
        lblOffense.Location = New System.Drawing.Point(12, 94)
        lblOffense.Name = "lblOffense"
        lblOffense.Size = New System.Drawing.Size(51, 15)
        lblOffense.TabIndex = 1
        lblOffense.Text = "Offense:"
        ' 
        ' txtOffense
        ' 
        txtOffense.Location = New System.Drawing.Point(150, 91)
        txtOffense.Name = "txtOffense"
        txtOffense.Size = New System.Drawing.Size(235, 23)
        txtOffense.TabIndex = 2
        ' 
        ' lblCaseNo
        ' 
        lblCaseNo.AutoSize = True
        lblCaseNo.Location = New System.Drawing.Point(12, 124)
        lblCaseNo.Name = "lblCaseNo"
        lblCaseNo.Size = New System.Drawing.Size(57, 15)
        lblCaseNo.TabIndex = 2
        lblCaseNo.Text = "Case No.:"
        ' 
        ' txtCaseNo
        ' 
        txtCaseNo.Location = New System.Drawing.Point(150, 121)
        txtCaseNo.MaxLength = 30
        txtCaseNo.Name = "txtCaseNo"
        txtCaseNo.Size = New System.Drawing.Size(120, 23)
        txtCaseNo.TabIndex = 3
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New System.Drawing.Point(12, 154)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New System.Drawing.Size(42, 15)
        lblStatus.TabIndex = 5
        lblStatus.Text = "Status:"
        ' 
        ' txtStatus
        ' 
        txtStatus.Location = New System.Drawing.Point(150, 151)
        txtStatus.Name = "txtStatus"
        txtStatus.Size = New System.Drawing.Size(235, 23)
        txtStatus.TabIndex = 4
        ' 
        ' lblPrePact
        ' 
        lblPrePact.AutoSize = True
        lblPrePact.Location = New System.Drawing.Point(12, 189)
        lblPrePact.Name = "lblPrePact"
        lblPrePact.Size = New System.Drawing.Size(87, 15)
        lblPrePact.TabIndex = 6
        lblPrePact.Text = "Pre-PACT Date:"
        ' 
        ' dtpPrePact
        ' 
        dtpPrePact.Format = System.Windows.Forms.DateTimePickerFormat.Short
        dtpPrePact.Location = New System.Drawing.Point(150, 185)
        dtpPrePact.Name = "dtpPrePact"
        dtpPrePact.Size = New System.Drawing.Size(130, 23)
        dtpPrePact.TabIndex = 5
        ' 
        ' lblDob
        ' 
        lblDob.AutoSize = True
        lblDob.Location = New System.Drawing.Point(12, 219)
        lblDob.Name = "lblDob"
        lblDob.Size = New System.Drawing.Size(76, 15)
        lblDob.TabIndex = 7
        lblDob.Text = "Date of Birth:"
        ' 
        ' dtpDob
        ' 
        dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short
        dtpDob.Location = New System.Drawing.Point(150, 215)
        dtpDob.Name = "dtpDob"
        dtpDob.Size = New System.Drawing.Size(130, 23)
        dtpDob.TabIndex = 6
        ' 
        ' lblInitial
        ' 
        lblInitial.AutoSize = True
        lblInitial.Location = New System.Drawing.Point(12, 249)
        lblInitial.Name = "lblInitial"
        lblInitial.Size = New System.Drawing.Size(107, 15)
        lblInitial.TabIndex = 8
        lblInitial.Text = "Initial Submit Date:"
        ' 
        ' dtpInitialSubmit
        ' 
        dtpInitialSubmit.Format = System.Windows.Forms.DateTimePickerFormat.Short
        dtpInitialSubmit.Location = New System.Drawing.Point(150, 245)
        dtpInitialSubmit.Name = "dtpInitialSubmit"
        dtpInitialSubmit.Size = New System.Drawing.Size(130, 23)
        dtpInitialSubmit.TabIndex = 7
        ' 
        ' lblLastStatus
        ' 
        lblLastStatus.AutoSize = True
        lblLastStatus.Location = New System.Drawing.Point(12, 279)
        lblLastStatus.Name = "lblLastStatus"
        lblLastStatus.Size = New System.Drawing.Size(94, 15)
        lblLastStatus.TabIndex = 9
        lblLastStatus.Text = "Last Case Status:"
        ' 
        ' dtpLastStatus
        ' 
        dtpLastStatus.Format = System.Windows.Forms.DateTimePickerFormat.Short
        dtpLastStatus.Location = New System.Drawing.Point(150, 275)
        dtpLastStatus.Name = "dtpLastStatus"
        dtpLastStatus.Size = New System.Drawing.Size(130, 23)
        dtpLastStatus.TabIndex = 8
        ' 
        ' chkIntake
        ' 
        chkIntake.AutoSize = True
        chkIntake.Location = New System.Drawing.Point(368, 275)
        chkIntake.Name = "chkIntake"
        chkIntake.Size = New System.Drawing.Size(120, 19)
        chkIntake.TabIndex = 8
        chkIntake.Text = "Intake Completed"
        chkIntake.UseVisualStyleBackColor = True
        ' 
        ' grpResults
        ' 
        grpResults.Controls.Add(lbl18BirthdayCap)
        grpResults.Controls.Add(lbl18Birthday)
        grpResults.Controls.Add(lblPrePactCap)
        grpResults.Controls.Add(lblPrePactDays)
        grpResults.Controls.Add(lblAgeCap)
        grpResults.Controls.Add(lblAge)
        grpResults.Controls.Add(lblPendingCap)
        grpResults.Controls.Add(lblPending)
        grpResults.Controls.Add(lblThresholdCap)
        grpResults.Controls.Add(lblThreshold)
        grpResults.Controls.Add(lblStaffingCap)
        grpResults.Controls.Add(lblStaffing)
        grpResults.Location = New System.Drawing.Point(512, 12)
        grpResults.Name = "grpResults"
        grpResults.Size = New System.Drawing.Size(397, 424)
        grpResults.TabIndex = 1
        grpResults.TabStop = False
        grpResults.Text = "Results"
        ' 
        ' lbl18BirthdayCap
        ' 
        lbl18BirthdayCap.AutoSize = True
        lbl18BirthdayCap.Location = New System.Drawing.Point(14, 91)
        lbl18BirthdayCap.Name = "lbl18BirthdayCap"
        lbl18BirthdayCap.Size = New System.Drawing.Size(107, 15)
        lbl18BirthdayCap.TabIndex = 10
        lbl18BirthdayCap.Text = "18th Birthday Date:"
        ' 
        ' lbl18Birthday
        ' 
        lbl18Birthday.AutoSize = True
        lbl18Birthday.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lbl18Birthday.Location = New System.Drawing.Point(14, 111)
        lbl18Birthday.Name = "lbl18Birthday"
        lbl18Birthday.Size = New System.Drawing.Size(15, 20)
        lbl18Birthday.TabIndex = 11
        lbl18Birthday.Text = "-"
        ' 
        ' lblPrePactCap
        ' 
        lblPrePactCap.AutoSize = True
        lblPrePactCap.Location = New System.Drawing.Point(14, 28)
        lblPrePactCap.Name = "lblPrePactCap"
        lblPrePactCap.Size = New System.Drawing.Size(126, 15)
        lblPrePactCap.TabIndex = 0
        lblPrePactCap.Text = "Pre-PACT Countdown:"
        ' 
        ' lblPrePactDays
        ' 
        lblPrePactDays.AutoSize = True
        lblPrePactDays.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lblPrePactDays.Location = New System.Drawing.Point(14, 48)
        lblPrePactDays.Name = "lblPrePactDays"
        lblPrePactDays.Size = New System.Drawing.Size(15, 20)
        lblPrePactDays.TabIndex = 1
        lblPrePactDays.Text = "-"
        ' 
        ' lblAgeCap
        ' 
        lblAgeCap.AutoSize = True
        lblAgeCap.Location = New System.Drawing.Point(14, 151)
        lblAgeCap.Name = "lblAgeCap"
        lblAgeCap.Size = New System.Drawing.Size(74, 15)
        lblAgeCap.TabIndex = 2
        lblAgeCap.Text = "Current Age:"
        ' 
        ' lblAge
        ' 
        lblAge.AutoSize = True
        lblAge.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lblAge.Location = New System.Drawing.Point(14, 171)
        lblAge.Name = "lblAge"
        lblAge.Size = New System.Drawing.Size(15, 20)
        lblAge.TabIndex = 3
        lblAge.Text = "-"
        ' 
        ' lblPendingCap
        ' 
        lblPendingCap.AutoSize = True
        lblPendingCap.Location = New System.Drawing.Point(14, 205)
        lblPendingCap.Name = "lblPendingCap"
        lblPendingCap.Size = New System.Drawing.Size(82, 15)
        lblPendingCap.TabIndex = 4
        lblPendingCap.Text = "Days Pending:"
        ' 
        ' lblPending
        ' 
        lblPending.AutoSize = True
        lblPending.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lblPending.Location = New System.Drawing.Point(14, 225)
        lblPending.Name = "lblPending"
        lblPending.Size = New System.Drawing.Size(15, 20)
        lblPending.TabIndex = 5
        lblPending.Text = "-"
        ' 
        ' lblThresholdCap
        ' 
        lblThresholdCap.AutoSize = True
        lblThresholdCap.Location = New System.Drawing.Point(14, 259)
        lblThresholdCap.Name = "lblThresholdCap"
        lblThresholdCap.Size = New System.Drawing.Size(182, 15)
        lblThresholdCap.TabIndex = 6
        lblThresholdCap.Text = "Threshold Date (Last Status + 60):"
        ' 
        ' lblThreshold
        ' 
        lblThreshold.AutoSize = True
        lblThreshold.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lblThreshold.Location = New System.Drawing.Point(14, 279)
        lblThreshold.Name = "lblThreshold"
        lblThreshold.Size = New System.Drawing.Size(15, 20)
        lblThreshold.TabIndex = 7
        lblThreshold.Text = "-"
        ' 
        ' lblStaffingCap
        ' 
        lblStaffingCap.AutoSize = True
        lblStaffingCap.Location = New System.Drawing.Point(14, 313)
        lblStaffingCap.Name = "lblStaffingCap"
        lblStaffingCap.Size = New System.Drawing.Size(159, 15)
        lblStaffingCap.TabIndex = 8
        lblStaffingCap.Text = "Countdown to Next Staffing:"
        ' 
        ' lblStaffing
        ' 
        lblStaffing.AutoSize = True
        lblStaffing.Font = New System.Drawing.Font("Segoe UI", 11F, Drawing.FontStyle.Bold)
        lblStaffing.Location = New System.Drawing.Point(14, 333)
        lblStaffing.Name = "lblStaffing"
        lblStaffing.Size = New System.Drawing.Size(15, 20)
        lblStaffing.TabIndex = 9
        lblStaffing.Text = "-"
        ' 
        ' grpNotes
        ' 
        grpNotes.Controls.Add(txtNotes)
        grpNotes.Location = New System.Drawing.Point(12, 324)
        grpNotes.Name = "grpNotes"
        grpNotes.Size = New System.Drawing.Size(494, 112)
        grpNotes.TabIndex = 2
        grpNotes.TabStop = False
        grpNotes.Text = "Progress Notes"
        ' 
        ' txtNotes
        ' 
        txtNotes.AcceptsReturn = True
        txtNotes.Location = New System.Drawing.Point(10, 22)
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        txtNotes.Size = New System.Drawing.Size(478, 78)
        txtNotes.TabIndex = 0
        ' 
        ' grpRecords
        ' 
        grpRecords.Controls.Add(lvRecords)
        grpRecords.Location = New System.Drawing.Point(12, 444)
        grpRecords.Name = "grpRecords"
        grpRecords.Size = New System.Drawing.Size(884, 210)
        grpRecords.TabIndex = 3
        grpRecords.TabStop = False
        grpRecords.Text = "Records"
        ' 
        ' lvRecords
        ' 
        lvRecords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {colChild, colLEA, colCaseNo, colOffense, colStatus, colIntake, colAge, colPending, colRemaining})
        lvRecords.FullRowSelect = True
        lvRecords.GridLines = True
        lvRecords.Location = New System.Drawing.Point(10, 22)
        lvRecords.MultiSelect = False
        lvRecords.Name = "lvRecords"
        lvRecords.Size = New System.Drawing.Size(887, 178)
        lvRecords.TabIndex = 0
        lvRecords.UseCompatibleStateImageBehavior = False
        lvRecords.View = System.Windows.Forms.View.Details
        ' 
        ' colChild
        ' 
        colChild.Text = "Child Name"
        colChild.Width = 150
        ' 
        ' colLEA
        ' 
        colLEA.Text = "LEA"
        ' 
        ' colCaseNo
        ' 
        colCaseNo.Text = "Case No."
        colCaseNo.Width = 100
        ' 
        ' colOffense
        ' 
        colOffense.Text = "Offense"
        colOffense.Width = 140
        ' 
        ' colStatus
        ' 
        colStatus.Text = "Status"
        colStatus.Width = 120
        ' 
        ' colIntake
        ' 
        colIntake.Text = "Intake"
        colIntake.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        colIntake.Width = 50
        ' 
        ' colAge
        ' 
        colAge.Text = "Age"
        colAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        colAge.Width = 45
        ' 
        ' colPending
        ' 
        colPending.Text = "Days Pending"
        colPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        colPending.Width = 90
        ' 
        ' colRemaining
        ' 
        colRemaining.Text = "PACT Countdown"
        colRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        colRemaining.Width = 110
        ' 
        ' btnCalculate
        ' 
        btnCalculate.Location = New System.Drawing.Point(12, 688)
        btnCalculate.Name = "btnCalculate"
        btnCalculate.Size = New System.Drawing.Size(100, 34)
        btnCalculate.TabIndex = 11
        btnCalculate.Text = "Calculate"
        btnCalculate.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New System.Drawing.Point(122, 688)
        btnSave.Name = "btnSave"
        btnSave.Size = New System.Drawing.Size(100, 34)
        btnSave.TabIndex = 12
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New System.Drawing.Point(232, 688)
        btnClear.Name = "btnClear"
        btnClear.Size = New System.Drawing.Size(100, 34)
        btnClear.TabIndex = 13
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New System.Drawing.Point(342, 688)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New System.Drawing.Size(100, 34)
        btnDelete.TabIndex = 14
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New System.Drawing.Point(452, 688)
        btnClose.Name = "btnClose"
        btnClose.Size = New System.Drawing.Size(100, 34)
        btnClose.TabIndex = 15
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblRecordCount
        ' 
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New System.Drawing.Point(14, 660)
        lblRecordCount.Name = "lblRecordCount"
        lblRecordCount.Size = New System.Drawing.Size(89, 15)
        lblRecordCount.TabIndex = 16
        lblRecordCount.Text = "Total Records: 0"
        ' 
        ' mainForm
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(932, 734)
        Controls.Add(lblRecordCount)
        Controls.Add(btnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnClear)
        Controls.Add(btnSave)
        Controls.Add(btnCalculate)
        Controls.Add(grpRecords)
        Controls.Add(grpNotes)
        Controls.Add(grpResults)
        Controls.Add(grpCase)
        Font = New System.Drawing.Font("Segoe UI", 9F)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "mainForm"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Text = "Pre-PACT Case Tracker"
        grpCase.ResumeLayout(False)
        grpCase.PerformLayout()
        grpResults.ResumeLayout(False)
        grpResults.PerformLayout()
        grpNotes.ResumeLayout(False)
        grpNotes.PerformLayout()
        grpRecords.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents grpCase As System.Windows.Forms.GroupBox
    Friend WithEvents lblChild As System.Windows.Forms.Label
    Friend WithEvents txtChildName As System.Windows.Forms.TextBox
    Friend WithEvents lblOffense As System.Windows.Forms.Label
    Friend WithEvents txtOffense As System.Windows.Forms.TextBox
    Friend WithEvents lblCaseNo As System.Windows.Forms.Label
    Friend WithEvents txtCaseNo As System.Windows.Forms.TextBox
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
    Friend WithEvents colCaseNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChild As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOffense As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRemaining As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIntake As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents colLEA As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblLEA As System.Windows.Forms.Label
    Friend WithEvents txbLEAgency As System.Windows.Forms.TextBox
    Friend WithEvents lbl18BirthdayCap As System.Windows.Forms.Label
    Friend WithEvents lbl18Birthday As System.Windows.Forms.Label
    Friend WithEvents colAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPending As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
End Class
