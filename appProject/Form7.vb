Imports System.Data.OleDb
Imports System.Text

Public Class Form7
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Clear the RichTextBox
        RichTextBox1.Clear()
        Dim studentID As String = TextBox1.Text
        DisplayAttendanceInfo(studentID, RichTextBox1)
    End Sub
    Private Sub DisplayAttendanceInfo(studentID As String, richTextBox As RichTextBox)
        Dim attendanceInfo As New Dictionary(Of String, Tuple(Of Integer, Integer, Integer))()
        Dim totalClassesHeld As Integer = 0
        Dim totalClassesAttended As Integer = 0

        ' Query to get attendance data for the student
        Dim query As String = "SELECT Class, COUNT(*) AS TotalClasses, SUM(IIf(Status = 'present', 1, 0)) AS TotalAttended " &
                               "FROM Attendance " &
                               "WHERE ID = @StudentID " &
                               "GROUP BY Class"
        Using connection As OleDbConnection = DatabaseModule.GetConnection(),
              command As New OleDbCommand(query, connection)
            command.Parameters.Add("@StudentID", OleDbType.VarChar).Value = studentID
            connection.Open()
            Dim reader As OleDbDataReader = command.ExecuteReader()
            While reader.Read()
                Dim subjectID As String = reader("Class").ToString()
                Dim totalClasses As Integer = Convert.ToInt32(reader("TotalClasses"))
                Dim totalAttended As Integer = Convert.ToInt32(reader("TotalAttended"))
                attendanceInfo(subjectID) = New Tuple(Of Integer, Integer, Integer)(totalClasses, totalAttended, 0)
                totalClassesHeld += totalClasses
                totalClassesAttended += totalAttended
            End While
            reader.Close()

            ' Calculate attendance percentage for each subject
            Dim updatedAttendanceInfo As New Dictionary(Of String, Tuple(Of Integer, Integer, Integer))()
            For Each kvp As KeyValuePair(Of String, Tuple(Of Integer, Integer, Integer)) In attendanceInfo
                Dim attendancePercentage As Integer = 0
                If kvp.Value.Item1 > 0 Then
                    attendancePercentage = (kvp.Value.Item2 * 100) / kvp.Value.Item1
                End If
                updatedAttendanceInfo(kvp.Key) = New Tuple(Of Integer, Integer, Integer)(kvp.Value.Item1, kvp.Value.Item2, attendancePercentage)
            Next
            attendanceInfo = updatedAttendanceInfo
            ' Display the attendance information in the RichTextBox
            Dim sb As New StringBuilder()
            sb.AppendLine("Class | Total Classes | Total Attended | Attendance Percentage")
            sb.AppendLine("------------------------------------------------------------")
            For Each kvp As KeyValuePair(Of String, Tuple(Of Integer, Integer, Integer)) In attendanceInfo
                sb.AppendLine($"{kvp.Key,-15} | {kvp.Value.Item1,-15} | {kvp.Value.Item2,-15} | {kvp.Value.Item3}%")
            Next
            sb.AppendLine("------------------------------------------------------------")
            sb.AppendLine($"Total Classes Held: {totalClassesHeld}")
            sb.AppendLine($"Total Classes Attended: {totalClassesAttended}")
            sb.AppendLine($"Total Attendance Percentage: {(totalClassesAttended * 100) / totalClassesHeld}%")

            richTextBox.Text = sb.ToString()
        End Using
    End Sub
End Class