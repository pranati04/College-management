Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class Form1
    Inherits Form
    Dim flag = 1
    Public Property userIn As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If flag = 1 Then
            MenuStrip1.Show()
            Button1.BackgroundImage = Image.FromFile("H:\images\icons8-hide-sidepanel-50.png")
            Button1.Location = New Point(80, 0) ' Set the new position of the button (x=100, y=100)
            flag = 0
        Else
            MenuStrip1.Hide()
            Button1.BackgroundImage = Image.FromFile("H:\images\icons8-show-sidepanel-50.png")
            Button1.Location = New Point(0, 0)
            flag = 1
        End If
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Dim admin As String
        admin = InputBox("Enter Password")
        admin = "adminpswrd"
        If admin = "adminpswrd" Then
            Dim tableSend As String = "Admin"
            Form2.table = tableSend
            Form2.Show()
        Else
            MsgBox("Contact adminstrator for password")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Font = New Font("Arial", 10)
        MenuStrip1.ForeColor = Color.White
        MenuStrip1.BackColor = Color.FromArgb(60, 60, 60)
        MenuStrip1.Padding = New Padding(5)
        MenuStrip1.Margin = New Padding(0)
        MenuStrip1.Hide()
    End Sub

    Private Sub SyllabusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyllabusToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub FacultyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultyToolStripMenuItem.Click
        Dim tableSend As String = "Faculty"
        Form2.table = tableSend
        Form2.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        If userIn = 0 Then
            Dim tableSend As String = "Student"
            Form2.table = tableSend
            Form2.Show()
        End If
    End Sub

    Private Sub AcadmicCalenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcadmicCalenderToolStripMenuItem.Click
        Form8.Show()
    End Sub

    Private Sub ResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultToolStripMenuItem.Click
        Form9.Show()
    End Sub

    Private Sub FeeDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeeDetailsToolStripMenuItem.Click
        Form10.Show()
    End Sub

    Private Sub RestPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestPasswordToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If userIn = 0 Then
            MessageBox.Show("Not yet logged in!")
        Else
            userIn = 0
            MessageBox.Show("Logged out succesfully!")
        End If
    End Sub
End Class
