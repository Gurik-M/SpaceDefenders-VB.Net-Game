Imports FinalGameProject

Public MustInherit Class Body
    Implements IKeyboardListener, IMouseListener

    Protected Friend location As Point
    Protected Friend game As GameEngine
    Protected Friend animationTick As Integer = 0

    Public Sub New(g As GameEngine, x As Integer, y As Integer)
        Me.game = g
        Me.location = New Point(x, y)
    End Sub

    Public MustOverride Function SpriteId() As Char

    Public Function Move(d As Direction) As Boolean
        Dim dx As Integer = xDelta(d)
        Dim dy As Integer = yDelta(d)

        Return Move(dx, dy)
    End Function

    Public Function Move(dx As Integer, dy As Integer) As Boolean
        Dim x2 As Integer = location.X + dx
        Dim y2 As Integer = location.Y + dy

        If x2 < 0 Or x2 > 16 Then
            Return False
        End If

        If y2 < 0 Or y2 > 17 Then
            Return False
        End If

        Dim ahead As List(Of Body) = game.Search(x2, y2)
        Dim allowMove As Boolean = True
        For Each target In ahead
            allowMove = allowMove AndAlso Collission(target, dx, dy)
        Next
        If allowMove Then
            location.X = x2
            location.Y = y2
        End If
        Return allowMove
    End Function
    ''' <summary>
    ''' Number of frames between animating this Body.
    ''' </summary>
    ''' <returns>Negative numbers mean animation is disabled</returns>
    Public Overridable Function GetAnimationDelay() As Integer
        Return -1
    End Function
    Public Overridable Sub AnimateIfReady()
        Dim delay As Integer
        delay = GetAnimationDelay()
        If delay <= -1 Then
            Return
        Else
            animationTick += 1
            If animationTick >= delay Then
                animationTick = 0
                Animate()
            End If
        End If
    End Sub
    Public Overridable Sub Animate()
        ' Default does nothing
    End Sub

    ''' <summary>
    ''' Gets called before you Move() into a location that has a Body there already.
    ''' In this project, we'll use Look-Ahead collission detection. The Body that is moving 
    ''' is responsible for not ruining the playability of your game.
    ''' </summary>
    ''' <returns>False if the move should be blocked, True if it should be allowed</returns>
    Protected Friend MustOverride Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean

    Public Overridable Sub KeyDown(keyCode As Keys) Implements IKeyboardListener.KeyDown
    End Sub

    Public Overridable Sub KeyUp(keyCode As Keys) Implements IKeyboardListener.KeyUp
    End Sub

    Public Overridable Sub MouseMoved(x As Integer, y As Integer) Implements IMouseListener.MouseMoved
    End Sub

    Public Overridable Sub MouseDown(button As Integer, x As Integer, y As Integer) Implements IMouseListener.MouseDown
    End Sub

    Public Overridable Sub MouseUp(button As Integer, x As Integer, y As Integer) Implements IMouseListener.MouseUp
    End Sub

    Public Overridable Sub MouseDrag(buttons As Integer, x As Integer, y As Integer) Implements IMouseListener.MouseDrag
    End Sub

    Public Overridable Sub MouseEnter() Implements IMouseListener.MouseEnter
    End Sub

    Public Overridable Sub MouseLeave() Implements IMouseListener.MouseLeave
    End Sub
End Class
