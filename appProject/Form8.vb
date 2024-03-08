Imports System.Data.OleDb
Imports System.IO
Public Class Form8
    Inherits Form
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim selectedName As String = ComboBox1.SelectedItem.ToString()

        ' Assuming you have a database connection and a query to retrieve the image path
        Dim query As String = "SELECT img FROM Acadmics WHERE SName = @Name"
        DatabaseModule.OpenConnection()
        Dim comm As New OleDbCommand(query, DatabaseModule.GetConnection())
        comm.Parameters.AddWithValue("@Name", selectedName)
        Dim imagePath As String = Convert.ToString(comm.ExecuteScalar())
        DatabaseModule.CloseConnection()

        ' Load and display the image
        If Not String.IsNullOrEmpty(imagePath) Then
            PictureBox1.Image = Image.FromFile(imagePath)
        End If
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        appProject.DatabaseModule.OpenConnection()
        Using dr As OleDbDataReader = DatabaseModule.GetDataReader("SELECT SName FROM Acadmics")
            While dr.Read()
                ComboBox1.Items.Add(dr("SName").ToString())
            End While
        End Using
        DatabaseModule.CloseConnection()
    End Sub
End Class