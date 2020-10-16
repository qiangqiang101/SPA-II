Public NotInheritable Class Logger

    Private Sub New()
    End Sub

    Public Shared Sub Log(message As Object)
        IO.File.AppendAllText(".\SPA II.log", DateTime.Now & ":" & message & Environment.NewLine)
    End Sub

    Public Shared Sub Logg(message As Object)
        IO.File.AppendAllText(".\SPA II.txt", message & Environment.NewLine)
    End Sub

End Class