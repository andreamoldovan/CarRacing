Public Class Startup

    Private Sub Incepe_Click(sender As Object, e As EventArgs) Handles Incepe.Click    'la click pe buton incepe
        Form1.Show()                                                                   'se incarca Form1 (Jocul)
        Form1.Scor_text.Show()                                                         'text Scor in lb romana
        Form1.Viteza_text.Show()                                                       'text viteza in lb romana

    End Sub

    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click   'la click pe buton start
        Form1.Show()                                                                'se incarca Form1 (Jocul)
        Form1.Score_Text.Show()                                                     'text score in lb eng
        Form1.Speed_Text.Show()                                                     'text speed in lb eng
    End Sub

    Private Sub Incipio_Click(sender As Object, e As EventArgs) Handles Incipio.Click
        Form1.Show()
        Form1.Puntuacion_Text.Show()
        Form1.Velocidad_Text.Show()
    End Sub

    Private Sub PictureEng_Click(sender As Object, e As EventArgs) Handles PictureEng.Click
        help.Show()             'la click pe pictograma aflata sub steag Anglia, apare help-ul in engleza 
    End Sub

    Private Sub PictureRom_Click(sender As Object, e As EventArgs) Handles PictureRom.Click
        ajutor.Show()           'la click pe pictograma aflata sub steag Romania, apare help-ul in romana
    End Sub

    Private Sub PictureEsp_Click(sender As Object, e As EventArgs) Handles PictureEsp.Click
        Ayuda.Show()            'la click pe picrograma aflata sub steag Spania, apare help-ul in spaniola
    End Sub

    Private Sub gantt_Click(sender As Object, e As EventArgs) Handles gantt.Click               'click picturebox gantt
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\Gantt.pdf"    'declarare fisier pdf(cale) ca sir

        If System.IO.File.Exists(FILE_NAME) = True Then             'Determină dacă fișierul specificat există
            Process.Start(FILE_NAME)                                'afisare
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)     'eroare si Warning ca fisierul nu exista
        End If
    End Sub

    Private Sub team_Click(sender As Object, e As EventArgs) Handles team.Click     'click pe pictograma echipa
        Form2.Show()                                                                'afisare form2 cu echipa
    End Sub


    Private Sub requirements_Click(sender As Object, e As EventArgs) Handles requirements.Click         'click pe pictograma 
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\Requirements.pdf"     'declarare  fisier pdf(cale)ca sir

        If System.IO.File.Exists(FILE_NAME) = True Then             'Determină dacă fișierul specificat există
            Process.Start(FILE_NAME)                                'afisare daca exista
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)     'eroare si Warning ca fisierul nu exista
        End If
    End Sub

    Private Sub bugrep_Click(sender As Object, e As EventArgs) Handles bugrep.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\ErrorBug.xlsx"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub testcase_Click(sender As Object, e As EventArgs) Handles testcase.Click
        Dim FILE_NAME As String = "C:\Users\User\source\repos\CarRacing\bin\Debug\TestCase.pdf"

        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("File Does Not Exist", MsgBoxStyle.Critical)
        End If
    End Sub
End Class