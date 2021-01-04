Imports FinalGameProject

Public Class Character
    Inherits Body
    Dim game_score As Integer = 0
    Dim bullet_location_x = location.X
    Dim bullet_location_y = location.Y


    Public Sub New(g As GameEngine, x As Integer, y As Integer)
        MyBase.New(g, x, y)
    End Sub

    Public Overrides Function SpriteId() As Char
        Return SpaceDefenders.C
    End Function

    Protected Friend Overrides Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean
        If ahead IsNot Nothing Then

            Dim found As Char
            found = ahead.SpriteId()

            If found = SpaceDefenders.P Then
                game.score += 5
                game.Remove(ahead)
                Return True

            ElseIf found = SpaceDefenders.B Then
                MessageBox.Show("OH NO!!")
                MessageBox.Show("You've Crashed Into The Enemy Ship and You're Ship is Destroyed! You have been killed.")
                MessageBox.Show("You have been killed.")
                MessageBox.Show("Click ok to redeem yourself")
                game.Remove(ahead)
                game.score = 0

                game.GameOver()
                Return True
            End If

        End If
        ' Default result is, if you run into something: Don't go there.
        Return False
    End Function

    Public Overrides Sub KeyDown(keyCode As Keys)
        MyBase.KeyDown(keyCode)

        If keyCode = Keys.Left Then
            Move(Direction.Left)
        ElseIf keyCode = Keys.Right Then
            Move(Direction.Right)
        ElseIf keyCode = Keys.Down Then
            Move(Direction.Down)
        ElseIf keyCode = Keys.Up Then
            Move(Direction.Up)
        ElseIf keyCode = Keys.Space Then

            game.layers(1).bodies.Add(New laserBullet(game, location.X + 1, location.Y - 1))
            game.layers(1).bodies.Add(New laserBullet(game, location.X, location.Y - 1))


        End If

    End Sub
End Class
