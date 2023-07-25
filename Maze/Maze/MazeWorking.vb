
Public Class Maze

    Dim UpG, DownG, RightG, LeftG, vmoveG, hmoveG, pauseG As Boolean
    Dim UpB, DownB, RightB, LeftB, vmoveB, hmoveB, pauseB As Boolean ' Two versions of movement variables for blue and red
    Dim hspG, vspG As Integer
    Dim hspB, vspB As Integer

    Dim AnimationCounterG, AnimationCounterB As Integer
    Dim SlimeTallG, SlimeTallB As Boolean
    Dim LookingLeftG, LookingLeftB As Boolean

    Dim Mode As String = "AI" 'Determines whether there is two players(important)
    Dim Path As String = ""
    Dim PathCounter As Integer
    Dim PathFinished As Boolean
    Dim AISpeed As Integer = 450 'Lower the number, faster the speed


    Dim speed As Integer = 2 'How many pixels are moved each interval

    Dim NewObject As Object ' New Object
    Dim CounterX, CounterY, LevelGreen, LevelBlue As Integer
    Dim LevelOrder = New Integer() {1, 2, 3, 4, 5, 6, 7} ' Is randomised later on
    Dim Map = New String() {"", "", "", "", "", ""}
    Dim Timetaken As Decimal 'Overall time taken

    Dim TimesG = New Decimal() {0, 0, 0, 0, 0, 0, 0} 'Needs to be as long as there are levels
    Dim TimesB = New Decimal() {0, 0, 0, 0, 0, 0, 0}


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_Collision.Location = pb_Player.Location ' Making sure the collision starts ontop of the player
        pb_Close.Image = My.Resources._exit ' Sets the close icon
        pb_Minimise.Image = My.Resources.minimise ' Sets the minimise icon
        pb_Player.Image = My.Resources.slimesquishr
        pb_Player2.Image = My.Resources.slimebluesquishr

        tmr_AIMove.Interval = AISpeed
        Shuffle(LevelOrder)
        NextMapGreen() 'Loads first map up
        If Mode = "One Player" Then
            Me.Size = New Size(842, 448)
        Else
            NextMapBlue()
            tmr_CollisionR.Enabled = True
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles tmr_CollisionB.Tick
        pb_Collision.Location = pb_Player.Location 'Making sure the collision box is on top of the player
        'Before collisions are checked
        If (pb_Player.Bounds.IntersectsWith(Pb_Exit.Bounds)) Then 'If it hits the exit
            TimesG(LevelGreen - 1) = Timetaken
            NextMapGreen() 'Fetch next map
        End If

        hspG = 0
        vspG = 0

        ''Green Player calculations
        ''VERTICAL
        'Get Vertical Input
        If (pauseG = False) Then

            If UpG Xor DownG = True Then 'Checks both arent pressed at same time
                If (UpG = True) Then
                    vspG = -speed
                Else 'If not upc must be downc
                    vspG = speed
                End If 'Sets vsp according to the buttons pressed

                'Vertical Collision
                pb_Collision.Top += vspG ' Adds the vertical speed
                vmoveG = False ' Resets the vmove variable to false
                For Each item As Panel In Me.Controls.OfType(Of Panel) 'Checks each panel
                    If Not item.Name = "pnl_WallR" Then
                        If (item.Bounds.IntersectsWith(pb_Collision.Bounds) = True) Then
                            pb_Collision.Location = pb_Player.Location
                            pb_Collision.Top += Math.Sign(vspG) 'Math.Sign used to get -1,1 pixels
                            Do While item.Bounds.IntersectsWith(pb_Collision.Bounds) = False 'Moves up to walls
                                pb_Player.Top += Math.Sign(vspG)                              'To stop white gaps
                                pb_Collision.Top += Math.Sign(vspG) 'Checks next pixel
                            Loop
                            pb_Collision.Location = pb_Player.Location 'Resets collision locations
                            vmoveG = False 'Dont move the player 
                            Exit For
                        Else
                            vmoveG = True ' Have to use variable so speed isnt applied multiple times
                        End If
                    End If
                Next
                If (vmoveG = True) Then 'Applys the speed if there is no collision
                    pb_Player.Top += vspG
                End If

            Else
                vspG = 0
            End If

            ''HORIZONTAL
            ' Get Horizontal Input
            If RightG Xor LeftG = True Then
                If (RightG = True) Then
                    hspG = speed
                    LookingLeftG = False
                Else
                    hspG = -speed
                    LookingLeftG = True
                End If
                'Horizontal Collision (Same as vertical with few things switched)
                pb_Collision.Left += hspG
                hmoveG = False
                For Each item2 As Panel In Me.Controls.OfType(Of Panel) ' For Each Panel
                    If Not item2.Name = "pnl_WallR" Then
                        If (item2.Bounds.IntersectsWith(pb_Collision.Bounds) = True) Then ' Check if it hits the collision box
                            pb_Collision.Location = pb_Player.Location
                            pb_Collision.Left += Math.Sign(hspG)
                            Do While item2.Bounds.IntersectsWith(pb_Collision.Bounds) = False 'Moves up to walls
                                pb_Player.Left += Math.Sign(hspG)                              'To stop white gaps
                                pb_Collision.Left += Math.Sign(hspG)
                            Loop
                            pb_Collision.Location = pb_Player.Location
                            hmoveG = False ' dont move
                            Exit For
                        Else
                            hmoveG = True ' move
                        End If
                    End If
                Next
                If (hmoveG = True) Then
                    pb_Player.Left += hspG ' Apply horizontal Speed

                End If
            End If
        Else
            hspG = 0
        End If

        If AnimationCounterG < 20 Then
            AnimationCounterG += 1
        Else
            If Not ((hspG = 0) And (vspG = 0)) Then
                If LookingLeftG Then

                    If SlimeTallG = True Then
                        pb_Player.Image = My.Resources.slimesquishl
                        SlimeTallG = False
                    Else
                        pb_Player.Image = My.Resources.slimetalll
                        SlimeTallG = True
                    End If
                Else
                    If SlimeTallG = True Then
                        pb_Player.Image = My.Resources.slimesquishr
                        SlimeTallG = False
                    Else
                        pb_Player.Image = My.Resources.slimetallr
                        SlimeTallG = True
                    End If
                End If
            End If
            AnimationCounterG = 0
        End If

        Me.Update()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmr_CollisionR.Tick
        ''Blue Player calculations
        pb_Collision2.Location = pb_Player2.Location
        If (pb_Player2.Bounds.IntersectsWith(Pb_Exit2.Bounds)) Then 'If it hits the exit
            TimesB(LevelBlue - 1) = Timetaken
            'If Mode = "AI" And PathFinished = True Then
            '    NextMapRed() 'Fetch next map
            'ElseIf Not Mode = "AI" Then
            NextMapBlue()
            'End If
        End If

        hspB = 0
        vspB = 0
        ''VERTICAL
        'Get Vertical Input
        If UpB Xor DownB = True Then 'Checks both arent pressed at same time
            If (UpB = True) Then
                vspB = -speed
            Else 'If not upc must be downc
                vspB = speed
            End If 'Sets vsp according to the buttons pressed

            'Vertical Collision
            pb_Collision2.Top += vspB ' Adds the vertical speed
            vmoveB = False ' Resets the vmove variable to false
            For Each item3 As Panel In Me.Controls.OfType(Of Panel) 'Checks each panel
                If Not item3.Name = "pnl_WallB" Then
                    If (item3.Bounds.IntersectsWith(pb_Collision2.Bounds) = True) Then
                        pb_Collision2.Location = pb_Player2.Location
                        pb_Collision2.Top += Math.Sign(vspB) 'Math.Sign used to get -1,1 pixels
                        Do While item3.Bounds.IntersectsWith(pb_Collision2.Bounds) = False 'Moves up to walls
                            pb_Player2.Top += Math.Sign(vspB)                              'To stop white gaps
                            pb_Collision2.Top += Math.Sign(vspB) 'Checks next pixel
                        Loop
                        pb_Collision2.Location = pb_Player2.Location 'Resets collision locations
                        vmoveB = False 'Dont move the player 
                        Exit For
                    Else
                        vmoveB = True ' Have to use variable so speed isnt applied multiple times
                    End If
                End If
            Next
            If (vmoveB = True) And (pauseB = False) Then 'Applys the speed if there is no collision
                pb_Player2.Top += vspB
            End If
        Else
            vspB = 0
        End If

        ''HORIZONTAL
        ' Get Horizontal Input
        If RightB Xor LeftB = True Then
            If (RightB = True) Then
                hspB = speed
                LookingLeftB = False
            Else
                hspB = -speed
                LookingLeftB = True
            End If
            'Horizontal Collision (Same as vertical with few things switched)
            pb_Collision2.Left += hspB
            hmoveB = False
            For Each item4 As Panel In Me.Controls.OfType(Of Panel) ' For Each Panel
                If Not item4.Name = "pnl_WallB" Then
                    If (item4.Bounds.IntersectsWith(pb_Collision2.Bounds) = True) Then ' Check if it hits the collision box
                        pb_Collision2.Location = pb_Player2.Location
                        pb_Collision2.Left += Math.Sign(hspB)
                        Do While item4.Bounds.IntersectsWith(pb_Collision2.Bounds) = False 'Moves up to walls
                            pb_Player2.Left += Math.Sign(hspB)                              'To stop white gaps
                            pb_Collision2.Left += Math.Sign(hspB)
                        Loop
                        pb_Collision2.Location = pb_Player2.Location
                        hmoveB = False ' dont move
                        Exit For
                    Else
                        hmoveB = True ' move
                    End If
                End If
            Next
            If (hmoveB = True) And (pauseB = False) Then
                pb_Player2.Left += hspB ' Apply horizontal Speed

            End If
        Else
            hspB = 0
        End If


        If Mode = "Two Player" Then

            If AnimationCounterB < 20 Then
                AnimationCounterB += 1
            Else
                If Not ((hspB = 0) And (vspB = 0)) Then
                    If LookingLeftB Then

                        If SlimeTallB = True Then
                            pb_Player2.Image = My.Resources.slimebluesmall
                            SlimeTallB = False
                        Else
                            pb_Player2.Image = My.Resources.slimebluetalll
                            SlimeTallB = True
                        End If
                    Else
                        If SlimeTallB = True Then
                            pb_Player2.Image = My.Resources.slimebluesquishr
                            SlimeTallB = False
                        Else
                            pb_Player2.Image = My.Resources.slimebluetallr
                            SlimeTallB = True
                        End If
                    End If
                End If
                AnimationCounterB = 0
            End If
        ElseIf Mode = "AI" Then
            pb_Player2.Image = My.Resources.Robot
        End If

        Me.Update()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode ' Booleans to be used in timer with higher refresh rate
            Case Keys.W 'If W Key is Pressed Down
                UpG = True
            Case Keys.S 'If S Key is Pressed Down
                DownG = True
            Case Keys.A 'If A Key is Pressed Down
                LeftG = True
            Case Keys.D 'If D Key is Pressed Down
                RightG = True
        End Select
        If Mode = "Two Player" Then
            Select Case e.KeyCode
                Case Keys.Up ' When W is let go, set it back to false
                    UpB = True
                Case Keys.Down ' When S is let go, set it back to false
                    DownB = True
                Case Keys.Left ' When A is let go, set it back to false
                    LeftB = True
                Case Keys.Right ' When D is let go, set it back to false
                    RightB = True
            End Select
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.W ' When W is let go, set it back to false
                UpG = False
            Case Keys.S ' When S is let go, set it back to false
                DownG = False
            Case Keys.A ' When A is let go, set it back to false
                LeftG = False
            Case Keys.D ' When D is let go, set it back to false
                RightG = False
        End Select

        If Mode = "Two Player" Then
            Select Case e.KeyCode
                Case Keys.Up ' When W is let go, set it back to false
                    UpB = False
                Case Keys.Down ' When S is let go, set it back to false
                    DownB = False
                Case Keys.Left ' When A is let go, set it back to false
                    LeftB = False
                Case Keys.Right ' When D is let go, set it back to false
                    RightB = False
            End Select
        End If
    End Sub

    Sub LoadMap(ByVal Map As String(), ByVal Level As Integer, ByVal IsGreen As Boolean)
        Select Case LevelOrder(Level - 1) 'Levels (3D Arrays, Array of Strings)
            Case 1 ' Level 1 
                Map(0) = "PWW_W___W___" ' F means finish
                Map(1) = "__W_W_W_WWW_" ' _ means empty
                Map(2) = "_WW___W_W___" ' W means Wall
                Map(3) = "____W_W___W_"
                Map(4) = "W_WWW___W_W_"
                Map(5) = "____WWWWW_WF"

            Case 2 ' Level 2
                Map(0) = "PWWW________"
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
                        If IsGreen = True Then
                            NewObject.Top = (NewObject.Height * CounterY) + 32
                            NewObject.Name = "pnl_WallB"
                        Else
                            NewObject.Top = 896 - (NewObject.Height * CounterY) - 96
                            NewObject.Name = "pnl_WallR"
                            If Mode = "AI" Then
                                CellMap(CounterX, CounterY).Wall = True
                            End If
                        End If
                        NewObject.BackgroundImage = My.Resources.BrickWall
                        'NewObject.BackColor = Color.Gray
                        Controls.Add(NewObject)
                    Case "F" 'Finish 
                        If IsGreen = False Then
                            Pb_Exit2.Left = (64 * CounterX) + 40
                            Pb_Exit2.Top = 896 - (64 * CounterY) - 88
                            If Mode = "AI" Then
                                CellMap(CounterX, CounterY).Wall = False
                                EndX = CounterX
                                EndY = CounterY
                            End If
                        Else
                            Pb_Exit.Left = (64 * CounterX) + 40
                            Pb_Exit.Top = (64 * CounterY) + 40
                        End If 'Moves the location of the exit instead of creating new one
                    Case "P" ' Player start 
                        If IsGreen = False Then
                            pb_Collision2.Left = (64 * CounterX) + 48
                            pb_Collision2.Top = 896 - (64 * CounterY) - 80
                            pb_Player2.Left = (64 * CounterX) + 48
                            pb_Player2.Top = 896 - (64 * CounterY) - 80
                            If Mode = "AI" Then
                                CellMap(CounterX, CounterY).Wall = False
                                StartX = CounterX
                                StartY = CounterY
                            End If
                        Else
                            pb_Collision.Left = (64 * CounterX) + 48
                            pb_Collision.Top = (64 * CounterY) + 48
                            pb_Player.Left = (64 * CounterX) + 48
                            pb_Player.Top = (64 * CounterY) + 48

                        End If
                    Case Else
                        If Mode = "AI" Then
                            CellMap(CounterX, CounterY).Wall = False
                        End If
                End Select
                CounterX += 1
            Loop
            CounterY += 1
        Loop
        If IsGreen = True Then
            pauseG = False
        Else
            pauseB = False
        End If

        If Mode = "AI" And IsGreen = False Then
            Path = ""
            PathCounter = 0
            FindPath()
            Debug.WriteLine(LevelBlue)
        End If
    End Sub

    Private Sub tmr_AIMove_Tick(sender As Object, e As EventArgs) Handles tmr_AIMove.Tick
        If PathCounter < Path.Length And Mode = "AI" Then
            Select Case Path(PathCounter)
                Case "U"
                    pb_Player2.Top -= 64
                Case "D"
                    pb_Player2.Top += 64
                Case "L"
                    pb_Player2.Left -= 64
                Case "R"
                    pb_Player2.Left += 64
            End Select

            PathCounter += 1
        End If
    End Sub


    Sub NextMapGreen()
        'Loading next level
        For I As Integer = Me.Controls.OfType(Of Panel).Count + 7 To 1 Step -1 ' Changes the + number to how many extra controls have been added
            Dim Ctl As Control ' Cant go up in iterations as the list is changing size
            Ctl = Controls.Item(I)
            If TypeOf Ctl Is Panel And Ctl.Name = "pnl_WallB" Then 'Only delete walls/ Panels on blues side
                Controls.Remove(Ctl)
                Ctl.Dispose()
            End If
        Next
        'Recording time taken for each level
        If LevelGreen < TimesG.Length Then 'Stops errors/crashes
            LevelGreen += 1
            pauseG = True
            LoadMap(Map, LevelGreen, True)
        End If

    End Sub

    Sub NextMapBlue()
        'Loading next level
        For I As Integer = Me.Controls.OfType(Of Panel).Count + 7 To 1 Step -1 ' Changes the + number to how many extra controls have been added
            Dim Ctl As Control ' Cant go up in iterations as the list is changing size
            Ctl = Controls.Item(I)
            If TypeOf Ctl Is Panel And Ctl.Name = "pnl_WallR" Then 'Only delete walls/ Panels on reds side
                Controls.Remove(Ctl)
                Ctl.Dispose()
            End If
        Next
        'Recording time taken for each level
        'Stops errors/crashes
        If LevelBlue < TimesB.Length Then
            LevelBlue += 1
            pauseB = True
            LoadMap(Map, LevelBlue, False)
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


    Private Const inOpened As Integer = 1
    Private Const inClosed As Integer = 2
    Private Heap As New BinaryHeap()
    Public Class BinaryHeap

#Region " Declares "
        Private lSize As Int16 'Size of the heap array
        Private Heap() As BinHeapData 'Heap Array
#End Region
        Public Structure BinHeapData
            'Data Structure to hold FScore and Location
            Friend Score As Int16
            Friend X As Int16
            Friend Y As Int16
        End Structure
#Region " Properties "

        'Return heap count
        Public ReadOnly Property Count() As Int16
            Get
                Return lSize
            End Get
        End Property

        'Return X position
        Public ReadOnly Property GetX() As Int16
            Get
                Return Heap(1).X
            End Get
        End Property

        'Return Y position
        Public ReadOnly Property GetY() As Int16
            Get
                Return Heap(1).Y
            End Get
        End Property

        'Return the lowest score
        Public ReadOnly Property GetScore() As Int16
            Get
                Return Heap(1).Score
            End Get
        End Property

#End Region

#Region " Subs "

        'Reset the heap
        Public Sub ResetHeap()
            lSize = 0
            ReDim Heap(0)
        End Sub

        'Remove the Root Object from the heap
        Public Sub RemoveRoot()

            'If only the root exists
            If lSize <= 1 Then
                lSize = 0
                ReDim Heap(0)
                Exit Sub
            End If

            'First copy the very bottom object to the top
            Heap(1) = Heap(lSize)

            'Resize the count
            lSize -= 1

            'Shrink the array
            ReDim Preserve Heap(lSize)

            'Sort the top item to it's correct position
            Dim Parent As Int16 = 1
            Dim ChildIndex As Int16 = 1

            'Sink the item to it's correct location
            While True
                ChildIndex = Parent
                If 2 * ChildIndex + 1 <= lSize Then
                    'Find the lowest value of the 2 child nodes
                    If Heap(ChildIndex).Score >= Heap(2 * ChildIndex).Score Then Parent = 2 * ChildIndex
                    If Heap(Parent).Score >= Heap(2 * ChildIndex + 1).Score Then Parent = 2 * ChildIndex + 1
                Else 'Just process the one node
                    If 2 * ChildIndex <= lSize Then
                        If Heap(ChildIndex).Score >= Heap(2 * ChildIndex).Score Then Parent = 2 * ChildIndex
                    End If
                End If

                'Swap out the child/parent
                If Parent <> ChildIndex Then
                    Dim tHeap As BinHeapData = Heap(ChildIndex)
                    Heap(ChildIndex) = Heap(Parent)
                    Heap(Parent) = tHeap
                Else
                    Exit While
                End If

            End While

        End Sub

        'Add the new element to the heap
        Public Sub Add(ByVal inScore As Int16, ByVal inX As Int16, ByVal inY As Int16)

            '**We will be ignoring the (0) place in the heap array because
            '**it's easier to handle the heap with a base of (1..?)

            'Increment the array count
            lSize += 1

            'Make room in the array
            ReDim Preserve Heap(lSize)

            'Store the data
            With Heap(lSize)
                .Score = inScore
                .X = inX
                .Y = inY
            End With

            'Bubble the item to its correct location
            Dim sPos As Int16 = lSize

            While sPos <> 1
                If Heap(sPos).Score <= Heap(sPos / 2).Score Then
                    Dim tHeap As BinHeapData = Heap(sPos / 2)
                    Heap(sPos / 2) = Heap(sPos)
                    Heap(sPos) = tHeap
                    sPos /= 2
                Else
                    Exit While
                End If
            End While

        End Sub

#End Region

    End Class
    Private StartX, StartY, EndX, EndY As Int16
    Private CellMap(11, 5) As CellData
    Public Structure CellData

#Region " Declares "
        Public OCList As Int16
        Public GCost As Int16
        Public HCost As Int16
        Public FCost As Int16
        Public ParentX, ParentY As Int16
        Public Wall As Boolean
        Public DrawPath As Boolean
#End Region

    End Structure
    Private PathFound, PathHunt As Boolean
    Private ParentX, ParentY As Int16

    Private Sub FindPath()
        Dim xCnt, yCnt As Int16
        'Make sure the starting point and ending point are not the same
        If (StartX = EndX) And (StartY = EndY) Then Exit Sub

        'Make sure the starting point or end point is not a wall
        If CellMap(StartX, StartY).Wall Then Exit Sub
        If CellMap(EndX, EndY).Wall Then Exit Sub

        'Set the flags
        PathFound = False
        PathHunt = True
        PathFinished = False

        'Put the starting point on the open list
        CellMap(StartX, StartY).OCList = inOpened
        Heap.Add(0, StartX, StartY)

        'Find the children
        While PathHunt
            If Heap.Count <> 0 Then
                'Get the parent node
                ParentX = Heap.GetX
                ParentY = Heap.GetY

                'Remove the root
                CellMap(ParentX, ParentY).OCList = inClosed
                Heap.RemoveRoot()


                For yCnt = (ParentY - 1) To (ParentY + 1) 'Find the available child nodes to add to the open list
                    For xCnt = (ParentX - 1) To (ParentX + 1)
                        If xCnt <> -1 And xCnt <> 12 And yCnt <> -1 And yCnt < 6 Then 'Check if out of bounds
                            If CellMap(xCnt, yCnt).OCList <> inClosed Then 'Not on the closed list
                                If CellMap(xCnt, yCnt).Wall = False Then 'Make sure its clear/empty
                                    'No cutting across corners
                                    Dim CanWalk As Boolean = True
                                    If xCnt = ParentX - 1 Then
                                        If yCnt = ParentY - 1 Then
                                            If CellMap(ParentX - 1, ParentY).Wall = True Or CellMap(ParentX, ParentY - 1).Wall = True Then CanWalk = False
                                        ElseIf yCnt = ParentY + 1 Then
                                            If CellMap(ParentX, ParentY + 1).Wall = True Or CellMap(ParentX - 1, ParentY).Wall = True Then CanWalk = False
                                        End If
                                    ElseIf xCnt = ParentX + 1 Then
                                        If yCnt = ParentY - 1 Then
                                            If CellMap(ParentX, ParentY - 1).Wall = True Or CellMap(ParentX + 1, ParentY).Wall = True Then CanWalk = False
                                        ElseIf yCnt = ParentY + 1 Then
                                            If CellMap(ParentX + 1, ParentY).Wall = True Or CellMap(ParentX, ParentY + 1).Wall = True Then CanWalk = False
                                        End If
                                    End If

                                    'Check if can move this way
                                    If CanWalk = True Then
                                        If CellMap(xCnt, yCnt).OCList <> inOpened Then

                                            'Calculate the GCost
                                            If Math.Abs(xCnt - ParentX) = 1 And Math.Abs(yCnt - ParentY) = 1 Then
                                                CellMap(xCnt, yCnt).GCost = CellMap(ParentX, ParentY).GCost + 14
                                            Else
                                                CellMap(xCnt, yCnt).GCost = CellMap(ParentX, ParentY).GCost + 10
                                            End If

                                            'Calculate the HCost
                                            CellMap(xCnt, yCnt).HCost = 10 * (Math.Abs(xCnt - EndX) + Math.Abs(yCnt - EndY))
                                            CellMap(xCnt, yCnt).FCost = (CellMap(xCnt, yCnt).GCost + CellMap(xCnt, yCnt).HCost)

                                            'Add the parent value
                                            CellMap(xCnt, yCnt).ParentX = ParentX
                                            CellMap(xCnt, yCnt).ParentY = ParentY

                                            'Add the item to the heap
                                            Heap.Add(CellMap(xCnt, yCnt).FCost, xCnt, yCnt)

                                            'Add the item to the open list
                                            CellMap(xCnt, yCnt).OCList = inOpened

                                        Else
                                            'We will check for better value
                                            'Dim AddedGCost As Int16
                                            'If Math.Abs(xCnt - ParentX) = 1 And Math.Abs(yCnt - ParentY) = 1 Then
                                            '    AddedGCost = 14
                                            'Else
                                            '    AddedGCost = 10
                                            'End If
                                            Dim tempCost As Int16 = CellMap(ParentX, ParentY).GCost + 10

                                            If tempCost < CellMap(xCnt, yCnt).GCost Then
                                                CellMap(xCnt, yCnt).GCost = tempCost
                                                CellMap(xCnt, yCnt).ParentX = ParentX
                                                CellMap(xCnt, yCnt).ParentY = ParentY
                                                If CellMap(xCnt, yCnt).OCList = inOpened Then
                                                    Dim NewCost As Int16 = CellMap(xCnt, yCnt).HCost + CellMap(xCnt, yCnt).GCost
                                                    Heap.Add(NewCost, xCnt, yCnt)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Else
                PathFound = False
                PathHunt = False
                MessageBox.Show("No more searches possible")
                Exit Sub
            End If

            'If we find a path
            If CellMap(EndX, EndY).OCList = inOpened Then
                PathFound = True
                PathHunt = False
            End If
            Application.DoEvents()

            Debug.WriteLine("At the end of path find")
        End While

        If PathFound Then
            Dim tX As Int16 = EndX
            Dim tY As Int16 = EndY
            CellMap(tX, tY).DrawPath = True
            While True
                Dim sX As Int16 = CellMap(tX, tY).ParentX
                Dim sY As Int16 = CellMap(tX, tY).ParentY
                CellMap(sX, sY).DrawPath = True
                tX = sX
                tY = sY
                If tX = StartX And tY = StartY Then Exit While
            End While

        End If
        FollowPath()
    End Sub

    Sub FollowPath()
        Dim Y As Integer = StartY
        Dim X As Integer = StartX
        Dim PathLeft As Boolean = True
        Debug.WriteLine("Made it to followpath")
        Do While PathLeft = True
            PathLeft = False
            If X > 0 Then
                If (CellMap(X - 1, Y).DrawPath) = True Then
                    CellMap(X, Y).DrawPath = False
                    Path &= "L"
                    PathLeft = True
                    X -= 1
                End If
            End If
            If X < 11 Then
                If (CellMap(X + 1, Y).DrawPath) = True Then
                    CellMap(X, Y).DrawPath = False
                    Path &= "R"
                    PathLeft = True
                    X += 1
                End If
            End If
            If Y > 0 Then
                If (CellMap(X, Y - 1).DrawPath) = True Then
                    CellMap(X, Y).DrawPath = False
                    Path &= "D"
                    PathLeft = True
                    Y -= 1
                End If
            End If
            If Y < 5 Then
                If (CellMap(X, Y + 1).DrawPath) = True Then
                    CellMap(X, Y).DrawPath = False
                    Path &= "U"
                    PathLeft = True
                    Y += 1
                End If
            End If

        Loop

        Dim ResetX, ResetY As Int16
        Heap.ResetHeap()
        For ResetY = 0 To 5
            For ResetX = 0 To 11
                With CellMap(ResetX, ResetY)
                    .DrawPath = False
                    .OCList = 0
                    .ParentX = 0
                    .ParentY = 0
                    .FCost = 0
                    .GCost = 0
                    .HCost = 0
                End With
            Next
        Next
        Debug.WriteLine("Made it out of path follow")
        PathFinished = True

    End Sub
End Class
