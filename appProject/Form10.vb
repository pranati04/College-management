Imports System.Data.OleDb
Public Class Form10
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Dark mode
            CheckBox1.Text = "Dark Mode"
            Change.Toggle(Me)
            Me.ForeColor = Color.White
            Me.BackColor = Color.Black
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.Black
                End If
            Next
            CheckBox1.ForeColor = Color.Black
        Else
            ' Light mode
            CheckBox1.Text = "Light Mode"
            Change.Toggle(Me)
            Me.ForeColor = Color.Black
            Me.BackColor = Color.White
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button Then
                    ctrl.ForeColor = Color.Black
                    ctrl.BackColor = Color.White
                End If
            Next
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Integer
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("No ID Entered!")

        Else
            Dim p As String = InputBox("Enter password for " & TextBox1.Text)
            RichTextBox1.Clear()

            ' Open the database connection
            DatabaseModule.OpenConnection()

            ' Create a query to select results for the selected exam
            Dim query1 As String = "SELECT PASS FROM Student WHERE Id = @i"
            Dim comm As New OleDbCommand(query1, DatabaseModule.GetConnection())
            comm.Parameters.AddWithValue("@i", TextBox1.Text)
            Dim read As OleDbDataReader = comm.ExecuteReader()

            If read.Read() Then
                Dim storedPassword As String = read.GetString(0)
                If p = storedPassword Then
                    flag = 1
                End If
            End If

            read.Close()


        End If
        If flag = 1 Then
            ' Clear the RichTextBox before displaying new results
            RichTextBox1.Clear()
            Dim query As String = "SELECT * FROM Fee WHERE Studentid = @ID"

            DatabaseModule.OpenConnection()
            Using command As New OleDbCommand(query, DatabaseModule.GetConnection())
                command.Parameters.AddWithValue("@ID", TextBox1.Text)
                Dim reader As OleDbDataReader = command.ExecuteReader()
                If reader.Read() Then
                    Dim resultInfo As String = $"Amount Due: {reader("AmountDue").ToString()}" & vbCrLf & $"Due By: {reader("DueBy").ToString()}"
                    TextBox2.Text = reader("FeeStatus").ToString
                    RichTextBox1.AppendText(resultInfo & vbCrLf) ' Append each result on a new line
                End If
                reader.Close()
            End Using
            DatabaseModule.CloseConnection()

        End If
    End Sub
End Class