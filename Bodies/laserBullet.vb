Imports FinalGameProject

Public Class laserBullet
    Inherits Body
    Dim game_score As Integer = 0
    Public Sub New(g As GameEngine, x As Integer, y As Integer)
        MyBase.New(g, x, y)
    End Sub

    Public Overrides Function SpriteId() As Char
        Return SpaceDefenders.W
    End Function

    Protected Friend Overrides Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean
        If ahead IsNot Nothing Then

            Dim found As Char
            found = ahead.SpriteId()

            If found = SpaceDefenders.C Then
                Return True
            ElseIf found = SpaceDefenders.P Then
                game.Remove(Me)
                Return False
            ElseIf found = SpaceDefenders.B Then
                'MessageBox.Show("You've Killed an Enemy Ship!")
                game.Remove(ahead)
                game.Remove(Me)
                game.score += 1
                Return True
            End If

        End If
        ' Default result is, if you run into something: Don't go there.
        Return False
    End Function
    Public Overrides Sub Animate()
        Move(Direction.Up)
        If location.Y < 1 Then
            game.Remove(Me)
        End If
    End Sub
    Public Overrides Function GetAnimationDelay() As Integer
        Return 1
    End Function

End Class
