Imports System.Data.OleDb

Module DatabaseModule
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\projectDatabase\USERS.accdb;"
    Private connection As New OleDbConnection(connectionString)

    Public Sub OpenConnection()
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If connection.State <> ConnectionState.Closed Then
            connection.Close()
        End If
    End Sub

    Public Function GetConnection() As OleDbConnection
        Return connection
    End Function

    Public Function GetDataReader(query As String, Optional parameters As List(Of OleDbParameter) = Nothing) As OleDbDataReader
        Dim command As New OleDbCommand(query, connection)

        If parameters IsNot Nothing Then
            For Each param As OleDbParameter In parameters
                command.Parameters.Add(param)
            Next
        End If

        Return command.ExecuteReader()
    End Function

End Module

