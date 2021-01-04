Imports FinalGameProject
Imports FinalGameProject.SpaceDefenders

Public MustInherit Class Layer

    Public map(,) As Body
    Public bodies As List(Of Body) = New List(Of Body)
    Protected Friend textEnabled As Boolean = False
    Protected Friend game As GameEngine

    Public Sub New(game As GameEngine)
        Me.game = game
    End Sub

    Public Sub CreateMap()
        Dim x As Integer = game.GetXCount
        Dim y As Integer = game.GetYCount
        Dim nextMap(x - 1, y - 1) As Body

        ' TODO #3 Create the map, representing where all of the bodies are, using their location.x and .y
        Dim i As Integer
        i = 0
        While i < bodies.Count
            Dim b As Body
            b = bodies(i)

            ' figure out where that body is.
            Dim xLocation As Integer
            xLocation = b.location.X

            Dim yLocation As Integer
            yLocation = b.location.Y

            ' now put it into nextMap
            If xLocation >= 0 And xLocation < game.GetXCount And yLocation >= 0 And yLocation < game.GetYCount Then
                nextMap(xLocation, yLocation) = b
            End If

            i += 1
        End While

        Me.map = nextMap
    End Sub

    Public Overridable Sub PaintNextFrame(gfx As Graphics)
        If map Is Nothing Then
            Exit Sub
        End If

        ' TODO #4 use the map to figure out which sprite id should be drawn. 
        ' Then get it from the SpriteMap, and draw it using Graphics.
        Dim x As Integer = game.GetXCount
        Dim y As Integer = game.GetYCount
        Dim size As Integer = game.GetTileSize

        Dim i As Integer
        Dim j As Integer

        i = 0
        While i < x
            j = 0
            While j < y
                Dim b As Body
                b = map(i, j)

                If b IsNot Nothing Then
                    Dim type As Char
                    type = b.SpriteId()

                    Dim pictureToDraw As Image
                    pictureToDraw = game.spriteMap(type)

                    gfx.DrawImage(pictureToDraw, i * size, j * size)

                End If
                j += 1
            End While
            i += 1
        End While

    End Sub
    Protected Friend MustOverride Sub ChangeLevel(level As Integer)


    Public Sub remove(target As Body)
        bodies.Remove(target)
    End Sub


    Public Function Search(x As Integer, y As Integer) As Body
        ' TODO #6 search the list of Bodies, and see if you can find one at that (x,y) coordinate. 
        ' If you Then find one, Return it.
        ' If Not, Return Nothing
        Dim i As Integer
        i = 0

        While i < bodies.Count
            Dim b As Body
            b = bodies(i)

            Dim xLocation As Integer
            xLocation = b.location.X
            Dim yLocation As Integer
            yLocation = b.location.Y
            If xLocation = x And yLocation = y Then
                Return b
            End If

            i += 1
        End While


        Return Nothing
    End Function

End Class