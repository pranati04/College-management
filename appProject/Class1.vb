Public Class ThemeManager
    Public Shared IsDarkMode As Boolean = False

    Public Shared Sub SetTheme(form As Form, ByVal img As Image)
        If IsDarkMode Then
            ' Dark Mode
            form.BackgroundImage = img
            ' Apply dark mode theme to other controls as needed
        Else
            ' Light Mode
            form.BackgroundImage = img
            ' Apply light mode theme to other controls as needed
        End If
    End Sub

    Public Shared Sub ToggleMode(form As Form, ByVal img As Image)
        IsDarkMode = Not IsDarkMode
        SetTheme(form, img)
    End Sub
End Class