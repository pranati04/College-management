Public Class Form2
    Public Property table As String
    Dim query As String
    Dim query1 As String
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim flag As Integer
        flag = 0
        Dim user As String
        user = InputBox("Enter Username:")
        Dim id As String
        id = InputBox("Enter Id Number:")
        appProject.DatabaseModule.OpenConnection()
        Using dr As OleDb.OleDbDataReader = DatabaseModule.GetDataReader(query)
            While dr.Read()
                If dr.GetValue(0) = user Then
                    If dr.GetValue(1) = id Then
                        flag = 1
                        Exit While
                    End If
                End If
            End While
        End Using
        If flag = 1 Then
            Form3.t = table
            Form3.Show()
        Else
            MsgBox("Wrong ID Entered!")
        End If
        DatabaseModule.CloseConnection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Integer
        flag = 0
        Dim user, pas As String
        user = TextBox1.Text
        pas = TextBox2.Text
        appProject.DatabaseModule.OpenConnection()
        Using dr As OleDb.OleDbDataReader = DatabaseModule.GetDataReader(query1)
            While dr.Read()
                If dr.GetValue(0) = user Then
                    If dr.GetValue(1) = pas Then
                        flag = 1
                        Exit While
                    End If
                End If
            End While
        End Using
        If flag = 1 Then
            For Each control As Control In Me.Controls
                If TypeOf control Is TextBox Then
                    CType(control, TextBox).Clear()
                End If
            Next
            If table = "Admin" Then
                Form4.Show()
                Me.Hide()
            ElseIf table = "Faculty" Then
                Form11.Show()
                Me.Hide()
            Else
                Form1.userIn = 1
                Me.Hide()
            End If
        Else
            MsgBox("Wrong Username/Password Entered!")
        End If
        DatabaseModule.CloseConnection()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.TabStop = False
        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            End If
        Next
        If table = "Admin" Then
            query = "Select USERNAME,Id from Admin;"
            query1 = "Select USERNAME,PASS from Admin;"
            Label10.Text = "Admin Login"
            TextBox1.Text = "Arun"
            TextBox2.Text = "Arun"
        ElseIf table = "Faculty" Then
            query = "Select USERNAME,Id from Faculty;"
            query1 = "Select USERNAME,PASS from Faculty;"
            Label10.Text = "Faculty Login"
            TextBox1.Text = "Amit"
            TextBox2.Text = "Amit"
        Else
            query = "Select USERNAME,Id from Student;"
            query1 = "Select USERNAME,PASS from Student;"
            Label10.Text = "Student Login"
            TextBox1.Text = "Aisha1"
            TextBox2.Text = "Sun"
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If TextBox2.UseSystemPasswordChar Then
            TextBox2.UseSystemPasswordChar = False
            PictureBox1.Image = Image.FromFile("H:\images\ima.png")
        Else
            TextBox2.UseSystemPasswordChar = True
            PictureBox1.Image = Image.FromFile("H:\images\image.png")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Dim myImage As Image = Image.FromFile("H:\images\Professional Education Badge Logo (2).png")
            ThemeManager.ToggleMode(Me, myImage)
            CheckBox1.Text = "Dark Mode"
            Label1.ForeColor = Color.White
            Label2.ForeColor = Color.White
            Label10.ForeColor = Color.White
            Button1.BackColor = Color.Black
            Button1.ForeColor = Color.White
        Else
            Dim myImage As Image = Image.FromFile("H:\images\Professional Education Badge Logo (1).png")
            ThemeManager.ToggleMode(Me, myImage)
            CheckBox1.Text = "Light Mode"
            Label1.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Button1.BackColor = Color.White
            Button1.ForeColor = Color.Black
        End If
    End Sub
End Class