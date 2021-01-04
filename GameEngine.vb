Public MustInherit Class GameEngine

    Public ReadOnly TILE_SIZE = GetTileSize()
    Public ReadOnly MAP_SIZE_X = GetXCount()
    Public ReadOnly MAP_SIZE_Y = GetYCount()

    Protected Friend MustOverride Function GetTileSize() As Integer
    Protected Friend MustOverride Function GetTitle() As String
    Protected Friend MustOverride Function GetXCount() As Integer
    Protected Friend MustOverride Function GetYCount() As Integer

    Protected Friend layers As List(Of Layer) = New List(Of Layer)

    Protected Friend currentLevel As Integer = 0
    Protected Friend score As Integer = 0
    Protected Friend debugEnabled As Boolean = True

    Protected Friend ReadOnly spriteMap As Hashtable = New Hashtable()
    Protected Friend ReadOnly spriteFilenames As Hashtable = New Hashtable()

    Public Sub New()
        CreateLayers()
        LoadSprites()
        NewGame()
    End Sub

    Protected Friend MustOverride Sub CreateLayers()
    Protected Friend MustOverride Sub LoadSprites()

    Public Sub NewGame()
        score = 0
        ChangeLevel(1)
    End Sub
    Public Sub GameOver()
        score = 0

        ChangeLevel(0)
    End Sub

    Public Sub RestartLevel()
        ChangeLevel(currentLevel)
    End Sub
    Public Sub NextLevel()
        currentLevel += 1
        ChangeLevel(currentLevel)
    End Sub

    Public Function GetScore() As Integer
        Return score
    End Function

    Public Sub EnableDebugInfo(x As Boolean)
        debugEnabled = x
    End Sub


    Protected Friend Sub AddSprite(c As Char, folder As String, filename As String)
        If Not spriteMap.ContainsKey(c) OrElse spriteMap(c) Is Nothing Then
            spriteMap.Add(c, Image.FromFile(Helpers.GetPath(folder, filename)))
            spriteFilenames.Add(c, filename)
        Else
            Throw New SpriteAlreadyUsedException(c, spriteFilenames(c), filename)
        End If
    End Sub
    Public Sub ChangeLevel(level As Integer)
        currentLevel = level
        Dim i As Integer = 0
        While i < layers.Count
            Dim layer As Layer = layers(i)
            layer.ChangeLevel(level)

            i += 1
        End While
    End Sub

    Public Sub Remove(target As Body)
        Dim i As Integer = 0
        While i < layers.Count
            layers(i).remove(target)

            i += 1
        End While
    End Sub

    Public Overridable Sub Animate()

        Dim i As Integer
        Dim j As Integer

        i = 0
        While i < layers.Count
            Dim layer As Layer = layers(i)
            Dim bodies As List(Of Body) = layer.bodies
            j = 0
            While j < bodies.Count
                Dim b As Body = bodies(j)

                b.AnimateIfReady()

                j += 1
            End While

            i += 1
        End While
    End Sub
    ''' <summary>
    ''' TODO #7 Search through your layers, in order from top to bottom, and return all of the Bodies that you find at that (x,y) location
    ''' </summary>
    ''' <returns></returns>
    Public Function Search(x As Integer, y As Integer) As List(Of Body)
        Dim ahead As List(Of Body) = New List(Of Body)

        Dim i As Integer
        i = layers.Count - 1
        While i >= 0
            Dim l As Layer
            l = layers(i)

            Dim item As Body
            item = l.Search(x, y)
            If item IsNot Nothing Then

                ahead.Add(item)
            End If

            i -= 1
        End While

        Return ahead
    End Function

    Public Function ConvertPixelToGrid(px As Integer) As Integer
        Return Math.Floor(px / TILE_SIZE)
    End Function

    Public Function ConvertGridToPixel(i As Integer) As Integer
        Return i * TILE_SIZE
    End Function
End Class
