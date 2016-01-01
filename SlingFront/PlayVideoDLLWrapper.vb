Public Class Functions_

    Public Structure RECT
        Dim x As Integer
        Dim y As Integer
        Dim width As Integer
        Dim height As Integer
    End Structure

    Declare Auto Function SurfaceRotate Lib "PlayVideoDLL.dll" (ByVal srcptr As IntPtr, ByVal desptr As IntPtr, ByVal width As Integer, ByVal height As Integer) As Integer
    Declare Auto Function SurfaceRotateSix Lib "PlayVideoDLL.dll" (ByVal srcptr As IntPtr, ByVal desptr As IntPtr, ByVal width As Integer, ByVal height As Integer) As Integer

    Declare Auto Function InitializeVideoPlayer Lib "PlayVideoDLL.dll" () As Integer
    Declare Auto Function OpenVideo Lib "PlayVideoDLL.dll" (ByVal fileName As String, ByVal hdc As IntPtr, ByVal sound As Boolean) As Integer

    Declare Auto Function UninitializeVideoPlayer Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function DrawNewFrame Lib "PlayVideoDLL.dll" (ByVal hdc As IntPtr, ByVal widthScreen As Integer, ByVal heightScreen As Integer, ByVal alpha As Byte) As Integer

    Declare Auto Function StartVideo Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function StopVideo Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function IsPlaying Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function VideoComplete Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function Seek Lib "PlayVideoDLL.dll" (ByVal time As Long) As Integer

    Declare Auto Function PlayVideo Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function GetVideoDuration Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Sub ShowTaskBar Lib "PlayVideoDLL.dll" ()
    Declare Auto Sub HideTaskBar Lib "PlayVideoDLL.dll" ()

    Declare Auto Function GetVideoSize Lib "PlayVideoDLL.dll" () As RECT

    Declare Auto Function AlphaBlendDCs Lib "PlayVideoDLL.dll" (ByVal SrcX As Integer, ByVal SrcY As Integer, ByVal SrcWidth As Integer, ByVal SrcHeight As Integer, ByVal DesX As Integer, ByVal DesY As Integer, ByVal DesWidth As Integer, ByVal DesHeight As Integer, ByVal SrcHDC As IntPtr, ByVal DesHDC As IntPtr, ByVal alpha As Byte) As Integer

    Declare Auto Function Update Lib "PlayVideoDLL.dll" () As Integer

    Declare Auto Function GetMasterVolume Lib "PlayVideoDLL.dll" () As Integer
    Declare Auto Function SetMasterVolume Lib "PlayVideoDLL.dll" (ByVal Volume As Integer) As Boolean

    Declare Auto Function SendKeysVideo Lib "PlayVideoDLL.dll" (ByVal kys() As Byte, ByVal wait As Boolean) As Boolean
    Declare Auto Function SendKeysStart Lib "PlayVideoDLL.dll" (ByVal kys() As Byte, ByVal wait As Boolean) As Boolean

    Declare Auto Function SendKeysStart2 Lib "PlayVideoDLL.dll" (ByVal kys() As Byte, ByVal wait As Boolean) As Boolean

    Declare Auto Function SendKeysStart3 Lib "PlayVideoDLL.dll" (ByVal kys() As Byte, ByVal wait As Boolean) As Boolean
    Declare Auto Function SendKeysNormal Lib "PlayVideoDLL.dll" (ByVal kys() As Byte, ByVal wait As Boolean) As Boolean

    Declare Auto Function SendVKx Lib "PlayVideoDLL.dll" (ByRef dum As Byte, ByVal bytetosend As Byte, ByVal Wait As Boolean, ByVal SendUp As Boolean) As Boolean
    Declare Auto Function SendVKUP Lib "PlayVideoDLL.dll" (ByRef dum As Byte, ByVal bytetosend As Byte, ByVal Wait As Boolean) As Boolean

End Class