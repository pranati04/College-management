Imports System.Data.OleDb

Public Class ResultManager
    Public Shared Sub AddResult(id As String, ex As String, br As String, cl As String, sn As String, m As Integer, sy As Integer)
        Try
            appProject.DatabaseModule.OpenConnection()

            Dim query As String = "INSERT INTO Result (Id,Exam,Branch, Class, SName, Marks,SYear) VALUES (@id, @ex, @br, @cl, @sn, @m,@sy);"

            Using command As New OleDbCommand(query, appProject.DatabaseModule.GetConnection())
                command.Parameters.AddWithValue("@id", id)
                command.Parameters.AddWithValue("@ex", ex)
                command.Parameters.AddWithValue("@br", br)
                command.Parameters.AddWithValue("@cl", cl)
                command.Parameters.AddWithValue("@sn", sn)
                command.Parameters.AddWithValue("@m", m)
                command.Parameters.AddWithValue("@sy", sy)
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Result added successfully.")
                Else
                    MessageBox.Show("Failed to add attendance.")
                End If
            End Using
        Catch exc As Exception
            MessageBox.Show("Error: " & exc.Message)
        Finally
            appProject.DatabaseModule.CloseConnection()
        End Try
    End Sub
End Class
