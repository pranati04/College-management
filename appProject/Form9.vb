Imports System.Data.OleDb
Public Class Form9
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            ' Dark mode
            Dim myImage As Image = Image.FromFile("H:\images\Professional Education Badge Logo (2).png")
            ThemeManager.ToggleMode(Me, myImage)
            CheckBox1.Text = "Dark Mode"
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is DateTimePicker Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.Black
                End If
            Next
        Else
            ' Light mode
            Dim myImage As Image = Image.FromFile("H:\images\Professional Education Badge Logo (1).png")
            ThemeManager.ToggleMode(Me, myImage)
            CheckBox1.Text = "Light Mode"
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is DateTimePicker Then
                    ctrl.ForeColor = Color.Black
                    ctrl.BackColor = Color.White
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()

        ' Open the database connection
        DatabaseModule.OpenConnection()

        ' Create a query to select results for the selected exam
        Dim query As String = "SELECT Class,Marks FROM Result WHERE Exam = @selectedExam"

        ' Create the command and set its properties
        Dim command As New OleDbCommand(query, DatabaseModule.GetConnection())
        command.Parameters.AddWithValue("@selectedExam", ComboBox1.SelectedItem)

        ' Execute the command and create a data reader
        Dim reader As OleDbDataReader = command.ExecuteReader()

        ' Loop through the results and append them to the RichTextBox
        While reader.Read()
            Dim resultInfo As String = $"{reader("Class").ToString()}: {reader("Marks").ToString()}"
            RichTextBox1.AppendText(resultInfo & vbCrLf) ' Append each result on a new line
        End While

        ' Close the data reader and the database connection
        reader.Close()
        DatabaseModule.CloseConnection()
        If RichTextBox1.Lines.Length = 0 Then
            RichTextBox1.Text = "No such data exists yet!"
        End If
    End Sub
End Class