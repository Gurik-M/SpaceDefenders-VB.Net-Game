Imports FinalGameProject

Public Class powerup
    Inherits Body
    Dim game_score As Integer = 0
    Public Sub New(g As GameEngine, x As Integer, y As Integer)
        MyBase.New(g, x, y)
    End Sub

    Public Overrides Function SpriteId() As Char
        Return SpaceDefenders.P
    End Function

    Protected Friend Overrides Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean
        If ahead IsNot Nothing Then

            Dim found As Char
            found = ahead.SpriteId()

            If found = SpaceDefenders.C Then
                game.score += 5
                game.Remove(Me)
                Return True

            ElseIf found = SpaceDefenders.W Then

                Return False
            ElseIf found = SpaceDefenders.B Then

                Return False
            End If

        End If
        ' Default result is, if you run into something: Don't go there.
        Return False
    End Function
    Public Overrides Sub Animate()
        Move(Direction.Down)
        If location.Y = 17 Then
            game.score -= 2
            game.Remove(Me)
        End If
        If game.score = 65 Then
            game.Remove(Me)
        End If
    End Sub
    Public Overrides Function GetAnimationDelay() As Integer
        Return 10
    End Function

End Class
