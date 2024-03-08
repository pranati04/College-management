
Imports System.Data.OleDb

Public Class AttendanceManager
    Public Shared Sub AddAttendance(selectedStudentID As String, n As String, d As Date, b As String, c As String, s As String)
        Try
            appProject.DatabaseModule.OpenConnection()

            Dim query As String = "INSERT INTO Attendance (ClassDate, SName, ID, Branch, Class, Status) VALUES (@d, @n, @id, @b, @c, @s);"

            Using command As New OleDbCommand(query, appProject.DatabaseModule.GetConnection())
                command.Parameters.AddWithValue("@d", d)
                command.Parameters.AddWithValue("@n", n)
                command.Parameters.AddWithValue("@id", selectedStudentID)
                command.Parameters.AddWithValue("@b", b)
                command.Parameters.AddWithValue("@c", c)
                command.Parameters.AddWithValue("@s", s)
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Attendance added successfully.")
                Else
                    MessageBox.Show("Failed to add attendance.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            appProject.DatabaseModule.CloseConnection()
        End Try
    End Sub
End Class
