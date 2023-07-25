Public Class Maze
    Dim UpB, DownB, RightB, LeftB, vmoveB, hmoveB, pauseB As Boolean
    Dim UpR, DownR, RightR, LeftR, vmoveR, hmoveR, pauseR As Boolean ' Two versions of movement variables for blue and red
    Dim hspB, vspB As Integer
    Dim hspR, vspR As Integer

    Dim TwoPlayers As Boolean = True 'Determines whether there is two players(important)

    Dim speed As Integer = 4 'How many paixels are moved each interval

    Dim NewObject As Object ' New Object
    Dim CounterX, CounterY, LevelBlue, LevelRed As Integer
    Dim LevelOrder = New Integer() {1, 2, 3, 4, 5, 6, 7}
    Dim Map = New String() {"", "", "", "", "", ""}
    Dim Timetaken As Decimal 'Overall time taken

    Dim TimesB = New Decimal() {0, 0, 0, 0, 0, 0, 0} 'Needs to be as long as there are levels
    Dim TimesR = New Decimal() {0, 0, 0, 0, 0, 0, 0}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_Collision.Location = pb_Player.Location ' Making sure the collision starts ontop of the player
        pb_Close.Image = My.Resources.cancel ' Sets the close icon
        pb_Minimise.Image = My.Resources.minimise ' Sets the minimise icon

        Shuffle(LevelOrder)
        NextMapBlue() 'Loads first map up

        If TwoPlayers = False Then
            Me.Size = New Size(842, 448)
        Else
            NextMapRed()
            tmr_CollisionR.Enabled = True
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles tmr_CollisionB.Tick
        pb_Collision.Location = pb_Player.Location 'Making sure the collision box is on top of the player
        'Before collisions are checked
        If (pb_Player.Bounds.IntersectsWith(Pb_Exit.Bounds)) Then 'If it hits the exit
            TimesB(LevelBlue - 1) = Timetaken
            NextMapBlue() 'Fetch next map
        End If


        ''BLUE Player calculations
        ''VERTICAL
        'Get Vertical Input
        If (pauseB = False) Then

            If UpB Xor DownB = True Then 'Checks both arent pressed at same time
                If (UpB = True) Then
                    vspB = -speed
                Else 'If not upc must be downc
                    vspB = speed
                End If 'Sets vsp according to the buttons pressed

                'Vertical Collision
                pb_Collision.Top += vspB ' Adds the vertical speed
                vmoveB = False ' Resets the vmove variable to false
                For Each item As Panel In Me.Controls.OfType(Of Panel) 'Checks each panel
                    If Not item.Name = "pnl_WallR" Then
                        If (item.Bounds.IntersectsWith(pb_Collision.Bounds) = True) Then
                            pb_Collision.Location = pb_Player.Location
                            pb_Collision.Top += Math.Sign(vspB) 'Math.Sign used to get -1,1 pixels
                            Do While item.Bounds.IntersectsWith(pb_Collision.Bounds) = False 'Moves up to walls
                                pb_Player.Top += Math.Sign(vspB)                              'To stop white gaps
                                pb_Collision.Top += Math.Sign(vspB) 'Checks next pixel
                            Loop
                            pb_Collision.Location = pb_Player.Location 'Resets collision locations
                            vmoveB = False 'Dont move the player 
                            Exit For
                        Else
                            vmoveB = True ' Have to use variable so speed isnt applied multiple times
                        End If
                    End If
                Next
                If (vmoveB = True) Then 'Applys the speed if there is no collision
                    pb_Player.Top += vspB
                End If
                Me.Refresh()

            Else
                vspB = 0
            End If

            ''HORIZONTAL
            ' Get Horizontal Input
            If RightB Xor LeftB = True Then
                If (RightB = True) Then
                    hspB = speed
                Else
                    hspB = -speed
                End If
                'Horizontal Collision (Same as vertical with few things switched)
                pb_Collision.Left += hspB
                hmoveB = False
                For Each item2 As Panel In Me.Controls.OfType(Of Panel) ' For Each Panel
                    If Not item2.Name = "pnl_WallR" Then
                        If (item2.Bounds.IntersectsWith(pb_Collision.Bounds) = True) Then ' Check if it hits the collision box
                            pb_Collision.Location = pb_Player.Location
                            pb_Collision.Left += Math.Sign(hspB)
                            Do While item2.Bounds.IntersectsWith(pb_Collision.Bounds) = False 'Moves up to walls
                                pb_Player.Left += Math.Sign(hspB)                              'To stop white gaps
                                pb_Collision.Left += Math.Sign(hspB)
                            Loop
                            pb_Collision.Location = pb_Player.Location
                            hmoveB = False ' dont move
                            Exit For
                        Else
                            hmoveB = True ' move
                        End If
                    End If
                Next
                If (hmoveB = True) Then
                    pb_Player.Left += hspB ' Apply horizontal Speed
                End If
                Me.Refresh()
            Else
                hspB = 0
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmr_CollisionR.Tick
        ''RED Player calculations
        pb_Collision2.Location = pb_Player2.Location
        If (pb_Player2.Bounds.IntersectsWith(Pb_Exit2.Bounds)) Then 'If it hits the exit
            TimesR(LevelRed - 1) = Timetaken
            NextMapRed() 'Fetch next map
        End If
        ''VERTICAL
        'Get Vertical Input
        If UpR Xor DownR = True Then 'Checks both arent pressed at same time
            If (UpR = True) Then
                vspR = -speed
            Else 'If not upc must be downc
                vspR = speed
            End If 'Sets vsp according to the buttons pressed

            'Vertical Collision
            pb_Collision2.Top += vspR ' Adds the vertical speed
            vmoveR = False ' Resets the vmove variable to false
            For Each item3 As Panel In Me.Controls.OfType(Of Panel) 'Checks each panel
                If Not item3.Name = "pnl_WallB" Then
                    If (item3.Bounds.IntersectsWith(pb_Collision2.Bounds) = True) Then
                        pb_Collision2.Location = pb_Player2.Location
                        pb_Collision2.Top += Math.Sign(vspR) 'Math.Sign used to get -1,1 pixels
                        Do While item3.Bounds.IntersectsWith(pb_Collision2.Bounds) = False 'Moves up to walls
                            pb_Player2.Top += Math.Sign(vspR)                              'To stop white gaps
                            pb_Collision2.Top += Math.Sign(vspR) 'Checks next pixel
                        Loop
                        pb_Collision2.Location = pb_Player2.Location 'Resets collision locations
                        vmoveR = False 'Dont move the player 
                        Exit For
                    Else
                        vmoveR = True ' Have to use variable so speed isnt applied multiple times
                    End If
                End If
            Next
            If (vmoveR = True) And (pauseR = False) Then 'Applys the speed if there is no collision
                pb_Player2.Top += vspR
            End If
            Me.Refresh()
        Else
            vspR = 0
        End If

        ''HORIZONTAL
        ' Get Horizontal Input
        If RightR Xor LeftR = True Then
            If (RightR = True) Then
                hspR = speed
            Else
                hspR = -speed
            End If
            'Horizontal Collision (Same as vertical with few things switched)
            pb_Collision2.Left += hspR
            hmoveR = False
            For Each item4 As Panel In Me.Controls.OfType(Of Panel) ' For Each Panel
                If Not item4.Name = "pnl_WallB" Then
                    If (item4.Bounds.IntersectsWith(pb_Collision2.Bounds) = True) Then ' Check if it hits the collision box
                        pb_Collision2.Location = pb_Player2.Location
                        pb_Collision2.Left += Math.Sign(hspR)
                        Do While item4.Bounds.IntersectsWith(pb_Collision2.Bounds) = False 'Moves up to walls
                            pb_Player2.Left += Math.Sign(hspR)                              'To stop white gaps
                            pb_Collision2.Left += Math.Sign(hspR)
                        Loop
                        pb_Collision2.Location = pb_Player2.Location
                        hmoveR = False ' dont move
                        Exit For
                    Else
                        hmoveR = True ' move
                    End If
                End If
            Next
            If (hmoveR = True) And (pauseR = False) Then
                pb_Player2.Left += hspR ' Apply horizontal Speed
            End If
            Me.Refresh()
        Else
            hspR = 0
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode ' Booleans to be used in timer with higher refresh rate
            Case Keys.W 'If W Key is Pressed Down
                UpB = True
            Case Keys.S 'If S Key is Pressed Down
                DownB = True
            Case Keys.A 'If A Key is Pressed Down
                LeftB = True
            Case Keys.D 'If D Key is Pressed Down
                RightB = True
        End Select
        If TwoPlayers = True Then
            Select Case e.KeyCode
                Case Keys.Up ' When W is let go, set it back to false
                    UpR = True
                Case Keys.Down ' When S is let go, set it back to false
                    DownR = True
                Case Keys.Left ' When A is let go, set it back to false
                    LeftR = True
                Case Keys.Right ' When D is let go, set it back to false
                    RightR = True
            End Select
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.W ' When W is let go, set it back to false
                UpB = False
            Case Keys.S ' When S is let go, set it back to false
                DownB = False
            Case Keys.A ' When A is let go, set it back to false
                LeftB = False
            Case Keys.D ' When D is let go, set it back to false
                RightB = False
        End Select

        If TwoPlayers = True Then
            Select Case e.KeyCode
                Case Keys.Up ' When W is let go, set it back to false
                    UpR = False
                Case Keys.Down ' When S is let go, set it back to false
                    DownR = False
                Case Keys.Left ' When A is let go, set it back to false
                    LeftR = False
                Case Keys.Right ' When D is let go, set it back to false
                    RightR = False
            End Select
        End If
    End Sub

    Sub LoadMap(ByVal Map As String(), ByVal Level As Integer, ByVal IsBlue As Boolean)
        Select Case LevelOrder(Level - 1) 'Levels (3D Arrays, Array of Strings)
            Case 1 ' Level 1 
                Map(0) = "P_W_W___W___" ' F means finish
                Map(1) = "__W_W_W_WWW_" ' _ means empty
                Map(2) = "_WW___W_W___" ' W means Wall
                Map(3) = "____W_W___W_"
                Map(4) = "W_WWW___W_W_"
                Map(5) = "____WWWWW_WF"

            Case 2 ' Level 2
                Map(0) = "P_WW________"
                Map(1) = "___W_WW_WWW_"
                Map(2) = "_W________W_"
                Map(3) = "_WWWWWWWWWW_"
                Map(4) = "__W___W___W_"
                Map(5) = "W___W___W__F"
            Case 3 ' Level 3
                Map(0) = "__W___W_____"
                Map(1) = "W_WPW___WWW_"
                Map(2) = "W_WWW_W_W___"
                Map(3) = "__W_______W_"
                Map(4) = "_WW_W_WWWWW_"
                Map(5) = "____W____WF_"
            Case 4 ' Level 4
                Map(0) = "__W___W___W_"
                Map(1) = "_WW_W_W_W___"
                Map(2) = "____W_W_WWW_"
                Map(3) = "W_WWW_____W_"
                Map(4) = "___WWW_WW_W_"
                Map(5) = "PW________WF"
            Case 5 ' Level 5
                Map(0) = "F__W______W_"
                Map(1) = "_W_W_WWWW_W_"
                Map(2) = "WW___W__W___"
                Map(3) = "_WWWWWW_WWW_"
                Map(4) = "__W___W___WP"
                Map(5) = "W___W___W___"
            Case 6 ' Level 6
                Map(0) = "PW__________"
                Map(1) = "_W_W_WWW_WWW"
                Map(2) = "_W_W_W_W____"
                Map(3) = "___W___WWWW_"
                Map(4) = "WWWWWWWW____"
                Map(5) = "F________WW_"
            Case 7 'Level 7
                Map(0) = "PW_____W____"
                Map(1) = "___WWW___WWW"
                Map(2) = "_WWW_WWWWW__"
                Map(3) = "_W_________W"
                Map(4) = "_WWW_WWWWW_W"
                Map(5) = "_____W_____F"
        End Select

        'Drawing the Map
        CounterY = 0 'Resets counter
        Do While CounterY < Map.Length 'Every vertical value
            CounterX = 0 'Resets counter
            Do While CounterX < Map(0).Length 'Every horizontal value
                Select Case Map(CounterY).Substring(CounterX, 1) 'What letter is in that spot
                    Case "W" 'Wall
                        NewObject = New Panel 'Creating new object
                        NewObject.Width = 64
                        NewObject.Height = 64
                        NewObject.Left = (NewObject.Width * CounterX) + 32
                        If IsBlue = True Then
                            NewObject.Top = (NewObject.Height * CounterY) + 32
                            NewObject.Name = "pnl_WallB"
                        Else
                            NewObject.Top = 896 - (NewObject.Height * CounterY) - 96
                            NewObject.Name = "pnl_WallR"
                        End If
                        NewObject.BackColor = Color.Gray
                        Controls.Add(NewObject)
                    Case "F" 'Finish 
                        If IsBlue = False Then
                            Pb_Exit2.Left = (64 * CounterX) + 48
                            Pb_Exit2.Top = 896 - (64 * CounterY) - 80
                        Else
                            Pb_Exit.Left = (64 * CounterX) + 48
                            Pb_Exit.Top = (64 * CounterY) + 48
                        End If 'Moves the location of the exit instead of creating new one
                    Case "P" ' Player 
                        If IsBlue = False Then
                            pb_Collision2.Left = (64 * CounterX) + 48
                            pb_Collision2.Top = 896 - (64 * CounterY) - 80
                            pb_Player2.Left = (64 * CounterX) + 48
                            pb_Player2.Top = 896 - (64 * CounterY) - 80
                        Else
                            pb_Collision.Left = (64 * CounterX) + 48
                            pb_Collision.Top = (64 * CounterY) + 48
                            pb_Player.Left = (64 * CounterX) + 48
                            pb_Player.Top = (64 * CounterY) + 48
                        End If

                End Select
                CounterX += 1
            Loop
            CounterY += 1
        Loop
        If IsBlue = True Then
            pauseB = False
        Else
            pauseR = False
        End If
    End Sub
    Sub NextMapBlue()
        'Loading next level
        For I As Integer = Me.Controls.OfType(Of Panel).Count + 8 To 1 Step -1 ' Changes the + number to how many extra controls have been added
            Dim Ctl As Control ' Cant go up in iterations as the list is changing size
            Ctl = Controls.Item(I)
            If TypeOf Ctl Is Panel And Ctl.Name = "pnl_WallB" Then 'Only delete walls/ Panels on blues side
                Controls.Remove(Ctl)
                Ctl.Dispose()
            End If
        Next
        'Recording time taken for each level
        If LevelBlue < TimesB.Length Then 'Stops errors/crashes
            LevelBlue += 1
            pauseB = True
            LoadMap(Map, LevelBlue, True)
        End If

    End Sub

    Sub NextMapRed()
        'Loading next level
        For I As Integer = Me.Controls.OfType(Of Panel).Count + 8 To 1 Step -1 ' Changes the + number to how many extra controls have been added
            Dim Ctl As Control ' Cant go up in iterations as the list is changing size
            Ctl = Controls.Item(I)
            If TypeOf Ctl Is Panel And Ctl.Name = "pnl_WallR" Then 'Only delete walls/ Panels on reds side
                Controls.Remove(Ctl)
                Ctl.Dispose()
            End If
        Next
        'Recording time taken for each level
        'Stops errors/crashes
        If LevelRed < TimesR.Length Then
            LevelRed += 1
            pauseR = True
            LoadMap(Map, LevelRed, False)
        End If

    End Sub

    Private Sub tmr_Timer_Tick(sender As Object, e As EventArgs) Handles tmr_Timer.Tick
        Timetaken += 0.1 'Adds 0.1 seconds for every 100 milliseconds
        lbl_Timer.Text = Timetaken 'Updates the label
    End Sub

    Public Sub Shuffle(ByRef data() As Integer)
        Randomize()
        Dim x, swap As Integer
        Dim r As Random = New Random()

        For i As Integer = 0 To data.GetUpperBound(0)
            x = r.Next(0, i)
            swap = data(x)
            data(x) = data(i)
            data(i) = swap
        Next i

    End Sub

    Private Sub pb_Close_Click(sender As Object, e As EventArgs) Handles pb_Close.Click
        Me.Close()
        Welcome.Close()
    End Sub

    Private Sub pb_Minimise_Click(sender As Object, e As EventArgs) Handles pb_Minimise.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
