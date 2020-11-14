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


    Private Sub PictureEng_Click(sender As Object, e As EventArgs) Handles PictureEng.Click
        help.Show()
    End Sub

    Private Sub PictureRom_Click(sender As Object, e As EventArgs) Handles PictureRom.Click
        ajutor.Show()
    End Sub
End Class