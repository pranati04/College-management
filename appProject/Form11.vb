Imports System.Data.OleDb
Public Class Form11
    Dim chosen As Integer

    Private Sub HideElements()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is DateTimePicker Then
                ctrl.Hide()
            End If
        Next
    End Sub

    Private Sub ShowElements()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is DateTimePicker Then
                ctrl.Show()
            End If
        Next
        If chosen = 1 Then
            Label7.Hide()
            Label8.Hide()
            Label9.Hide()
            TextBox1.Hide()
            TextBox2.Hide()
            ComboBox5.Hide()
        Else
            DateTimePicker1.Hide()
            Label5.Hide()
            Label6.Hide()
            RadioButton1.Hide()
            RadioButton2.Hide()
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "BTech. CS" Then
            ComboBox2.Items.Add("7")
            ComboBox2.Items.Add("8")
        End If
        Label2.Show()
        ComboBox2.Show()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim br As String = ComboBox1.SelectedItem
        Dim y As Integer = ComboBox2.SelectedItem
        DatabaseModule.OpenConnection()
        Dim parameters As New List(Of OleDbParameter)()
        parameters.Add(New OleDbParameter("@br", br))
        parameters.Add(New OleDbParameter("@y", y))

        Using dr As OleDb.OleDbDataReader = DatabaseModule.GetDataReader("SELECT Id FROM Student WHERE Branch = @br AND SYear = @y", parameters)
            While dr.Read()
                ComboBox3.Items.Add(dr("Id").ToString())
            End While
        End Using
        Label3.Show()
        ComboBox3.Show()
        DatabaseModule.CloseConnection()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox1.SelectedItem = "BCA" Then
            If ComboBox2.SelectedItem = "1" Then
                ComboBox4.Items.Add("Programming in C")
                ComboBox4.Items.Add("Digital Computer Fundamentals")
                ComboBox4.Items.Add("Principles of Management")
                ComboBox4.Items.Add("Business Communication")
                ComboBox4.Items.Add("Mathematics for Computing")
            ElseIf ComboBox2.SelectedItem = "2" Then
                ComboBox4.Items.Add("Database Management Systems")
                ComboBox4.Items.Add("Computer Networks")
                ComboBox4.Items.Add("Data Structures")
                ComboBox4.Items.Add("Object-Oriented Programming Using C++")
                ComboBox4.Items.Add("Software Engineering")
            ElseIf ComboBox2.SelectedItem = "3" Then
                ComboBox4.Items.Add("Visual Basic")
                ComboBox4.Items.Add("Computer Architecture")
                ComboBox4.Items.Add("Operating Systems")
                ComboBox4.Items.Add("Java Programming")
                ComboBox4.Items.Add("Web Technology")
            ElseIf ComboBox2.SelectedItem = "4" Then
                ComboBox4.Items.Add("Computer Graphics")
                ComboBox4.Items.Add("Microprocessor Systems")
                ComboBox4.Items.Add("Software Project Management")
                ComboBox4.Items.Add("Artificial Intelligence")
                ComboBox4.Items.Add("System Analysis and Design")
            ElseIf ComboBox2.SelectedItem = "5" Then
                ComboBox4.Items.Add("Network Security")
                ComboBox4.Items.Add("Advanced Database Management Systems")
                ComboBox4.Items.Add("Mobile Application Development")
                ComboBox4.Items.Add("Cloud Computing")
                ComboBox4.Items.Add("Python Programming")
            Else
                ComboBox4.Items.Add("Big Data Analytics")
                ComboBox4.Items.Add("Internet of Things (IoT)")
                ComboBox4.Items.Add("Cyber Security")
                ComboBox4.Items.Add("Multimedia Systems")
                ComboBox4.Items.Add("Computer Simulation and Modeling")
            End If
        Else
            If ComboBox1.SelectedItem = "1" Then
                ComboBox4.Items.Add("Engineering Mathematics")
                ComboBox4.Items.Add("Digital Logic")
                ComboBox4.Items.Add("Computer Organization and Architecture")
                ComboBox4.Items.Add("Programming and Data Structures")
                ComboBox4.Items.Add("Algorithms")
            ElseIf ComboBox2.SelectedItem = "2" Then
                ComboBox4.Items.Add("Theory of Computation")
                ComboBox4.Items.Add("Compiler Design")
                ComboBox4.Items.Add("Operating Systems")
                ComboBox4.Items.Add("Database Management Systems")
                ComboBox4.Items.Add("Computer Networks")
            ElseIf ComboBox2.SelectedItem = "3" Then
                ComboBox4.Items.Add("Software Engineering")
                ComboBox4.Items.Add("Web Technologies")
                ComboBox4.Items.Add("Mobile Computing")
                ComboBox4.Items.Add("Cloud Computing")
                ComboBox4.Items.Add("Data Mining and Data Warehousing")
            ElseIf ComboBox2.SelectedItem = "4" Then
                ComboBox4.Items.Add("Artificial Intelligence")
                ComboBox4.Items.Add("Machine Learning")
                ComboBox4.Items.Add("Computer Graphics")
                ComboBox4.Items.Add("Information and Network Security")
                ComboBox4.Items.Add("Internet of Things (IoT)")
            ElseIf ComboBox2.SelectedItem = "5" Then
                ComboBox4.Items.Add("Parallel and Distributed Computing")
                ComboBox4.Items.Add("Software Testing and Quality Assurance")
                ComboBox4.Items.Add("Big Data Analytics")
                ComboBox4.Items.Add("Cyber Security")
                ComboBox4.Items.Add("Robotics")
            ElseIf ComboBox2.SelectedItem = "6" Then
                ComboBox4.Items.Add("Natural Language Processing")
                ComboBox4.Items.Add("Computer Vision")
                ComboBox4.Items.Add("Blockchain Technology")
                ComboBox4.Items.Add("Computer Hardware Design")
                ComboBox4.Items.Add("Embedded Systems")
            ElseIf ComboBox2.SelectedItem = "7" Then
                ComboBox4.Items.Add("Computer Simulation and Modeling")
                ComboBox4.Items.Add("Computer Architecture and Parallel Processing")
                ComboBox4.Items.Add("Advanced Database Management Systems")
                ComboBox4.Items.Add("Software Project Management")
                ComboBox4.Items.Add("Information Retrieval")
            Else
                ComboBox4.Items.Add("Digital Image Processing")
                ComboBox4.Items.Add("Computational Intelligence")
                ComboBox4.Items.Add("Distributed Systems")
                ComboBox4.Items.Add("Human-Computer Interaction")
                ComboBox4.Items.Add("Computer Graphics and Multimedia")
            End If
        End If
        ShowElements()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If chosen = 1 Then
            Dim selectedStudentID As String = ComboBox3.SelectedItem.ToString()
            Dim n As String

            ' Your existing code to retrieve the student name 'n' from the database here

            appProject.DatabaseModule.OpenConnection()

            Dim query1 As String = "SELECT SName FROM Student WHERE ID = '" & selectedStudentID & "'"
            Dim reader As OleDbDataReader = DatabaseModule.GetDataReader(query1)

            If reader.Read() Then
                n = reader.GetString(0)

            End If

            reader.Close()

            Dim d As Date = DateTimePicker1.Value
            Dim b As String = ComboBox1.SelectedItem
            Dim c As String = ComboBox4.SelectedItem
            Dim s As String = If(RadioButton1.Checked, "present", "absent")

            AttendanceManager.AddAttendance(selectedStudentID, n, d, b, c, s)
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            For i As Integer = 0 To ComboBox2.Items.Count - 1
                If ComboBox2.Items(i).ToString() = "7" Then
                    ComboBox2.Items.RemoveAt(i)
                    Exit For
                End If
            Next
            For i As Integer = 0 To ComboBox2.Items.Count - 1
                If ComboBox2.Items(i).ToString() = "8" Then
                    ComboBox2.Items.RemoveAt(i)
                    Exit For
                End If
            Next
            DatabaseModule.CloseConnection()
        Else
            If CInt(TextBox2.Text) > CInt(TextBox1.Text) Then
                MessageBox.Show("Marks cannot be greater than max marks")
            Else
                Dim id As String = ComboBox3.SelectedItem.ToString()
                Dim sn As String
                Dim sy As Integer
                ' Your existing code to retrieve the student name 'n' from the database here

                appProject.DatabaseModule.OpenConnection()

                Dim query1 As String = "SELECT SName, SYear FROM Student WHERE ID = '" & id & "'"
                Dim reader As OleDbDataReader = DatabaseModule.GetDataReader(query1)

                If reader.Read() Then
                    sn = reader.GetString(0)
                    sy = reader.GetValue(1)
                End If

                reader.Close()
                Dim ex As String = ComboBox5.SelectedItem.ToString()
                Dim br As String = ComboBox1.SelectedItem.ToString()
                Dim cl As String = ComboBox4.SelectedItem.ToString()
                Dim m As Integer = TextBox2.Text

                ResultManager.AddResult(id, ex, br, cl, sn, m, sy)
                ComboBox3.Items.Clear()
                ComboBox4.Items.Clear()
                For i As Integer = 0 To ComboBox2.Items.Count - 1
                    If ComboBox2.Items(i).ToString() = "7" Then
                        ComboBox2.Items.RemoveAt(i)
                        Exit For
                    End If
                Next
                For i As Integer = 0 To ComboBox2.Items.Count - 1
                    If ComboBox2.Items(i).ToString() = "8" Then
                        ComboBox2.Items.RemoveAt(i)
                        Exit For
                    End If
                Next

                DatabaseModule.CloseConnection()
            End If
        End If
    End Sub

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

    Private Sub UploadAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadAttendanceToolStripMenuItem.Click
        chosen = 1
        HideElements()
        Label10.Show()
        Label10.Text = "UPLOAD ATTENDANCE"
        Label1.Show()
        ComboBox1.Show()
        Label4.Text = "Class"
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HideElements()
        Label10.Show()
        Label10.Text = "Faculty"
    End Sub

    Private Sub UploadResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadResultToolStripMenuItem.Click
        chosen = 2
        HideElements()
        Label10.Show()
        Label10.Text = "UPLOAD RESULT"
        Label1.Show()
        ComboBox1.Show()
        Label4.Text = "Subject"
    End Sub
End Class
