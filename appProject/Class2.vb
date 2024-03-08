Public Class Change
    Public Shared DarkMode As Boolean = False

    Public Shared Sub SetT(form As Form)
        If DarkMode Then
            ' Dark Mode
            form.BackColor = Color.FromArgb(31, 31, 31)
            form.ForeColor = Color.White
            ' Apply dark mode theme to other controls as needed
        Else
            ' Light Mode
            form.BackColor = SystemColors.Control
            form.ForeColor = SystemColors.ControlText
            ' Apply light mode theme to other controls as needed
        End If
    End Sub

    Public Shared Sub Toggle(form As Form)
        DarkMode = Not DarkMode
        SetT(form)
    End Sub
End Class
