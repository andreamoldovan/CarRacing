Public Class Startup

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Form1.Scor_text.Show()
        Form1.Viteza_text.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Form1.Score_Text.Show()
        Form1.Speed_Text.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Form1.Puntuacion_Text.Show()
        Form1.Velocidad_Text.Show()
    End Sub

    Private Sub PictureEng_Click(sender As Object, e As EventArgs) Handles PictureEng.Click
        help.Show()
    End Sub

    Private Sub PictureRom_Click(sender As Object, e As EventArgs) Handles PictureRom.Click
        ajutor.Show()
    End Sub

    Private Sub PictureEsp_Click(sender As Object, e As EventArgs) Handles PictureEsp.Click
        Ayuda.Show()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\Gantt.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\TestCase.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\Requirements.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\ErrorBug.xlsx"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub
End Class