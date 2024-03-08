<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcadmicCalenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyllabusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowDrop = True
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.FacultyToolStripMenuItem, Me.StudentToolStripMenuItem, Me.ResultToolStripMenuItem, Me.SyllabusToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(68, 450)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'FacultyToolStripMenuItem
        '
        Me.FacultyToolStripMenuItem.Name = "FacultyToolStripMenuItem"
        Me.FacultyToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.FacultyToolStripMenuItem.Text = "Faculty"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestPasswordToolStripMenuItem, Me.FeeDetailsToolStripMenuItem, Me.AcadmicCalenderToolStripMenuItem})
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.StudentToolStripMenuItem.Text = "Student"
        '
        'RestPasswordToolStripMenuItem
        '
        Me.RestPasswordToolStripMenuItem.Name = "RestPasswordToolStripMenuItem"
        Me.RestPasswordToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RestPasswordToolStripMenuItem.Text = "View Attendance"
        '
        'FeeDetailsToolStripMenuItem
        '
        Me.FeeDetailsToolStripMenuItem.Name = "FeeDetailsToolStripMenuItem"
        Me.FeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.FeeDetailsToolStripMenuItem.Text = "Fee Details"
        '
        'AcadmicCalenderToolStripMenuItem
        '
        Me.AcadmicCalenderToolStripMenuItem.Name = "AcadmicCalenderToolStripMenuItem"
        Me.AcadmicCalenderToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AcadmicCalenderToolStripMenuItem.Text = "Acadmic Calender"
        '
        'ResultToolStripMenuItem
        '
        Me.ResultToolStripMenuItem.Name = "ResultToolStripMenuItem"
        Me.ResultToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.ResultToolStripMenuItem.Text = "Result"
        '
        'SyllabusToolStripMenuItem
        '
        Me.SyllabusToolStripMenuItem.Name = "SyllabusToolStripMenuItem"
        Me.SyllabusToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.SyllabusToolStripMenuItem.Text = "Syllabus"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(55, 19)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 31)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Himalaya", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(687, 341)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(539, 44)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "WELCOME TO EVERGREEN UNIVERSITY"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Home page"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacultyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestPasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcadmicCalenderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SyllabusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
End Class
