Public Class Form1
    Dim RandomNumber1 As Integer
    Dim RandomNumber2 As Integer ' Seperating each of the four so we can
    Dim RandomNumber3 As Integer ' show how many are right
    Dim RandomNumber4 As Integer

    Dim NumberRight As Integer

    Dim TextNumber1 As Integer
    Dim TextNumber2 As Integer
    Dim TextNumber3 As Integer
    Dim TextNumber4 As Integer
    Private Sub btn_Generate_Click(sender As Object, e As EventArgs) Handles btn_Generate.Click

        RandomNumber1 = CInt(Math.Floor((9 - 0 + 1) * Rnd())) + 0
        RandomNumber2 = CInt(Math.Floor((9 - 0 + 1) * Rnd())) + 0 'Making each number
        RandomNumber3 = CInt(Math.Floor((9 - 0 + 1) * Rnd())) + 0 'random inbetween 9-0
        RandomNumber4 = CInt(Math.Floor((9 - 0 + 1) * Rnd())) + 0
    End Sub

    Private Sub btn_Check_Click(sender As Object, e As EventArgs) Handles btn_Check.Click
        NumberRight = 0

        TextNumber1 = Integer.Parse(TextBox1.Text)
        TextNumber2 = Integer.Parse(TextBox2.Text)
        TextNumber3 = Integer.Parse(TextBox3.Text)
        TextNumber4 = Integer.Parse(TextBox4.Text)

        If (TextNumber1 = RandomNumber1) Then
            NumberRight += 1
        End If
        If (TextNumber1 = RandomNumber2) Then
            NumberRight += 1
        End If
        If (TextNumber1 = RandomNumber3) Then
            NumberRight += 1
        End If
        If (TextNumber1 = RandomNumber4) Then
            NumberRight += 1
        End If


        If (TextNumber2 = RandomNumber1) Then
            NumberRight += 1
        End If
        If (TextNumber2 = RandomNumber2) Then
            NumberRight += 1
        End If
        If (TextNumber2 = RandomNumber3) Then
            NumberRight += 1
        End If
        If (TextNumber2 = RandomNumber4) Then
            NumberRight += 1
        End If


        If (TextNumber3 = RandomNumber1) Then
            NumberRight += 1
        End If
        If (TextNumber3 = RandomNumber2) Then
            NumberRight += 1
        End If
        If (TextNumber3 = RandomNumber3) Then
            NumberRight += 1
        End If
        If (TextNumber3 = RandomNumber4) Then
            NumberRight += 1
        End If


        If (TextNumber4 = RandomNumber1) Then
            NumberRight += 1
        End If
        If (TextNumber4 = RandomNumber2) Then
            NumberRight += 1
        End If
        If (TextNumber4 = RandomNumber3) Then
            NumberRight += 1
        End If
        If (TextNumber4 = RandomNumber4) Then
            NumberRight += 1
        End If

        tb_right.Text = NumberRight.ToString 'NEED TO FIND A WAY TO CLEAR IT

    End Sub
End Class
