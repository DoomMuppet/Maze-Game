Public Class Welcome
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point With {
                .X = Me.Location.X + (e.X - MouseDownX),
                .Y = Me.Location.Y + (e.Y - MouseDownY)
            }
            Me.Location = temp
            temp = Nothing
        End If
    End Sub
    Private Sub pb_Close_Click(sender As Object, e As EventArgs) Handles pb_Close.Click
        Me.Close()
        MazeWorking.Close()
    End Sub

    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_Close.Image = My.Resources._exit ' Sets the close icon
        pb_Minimise.Image = My.Resources.minimise ' Sets the minimise icon
        Me.BackgroundImage = My.Resources.Welcome

    End Sub

    Private Sub lbl_Welcome_Click(sender As Object, e As EventArgs) Handles lbl_Welcome.Click
        Maze.Show()
        Me.Hide()
    End Sub
End Class