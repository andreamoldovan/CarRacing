
Public Class Form1

    Dim speed As Integer        'declarare variabile
    Dim road(7) As PictureBox   'declarare  benzi drum
    Dim record As Integer = 0   'initializare record cu valoare initiala de zero
    Dim score As Integer = 0    'initializare scor cu valoare initiala zero
    Dim playerName As String = ""   'declarare variabila de tip sir ce tine numele jucatorului pentru introducere in caz de record 

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FileNum As Integer  'declarare variabila fisier tip nr integral

        speed = 3               'asignare valoare vitezei de inceput 
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8

        FileNum = FreeFile()                            'returneaza nr  disponibil   
        FileOpen(FileNum, "scor.txt", OpenMode.Input)   'deschidere fisier; asignare cale fisier si modul in care se deschide (read only)=input
        playerName = LineInput(FileNum)                 'citeste numelem jucatorului introdus pe prima linie a fisierului txt
        record = LineInput(FileNum)                     'citeste recordul utilizatorului
        nameLabel.Text = "Top player: " & playerName    'afiseaza in label textul indicat + valoarea preluata din fisierul extern
        Record_Text.Text = "Record: " & record
        FileClose(FileNum)                              'inchide fisier


    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick     'deplasare benzi 

        For x As Integer = 0 To 7                       'declarare road(x) pentru toate valorile lui x de la 0 la 7 (road)
            road(x).Top += speed
            If road(x).Top >= Me.Height Then            'cand o banda depaseste inaltimea masinii
                road(x).Top = -road(x).Height           'coboara/scade pentru a oferi continuitate

            End If

        Next
        If score > 10 And score < 20 Then               'daca scorul este intre cele doua extreme, viteza creste cate o treapta 
            speed = 4
        End If
        If score > 20 And score < 30 Then
            speed = 5
        End If
        If score > 30 And score < 40 Then
            speed = 6
        End If
        Speed_Text.Text = "Speed" & speed              'eticheta cu "scor" afiseaza alaturi de text si valoarea vitezei curente
        Viteza_text.Text = "Viteza" & speed
        Velocidad_Text.Text = "Velocidad" & speed
        If (Car.Bounds.IntersectsWith(EnemyCar1.Bounds)) Then           'daca masina se loveste cu masina 1, SFARSIT JOC
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar2.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar3.Bounds)) Then
            gameOver()
        End If
    End Sub
    Private Sub gameOver()                              'sfarsitul jocului
        Dim FileNum As Integer                          'declarare acelasi fisier tot de tip integer
        If score > record Then                          'daca scorul cumular este mai mare decar recordul curent
            record = score                              'se inlocuieste valoare recordului cu noul scor
            Record_Text.Text = "Record: " & record      'label ce indica record se inlocuieste cu noua valoare atribuita recordului 
            playerName = InputBox("Enter name", "Enter name") 'apare fereastra de tip pop-out cu mesajul "Enter name" si spatiul de completat
            nameLabel.Text = "Top player: " & playerName      'eticheta cu Top Player este reactualizata cu noua valoare preluata din fisier (playerName)   
            FileNum = FreeFile()

            FileOpen(FileNum, "scor.txt", OpenMode.Output)  'deschide fisier indicat in mod Output sterge datele existente si insereaza datele noi
            PrintLine(FileNum, playerName)                  'citeste inputul
            PrintLine(FileNum, record)
            FileClose(FileNum)                              'inchide fisierul

        End If


        End_Text.Visible = True                  'la sfarsitul jocului, labelul cu textul "Game Over" isi schimba vizibilitatea in VISIBLE, initial fiind setat la False    
        Replay_Button.Visible = True             'butoanele de reinitializare joc devin vizibile pt fiecare limba 
        Restart_Button.Visible = True
        Reiniciar_Button.Visible = True
        RoadMover.Stop()                        'drumul si masinile nu se mai misca
        Enemy1_Mover.Stop()
        Enemy2_Mover.Stop()
        Enemy3_Mover.Stop()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            Right_Mover.Start()                  'DACA se apasa tasta sageata dreapta, masina se deplaseaza la dreapta
        End If
        If e.KeyCode = Keys.Left Then            'DACA se apasa tasta sageata dreapta, masina se deplaseaza la stanga
            Left_Mover.Start()

        End If
    End Sub

    Private Sub Left_Mover_Tick(sender As Object, e As EventArgs) Handles Left_Mover.Tick
        If (Car.Location.X > 0) Then            'preluare dimensiunea maxima de deplasare a masinii din design form
            Car.Left -= 5                       'viteza de deplasare a masinii
        End If
    End Sub
    Private Sub Right_Mover_Tick(sender As Object, e As EventArgs) Handles Right_Mover.Tick
        If (Car.Location.X < 175) Then
            Car.Left += 5
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Right_Mover.Stop()                      'daca se elibereaza tastele de control , masina stationeaza
        Left_Mover.Stop()


    End Sub

    Private Sub Enemy1_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy1_Mover.Tick
        EnemyCar1.Top += speed / 2              'setare viteza de deplasare masina 3
        If EnemyCar1.Top >= Me.Height Then      'daca masina mea trece de masina inamica 
            score += 1                          'scorul creste cu o unitate
            Score_Text.Text = "Score" & score   'scorul se actualizeaza si afiseaza noua valoare in fiecare limba, dar este vizibil un singur textbox
            Scor_text.Text = "Scor" & score
            Puntuacion_Text.Text = "Punctuacion" & score

            EnemyCar1.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar1.Height)   'returneaza o valoare randomizata pentru momentul aparitia masinii
            EnemyCar1.Left = CInt(Math.Ceiling(Rnd() * 50)) + 0
        End If
    End Sub

    Private Sub Enemy2_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy2_Mover.Tick
        EnemyCar2.Top += speed          'setare viteza de deplasare masina 2
        If EnemyCar2.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score
            Scor_text.Text = "Scor" & score
            Puntuacion_Text.Text = "Punctuacion" & score

            EnemyCar2.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar2.Height)
            EnemyCar2.Left = CInt(Math.Ceiling(Rnd() * 50)) + 100
        End If
    End Sub

    Private Sub Enemy3_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy3_Mover.Tick
        EnemyCar3.Top += speed * 3 / 2    'setare viteza de deplasare masina 3
        If EnemyCar3.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score
            Scor_text.Text = "Scor" & score
            Puntuacion_Text.Text = "Punctuacion" & score
            EnemyCar3.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar3.Height)
            EnemyCar3.Left = CInt(Math.Ceiling(Rnd() * 20)) + 130
        End If
    End Sub


    Private Sub Replay_Button_Click(sender As Object, e As EventArgs) Handles Replay_Button.Click
        score = 0
        Me.Controls.Clear()             'resetare intreg jocul la starea default
        InitializeComponent()           'initializare componente
        Form1_Load(e, e)                'reincarcare form1
        Score_Text.Visible = True       'vizibilitatea label urilor corespunzatoare scorului, vitezei, recordului
        Speed_Text.Visible = True       'recordul afisat este preluat din fisier cu ultimele date completate
        Record_Text.Visible = True
        Record_Text.Text = "Record: " & record
        nameLabel.Text = "Top player: " & playerName
    End Sub

    Private Sub Restart_Button_Click(sender As Object, e As EventArgs) Handles Restart_Button.Click
        score = 0                       'similar pentru butonul de repornire in engleza cu afisarea textelor corespondente 
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        Scor_text.Visible = True
        Viteza_text.Visible = True
        Record_Text.Visible = True
        Record_Text.Text = "Record: " & record
        nameLabel.Text = "Top player: " & playerName
    End Sub

    Private Sub Reiniciar_Button_Click(sender As Object, e As EventArgs) Handles Reiniciar_Button.Click
        score = 0                       'similar pentru butonul de repornire in spaniola cu afisarea textelor corespondente 
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        Puntuacion_Text.Visible = True
        Velocidad_Text.Visible = True
        Record_Text.Visible = True
        Record_Text.Text = "Record: " & record
        nameLabel.Text = "Top player: " & playerName
    End Sub
End Class
