
Public Class Form1

    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim record As Integer = 0
    Dim score As Integer = 0
    Dim playerName As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FileNum As Integer

        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8

        FileNum = FreeFile()
        FileOpen(FileNum, "scor.txt", OpenMode.Input)
        playerName = LineInput(FileNum)
        record = LineInput(FileNum)
        nameLabel.Text = "Top player: " & playerName
        Record_Text.Text = "Record: " & record
        FileClose(FileNum)


    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick

        For x As Integer = 0 To 7
            road(x).Top += speed
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height

            End If

        Next
        If score > 10 And score < 20 Then
            speed = 4
        End If
        If score > 20 And score < 30 Then
            speed = 5
        End If
        If score > 30 And score < 40 Then
            speed = 6
        End If
        Speed_Text.Text = "Speed" & speed
        Viteza_text.Text = "Viteza" & speed
        Velocidad_Text.Text = "Velocidad" & speed
        If (Car.Bounds.IntersectsWith(EnemyCar1.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar2.Bounds)) Then
            gameOver()
        End If
        If (Car.Bounds.IntersectsWith(EnemyCar3.Bounds)) Then
            gameOver()
        End If
    End Sub
    Private Sub gameOver()
        Dim FileNum As Integer
        If score > record Then
            record = score
            Record_Text.Text = "Record: " & record
            playerName = InputBox("Enter name", "Enter name")
            nameLabel.Text = "Top player: " & playerName
            FileNum = FreeFile()

            FileOpen(FileNum, "scor.txt", OpenMode.Output)
            PrintLine(FileNum, playerName)
            PrintLine(FileNum, record)
            FileClose(FileNum)

        End If


        End_Text.Visible = True
        Replay_Button.Visible = True
        Restart_Button.Visible = True
        Reiniciar_Button.Visible = True
        RoadMover.Stop()
            Enemy1_Mover.Stop()
            Enemy2_Mover.Stop()
            Enemy3_Mover.Stop()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Right_Mover.Tick
    End Sub

    Private Sub Car_Click(sender As Object, e As EventArgs) Handles Car.Click

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            Right_Mover.Start()
        End If
        If e.KeyCode = Keys.Left Then
            Left_Mover.Start()

        End If
    End Sub

    Private Sub Left_Mover_Tick(sender As Object, e As EventArgs) Handles Left_Mover.Tick
        If (Car.Location.X > 0) Then
            Car.Left -= 5
        End If
    End Sub
    Private Sub Right_Mover_Tick(sender As Object, e As EventArgs) Handles Right_Mover.Tick
        If (Car.Location.X < 175) Then
            Car.Left += 5
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Right_Mover.Stop()
        Left_Mover.Stop()


    End Sub

    Private Sub Enemy1_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy1_Mover.Tick
        EnemyCar1.Top += speed / 2
        If EnemyCar1.Top >= Me.Height Then
            score += 1
            Score_Text.Text = "Score" & score
            Scor_text.Text = "Scor" & score
            Puntuacion_Text.Text = "Punctuacion" & score

            EnemyCar1.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar1.Height)
            EnemyCar1.Left = CInt(Math.Ceiling(Rnd() * 50)) + 0
        End If
    End Sub

    Private Sub Enemy2_Mover_Tick(sender As Object, e As EventArgs) Handles Enemy2_Mover.Tick
        EnemyCar2.Top += speed
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
        EnemyCar3.Top += speed * 3 / 2
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
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        Score_Text.Visible = True
        Speed_Text.Visible = True
        Record_Text.Visible = True
        Record_Text.Text = "Record: " & record
        nameLabel.Text = "Top player: " & playerName
    End Sub

    Private Sub Restart_Button_Click(sender As Object, e As EventArgs) Handles Restart_Button.Click
        score = 0
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
        score = 0
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
