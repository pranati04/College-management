Imports System.Data.OleDb
Public Class Form4
    Dim stat As String
    Dim att As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            End If
        Next
        Me.FormBorderStyle = FormBorderStyle.FixedSingle ' Set the border style to FixedSingle
        PictureBox1.TabStop = False
        HideElements()
        appProject.DatabaseModule.OpenConnection()
        Using dr As OleDbDataReader = DatabaseModule.GetDataReader("SELECT Studentid FROM Fee")
            While dr.Read()
                ComboBox1.Items.Add(dr("Studentid").ToString())
            End While
        End Using
        DatabaseModule.CloseConnection()
        appProject.DatabaseModule.OpenConnection()
        Using dr As OleDbDataReader = DatabaseModule.GetDataReader("SELECT DISTINCT ID FROM Attendance")
            While dr.Read()
                ComboBox2.Items.Add(dr("ID").ToString())
            End While
        End Using
        DatabaseModule.CloseConnection()
    End Sub

    Private Sub FeeRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeeRecordsToolStripMenuItem.Click
        HideElements()
        ComboBox1.Show()
        Label1.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox2.Text = ""
        If ComboBox1.SelectedIndex >= 0 Then
            Dim selectedStudentID As String = ComboBox1.SelectedItem.ToString()

            DatabaseModule.OpenConnection()

            Dim query As String = "SELECT SName, Branch, SYear FROM Student WHERE ID = '" & selectedStudentID & "'"
            Dim reader As OleDbDataReader = DatabaseModule.GetDataReader(query)

            If reader.Read() Then
                TextBox1.Text = reader.GetString(0) ' Assuming SName is at index 0
                TextBox2.Text += reader.GetValue(1) & " " & reader.GetValue(2) & " year"
                ShowElements(0)
            End If

            reader.Close()
            DatabaseModule.CloseConnection()
        End If
    End Sub

    Private Sub HideElements()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox Then
                ctrl.Hide()
            End If
        Next

        RadioButton1.Hide()
        RadioButton2.Hide()
        RadioButton3.Hide()
        RadioButton4.Hide()
        RadioButton5.Hide()
        RadioButton6.Hide()
        Button1.Hide()
        DateTimePicker1.Hide()
        Button2.Hide()
        DateTimePicker1.Hide()
        Button3.Hide()
    End Sub

    Private Sub ShowElements(i As Integer)
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox Then
                ctrl.Show()
            End If
        Next
        If i = 0 Then
            Label7.Hide()
            Label8.Hide()
            RadioButton1.Show()
            RadioButton2.Show()
            RadioButton3.Show()
            RadioButton4.Show()
            Button1.Show()
            DateTimePicker1.Show()
        Else
            Label4.Hide()
            Label5.Hide()
            TextBox3.Hide()
            Label6.Hide()
            Button2.Show()
            DateTimePicker1.Show()
            RadioButton5.Show()
            RadioButton6.Show()
        End If
        Label9.Hide()
        Label11.Hide()
        TextBox4.Hide()
        TextBox5.Hide()
        Button3.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedStudentID As String = ComboBox1.SelectedItem.ToString()
        Dim dueDate As Date = DateTimePicker1.Value
        Dim amountDue As Integer = CInt(TextBox3.Text)
        DatabaseModule.OpenConnection()

        Try
            Dim query As String = "UPDATE Fee SET FeeStatus = @s, AmountDue = @amt, DueBy = @d WHERE Studentid = @id"
            Using command As New OleDbCommand(query, DatabaseModule.GetConnection())
                command.Parameters.AddWithValue("@s", stat)
                command.Parameters.AddWithValue("@amt", amountDue)
                command.Parameters.AddWithValue("@d", dueDate)
                command.Parameters.AddWithValue("@id", selectedStudentID)

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Records updated.")
                    'Me.Hide()
                Else
                    MessageBox.Show("No records updated.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating records: " & ex.Message)
        Finally
            DatabaseModule.CloseConnection()
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        stat = "Due"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        stat = "Partially Due"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        stat = "Paid"
        TextBox3.Text = "0"
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        stat = "Scholarship"
        TextBox3.Text = "0"
    End Sub

    Private Sub AttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttendanceToolStripMenuItem.Click
        HideElements()
        ComboBox2.Show()
        Label1.Show()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox2.Text = ""
        If ComboBox2.SelectedIndex >= 0 Then
            Dim selectedStudentID As String = ComboBox2.SelectedItem.ToString()

            DatabaseModule.OpenConnection()

            Dim query As String = "SELECT SName, Branch, SYear FROM Student WHERE ID = '" & selectedStudentID & "'"
            Dim reader As OleDbDataReader = DatabaseModule.GetDataReader(query)

            If reader.Read() Then
                TextBox1.Text = reader.GetString(0) ' Assuming SName is at index 0
                TextBox2.Text += reader.GetValue(1) & " " & reader.GetValue(2) & " year"
                ShowElements(1)
            End If

            reader.Close()
            DatabaseModule.CloseConnection()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectedStudentID As String = ComboBox2.SelectedItem.ToString()
        Dim dd As Date = DateTimePicker1.Value
        'Dim amountDue As Integer = CInt(TextBox3.Text)
        DatabaseModule.OpenConnection()

        Try
            Dim query As String = "UPDATE Attendance SET Status = @a, Class = @cl, ClassDate = @d WHERE ID = @id"
            Using command As New OleDbCommand(query, DatabaseModule.GetConnection())
                command.Parameters.AddWithValue("@a", att)
                command.Parameters.AddWithValue("@cl", TextBox2.Text)
                command.Parameters.AddWithValue("@d", dd)
                command.Parameters.AddWithValue("@id", selectedStudentID)

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Records updated.")
                    'Me.Hide()
                Else
                    MessageBox.Show("No records updated.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating records: " & ex.Message)
        Finally
            DatabaseModule.CloseConnection()
        End Try

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        att = "Present"
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        att = "Absent"
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Dim tableSend As String = "Admin"
        Form6.table = tableSend
        Form6.Show()
    End Sub

    Private Sub FacultyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultyToolStripMenuItem.Click
        Dim tableSend As String = "Faculty"
        Form6.table = tableSend
        Form6.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        Dim tableSend As String = "Student"
        Form6.table = tableSend
        Form6.Show()
    End Sub

    Private Sub AdminToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem1.Click
        Dim id As String
        Dim metap As String
        id = InputBox("Enter username to be deleted from admin database: ")
        metap = InputBox("Enter data master password: ")
        If metap = "metapswrd" Then
            DatabaseModule.OpenConnection()
            Dim query As String = "DELETE FROM Admin WHERE USERNAME = @username"

            Dim command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@username", id)
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Admin user deleted successfully.")
            Else
                MessageBox.Show("No admin user with this username exists")
            End If
            DatabaseModule.CloseConnection()
        End If

    End Sub

    Private Sub FacultyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacultyToolStripMenuItem1.Click
        Dim id As String
        Dim metap As String
        id = InputBox("Enter username to be deleted from faculty database: ")
        metap = InputBox("Enter data master password: ")
        metap = "metapswrd"
        If metap = "metapswrd" Then
            DatabaseModule.OpenConnection()
            Dim query As String = "DELETE FROM Faculty WHERE USERNAME = @username"

            Dim command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@username", id)
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Faculty user deleted successfully.")
            Else
                MessageBox.Show("No faculty user with this username exists")
            End If
            DatabaseModule.CloseConnection()
        End If
    End Sub

    Private Sub StudentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem1.Click
        Dim id As String
        Dim metap As String
        id = InputBox("Enter username to be deleted from student database: ")
        metap = InputBox("Enter data master password: ")
        If metap = "metapswrd" Then
            DatabaseModule.OpenConnection()
            Dim query As String = "DELETE FROM Student WHERE USERNAME = @username"

            Dim command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@username", id)
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Student user deleted successfully.")
            Else
                MessageBox.Show("No student user with this username exists")
            End If
            DatabaseModule.CloseConnection()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String
        query = "INSERT INTO Acadmics (SName,img) VALUES (@name, @p);"
        Dim sname As String = TextBox4.Text
        Dim p As String = TextBox5.Text
        DatabaseModule.OpenConnection()
        Using command As New OleDbCommand(query, DatabaseModule.GetConnection())
            command.Parameters.AddWithValue("@name", sname)
            command.Parameters.AddWithValue("@p", p)
            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Data added successfully.")
                ' Optionally, clear the text boxes after adding the user
                Me.Hide()
            Else
                MessageBox.Show("Failed to insert data.")
            End If
        End Using
        DatabaseModule.CloseConnection()
    End Sub

    Private Sub AcadmicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcadmicsToolStripMenuItem.Click
        HideElements()
        Label9.Show()
        Label11.Show()
        TextBox4.Show()
        TextBox5.Show()
        Button3.Show()
    End Sub

End Class
