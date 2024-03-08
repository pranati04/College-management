Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data.OleDb
Public Class Form3
    Public Property t As String
    Dim query As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = TextBox3.Text Then
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\projectDatabase\USERS.accdb;"

            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@pass", TextBox2.Text)
                    command.Parameters.AddWithValue("@use", TextBox1.Text)

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Password updated successfully.")
                        Me.Hide()
                    Else
                        MessageBox.Show("No records updated.")
                    End If
                End Using
            End Using
            DatabaseModule.CloseConnection()
        Else
            MessageBox.Show("Passwords do not match!")
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Change.Toggle(Me)
            CheckBox1.Text = "Dark Mode"
            Label1.ForeColor = Color.White
            Label2.ForeColor = Color.White
            Label3.ForeColor = Color.White
            Label4.ForeColor = Color.White
            Button1.BackColor = Color.Black
            Button1.ForeColor = Color.White
        Else
            Change.Toggle(Me)
            CheckBox1.Text = "Light Mode"
            Label1.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
            Button1.BackColor = Color.White
            Button1.ForeColor = Color.Black
        End If
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.TabStop = False
        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            End If
        Next
        If t = "Admin" Then
            query = "UPDATE Admin SET PASS = @pass WHERE USERNAME = @use;"
            TextBox1.Text = "Arun"
            TextBox2.Text = "Arun"
            TextBox3.Text = "Arun"
        ElseIf t = "Faculty" Then
            query = "UPDATE Faculty SET PASS = @pass WHERE USERNAME = @use;"
            TextBox1.Text = "Amit"
            TextBox2.Text = "Amit"
            TextBox3.Text = "Amit"
        Else
            query = "UPDATE Student SET PASS = @pass WHERE USERNAME = @use;"
            TextBox1.Text = "Aisha1"
            TextBox2.Text = "Sun"
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If TextBox3.UseSystemPasswordChar Then
            TextBox3.UseSystemPasswordChar = False
            PictureBox2.Image = Image.FromFile("H:\images\ima.png")
        Else
            TextBox3.UseSystemPasswordChar = True
            PictureBox2.Image = Image.FromFile("H:\images\image.png")
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox3.UseSystemPasswordChar = True
    End Sub
End Class