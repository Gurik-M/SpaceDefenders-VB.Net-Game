Public Enum Direction
    None
    Up
    Down
    Left
    Right
    UpLeft
    UpRight
    DownLeft
    DownRight
End Enum

Public Module DirectionUtils
    Public Function xDelta(direction As Direction) As Integer
        Select Case direction
            Case direction.Left, direction.DownLeft, direction.UpLeft
                Return -1
            Case direction.Right, direction.DownRight, direction.UpRight
                Return 1
        End Select
        Return 0
    End Function
    Public Function yDelta(direction As Direction) As Integer
        Select Case direction
            Case direction.Up, direction.UpLeft, direction.UpRight
                Return -1
            Case direction.Down, direction.DownLeft, direction.DownRight
                Return 1
        End Select
        Return 0
    End Function
End Module