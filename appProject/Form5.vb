Imports System.Data.OleDb
Public Class Form5
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Using path As New Drawing2D.GraphicsPath()
            path.AddEllipse(0, 0, PictureBox1.Width - 1, PictureBox1.Height - 1)
            PictureBox1.Region = New Region(path)
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim linkUrl As String = String.Empty
        Dim code As String = ComboBox1.SelectedItem
        Dim name As String = ComboBox2.SelectedItem

        Try
            DatabaseModule.OpenConnection()

            Dim query As String = "SELECT Syll FROM Syllabi WHERE SubjectCode = @CO OR SubjectName = @NA;"
            Dim command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@CO", code)
            command.Parameters.AddWithValue("@NA", name)

            Dim reader As OleDbDataReader = command.ExecuteReader()

            If reader.Read() Then
                linkUrl = reader.GetString(0)
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error reading link address from database: " & ex.Message)
        Finally
            DatabaseModule.CloseConnection()
        End Try

        If Not String.IsNullOrEmpty(linkUrl) Then
            LinkLabel1.Text = "Click here to visit"
            LinkLabel1.Links.Add(0, LinkLabel1.Text.Length, linkUrl)
        End If
    End Sub
End Class