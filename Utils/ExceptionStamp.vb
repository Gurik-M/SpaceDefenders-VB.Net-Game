Public Class ExceptionStamp
    Public ReadOnly ex As Exception
    Public ReadOnly t As DateTime

    Public Sub New(ex As Exception)
        Me.ex = ex
        t = DateTime.Now()
    End Sub
End Class
