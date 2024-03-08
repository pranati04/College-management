Imports System.Data.OleDb
Public Class Form6
    Public Property table As String
    Dim query As String
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            End If
        Next
        PictureBox1.TabStop = False
        If table <> "Student" Then
            TextBox4.Hide()
            TextBox5.Hide()
            TextBox6.Hide()
            Label4.Hide()
            Label5.Hide()
            Label6.Hide()
        End If
        If table = "Admin" Then
            query = "INSERT INTO Admin (USERNAME, PASS, Id) VALUES (@username, @password, @id);"
            Label10.Text = "New Admin"
        ElseIf table = "Faculty" Then
            query = "INSERT INTO Faculty (USERNAME, PASS, Id) VALUES (@username, @password, @id);"
            Label10.Text = "New Faculty"
        Else
            query = "INSERT INTO Student (USERNAME, PASS, Id,SName,Branch,SYear) VALUES (@username, @password, @id,@name,@br,@sy);"
            Label10.Text = "New Student"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        Dim id As String = TextBox3.Text
        Dim sn As String = TextBox4.Text
        Dim b As String = TextBox5.Text
        Dim y As String = TextBox6.Text
        DatabaseModule.OpenConnection()
        Using command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)
            command.Parameters.AddWithValue("@id", id)
            If table = "Student" Then
                command.Parameters.AddWithValue("@name", sn)
                command.Parameters.AddWithValue("@br", b)
                command.Parameters.AddWithValue("@sy", y)
            End If
            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show(table & " user added successfully.")
                ' Optionally, clear the text boxes after adding the user
                Me.Hide()
            Else
                MessageBox.Show("Failed to add" & table & "user.")
            End If
        End Using
        DatabaseModule.CloseConnection()
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
            Label1.BackColor = Color.Black
            Label2.BackColor = Color.Black
            Label3.ForeColor = Color.White
            Label4.ForeColor = Color.White
            Label3.BackColor = Color.Black
            Label4.BackColor = Color.Black
            Label5.ForeColor = Color.White
            Label5.BackColor = Color.Black
            Button1.BackColor = Color.Black
            Button1.ForeColor = Color.White
            Label10.ForeColor = Color.White
            Label10.BackColor = Color.Black
        Else
            Dim myImage As Image = Image.FromFile("H:\images\Professional Education Badge Logo (1).png")
            ThemeManager.ToggleMode(Me, myImage)
            CheckBox1.Text = "Light Mode"
            Label1.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label1.BackColor = Color.White
            Label2.BackColor = Color.White
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
            Label3.BackColor = Color.White
            Label4.BackColor = Color.White
            Label5.ForeColor = Color.Black
            Label5.BackColor = Color.White
            Button1.BackColor = Color.White
            Button1.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Label10.BackColor = Color.White
        End If
    End Sub
End Class