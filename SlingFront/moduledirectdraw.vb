Module moduledirectdraw
    Public draw As Microsoft.DirectX.DirectDraw.Device = Nothing
    Public Sub InitDirectDrawDevice(ByVal F As Form)
        Try
            draw = New Microsoft.DirectX.DirectDraw.Device
            draw.SetCooperativeLevel(F, Microsoft.DirectX.DirectDraw.CooperativeLevelFlags.Normal)
        Catch
        End Try

    End Sub

    Public Sub SetRes(ByVal F As Form, ByVal ResX As Integer, ByVal ResY As Integer)

        SetRes(F, ResX, ResY, 0)
    End Sub
    Public Sub SetRes(ByVal F As Form, ByVal ResX As Integer, ByVal ResY As Integer, ByVal Freq As Integer)
        If draw Is Nothing Then InitDirectDrawDevice(F)
        Try
            draw.SetDisplayMode(ResX, ResY, 32, Freq, False)
        Catch
        End Try

    End Sub
End Module
