Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Public Class EndpointVolume
    Private oEnumerator As Object = Nothing
    Private iMde As IMMDeviceEnumerator = Nothing
    Private oDevice As Object = Nothing
    Private imd As IMMDevice = Nothing
    Private oEndPoint As Object = Nothing
    Private iAudioEndpoint As IAudioEndpointVolume = Nothing

    Public Sub New(ByVal eDataFlow As EDataFlow)
        Const CLSCTX_INPROC_SERVER As System.UInt32 = 1
        Dim clsid As New Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")
        Dim IID_IUnknown As New Guid("00000000-0000-0000-C000-000000000046")
        oEnumerator = Nothing
        Dim hResult As System.UInt32 = CoCreateInstance(clsid, Nothing, CLSCTX_INPROC_SERVER, IID_IUnknown, oEnumerator)
        If hResult <> 0 Or oEnumerator Is Nothing Then
        End If

        iMde = CType(oEnumerator, IMMDeviceEnumerator)
        If iMde Is Nothing Then
        End If

        Dim pDevice As IntPtr = IntPtr.Zero
        Dim retVal As Integer = iMde.GetDefaultAudioEndpoint(eDataFlow, ERole.eConsole, pDevice)
        If retVal <> 0 Then
        End If

        Dim dwStateMask As Integer = DEVICE_STATE_ACTIVE Or DEVICE_STATE_NOTPRESENT Or DEVICE_STATE_UNPLUGGED
        Dim pCollection As IntPtr = IntPtr.Zero
        retVal = iMde.EnumAudioEndpoints(eDataFlow, dwStateMask, pCollection)
        If retVal <> 0 Then
        End If

        oDevice = System.Runtime.InteropServices.Marshal.GetObjectForIUnknown(pDevice)
        imd = CType(oDevice, IMMDevice)
        If imd Is Nothing Then
        End If

        Dim iid As New Guid("5CDF2C82-841E-4546-9722-0CF74078229A")
        Dim dwClsCtx As System.UInt32 = CType(CLSCTX.CLSCTX_ALL, System.UInt32)

        Dim pActivationParams As IntPtr = IntPtr.Zero
        Dim pEndPoint As IntPtr = IntPtr.Zero
        retVal = imd.Activate(iid, dwClsCtx, pActivationParams, pEndPoint)
        If retVal <> 0 Then
        End If

        oEndPoint = System.Runtime.InteropServices.Marshal.GetObjectForIUnknown(pEndPoint)
        iAudioEndpoint = CType(oEndPoint, IAudioEndpointVolume)
        If iAudioEndpoint Is Nothing Then
        End If

    End Sub

    Public Property VolumeScalar() As Single
        Get
            Dim vol As Single = -1
            Dim retVal As Integer = iAudioEndpoint.GetMasterVolumeLevelScalar(vol)
            If retVal <> 0 Then
            End If

            Return vol
        End Get
        Set(ByVal value As Single)
            Dim retVal As Integer = iAudioEndpoint.SetMasterVolumeLevelScalar(value, Guid.Empty)
            If retVal <> 0 Then
            End If
        End Set
    End Property

    Public Property IsMuted() As Boolean
        Get
            Dim mute As Boolean = False
            Dim retVal As Integer = iAudioEndpoint.GetMute(mute)
            If retVal <> 0 Then
            End If

            Return mute
        End Get
        Set(ByVal value As Boolean)
            Dim retVal As Integer = iAudioEndpoint.SetMute(value, Guid.Empty)
            If retVal <> 0 Then
            End If
        End Set
    End Property

    Public Overridable Sub Dispose()
        If Not (iAudioEndpoint Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(iAudioEndpoint)
            iAudioEndpoint = Nothing
        End If
        If Not (oEndPoint Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oEndPoint)
            oEndPoint = Nothing
        End If

        If Not (imd Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(imd)
            imd = Nothing
        End If
        If Not (oDevice Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDevice)
            oDevice = Nothing
        End If

        If Not (iMde Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(iMde)
            iMde = Nothing
        End If
        If Not (oEnumerator Is Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oEnumerator)
            oEnumerator = Nothing
        End If
    End Sub

    Declare Auto Function CoCreateInstance Lib "ole32.Dll" (ByRef clsid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByVal inner As Object, ByVal context As System.UInt32, ByRef uuid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByRef rReturnedComObject As Object) As System.UInt32

    <Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAudioEndpointVolume

        Function RegisterControlChangeNotify(ByVal pNotify As IntPtr) As Integer

        Function UnregisterControlChangeNotify(ByVal pNotify As IntPtr) As Integer

        Function GetChannelCount(ByRef pnChannelCount As System.UInt32) As Integer

        Function SetMasterVolumeLevel(ByVal fLevelDB As Single, ByVal pguidEventContext As Guid) As Integer

        Function SetMasterVolumeLevelScalar(ByVal fLevel As Single, ByVal pguidEventContext As Guid) As Integer

        Function GetMasterVolumeLevel(ByRef pfLevelDB As Single) As Integer

        Function GetMasterVolumeLevelScalar(ByRef pfLevel As Single) As Integer

        Function SetChannelVolumeLevel(ByVal nChannel As System.UInt32, ByVal fLevelDB As Single, ByVal pguidEventContext As Guid) As Integer

        Function SetChannelVolumeLevelScalar(ByVal nChannel As System.UInt32, ByVal fLevel As Single, ByVal pguidEventContext As Guid) As Integer

        Function GetChannelVolumeLevel(ByVal nChannel As System.UInt32, ByRef pfLevelDB As Single) As Integer

        Function GetChannelVolumeLevelScalar(ByVal nChannel As System.UInt32, ByRef pfLevel As Single) As Integer

        Function SetMute(ByVal bMute As Boolean, ByVal pguidEventContext As Guid) As Integer

        Function GetMute(ByRef pbMute As Boolean) As Integer

        Function GetVolumeStepInfo(ByRef pnStep As System.UInt32, ByRef pnStepCount As System.UInt32) As Integer

        Function VolumeStepUp(ByVal pguidEventContext As Guid) As Integer

        Function VolumeStepDown(ByVal pguidEventContext As Guid) As Integer

        Function QueryHardwareSupport(ByRef pdwHardwareSupportMask As System.UInt32) As Integer

        Function GetVolumeRange(ByRef pflVolumeMindB As Single, ByRef pflVolumeMaxdB As Single, ByRef pflVolumeIncrementdB As Single) As Integer
    End Interface
    <Guid("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDeviceCollection

        Function GetCount(ByRef pcDevices As System.UInt32) As Integer

        Function Item(ByVal nDevice As System.UInt32, ByRef ppDevice As IntPtr) As Integer
    End Interface
    <Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDevice

        Function Activate(ByRef iid As Guid, ByVal dwClsCtx As System.UInt32, ByVal pActivationParams As IntPtr, ByRef ppInterface As IntPtr) As Integer

        Function OpenPropertyStore(ByVal stgmAccess As Integer, ByRef ppProperties As IntPtr) As Integer

        Function GetId(ByRef ppstrId As String) As Integer

        Function GetState(ByRef pdwState As Integer) As Integer
    End Interface
    <Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDeviceEnumerator

        Function EnumAudioEndpoints(ByVal dataFlow As EDataFlow, ByVal dwStateMask As Integer, ByRef ppDevices As IntPtr) As Integer

        Function GetDefaultAudioEndpoint(ByVal dataFlow As EDataFlow, ByVal role As ERole, ByRef ppEndpoint As IntPtr) As Integer

        Function GetDevice(ByVal pwstrId As String, ByRef ppDevice As IntPtr) As Integer

        Function RegisterEndpointNotificationCallback(ByVal pClient As IntPtr) As Integer

        Function UnregisterEndpointNotificationCallback(ByVal pClient As IntPtr) As Integer
    End Interface
    <Flags()> _
    Enum CLSCTX
        CLSCTX_INPROC_SERVER = &H1
        CLSCTX_INPROC_HANDLER = &H2
        CLSCTX_LOCAL_SERVER = &H4
        CLSCTX_INPROC_SERVER16 = &H8
        CLSCTX_REMOTE_SERVER = &H10
        CLSCTX_INPROC_HANDLER16 = &H20
        CLSCTX_RESERVED1 = &H40
        CLSCTX_RESERVED2 = &H80
        CLSCTX_RESERVED3 = &H100
        CLSCTX_RESERVED4 = &H200
        CLSCTX_NO_CODE_DOWNLOAD = &H400
        CLSCTX_RESERVED5 = &H800
        CLSCTX_NO_CUSTOM_MARSHAL = &H1000
        CLSCTX_ENABLE_CODE_DOWNLOAD = &H2000
        CLSCTX_NO_FAILURE_LOG = &H4000
        CLSCTX_DISABLE_AAA = &H8000
        CLSCTX_ENABLE_AAA = &H10000
        CLSCTX_FROM_DEFAULT_CONTEXT = &H20000
        CLSCTX_INPROC = CLSCTX_INPROC_SERVER Or CLSCTX_INPROC_HANDLER
        CLSCTX_SERVER = CLSCTX_INPROC_SERVER Or CLSCTX_LOCAL_SERVER Or CLSCTX_REMOTE_SERVER
        CLSCTX_ALL = CLSCTX_SERVER Or CLSCTX_INPROC_HANDLER
    End Enum

    Public Enum EDataFlow
        eRender
        eCapture
        eAll
        EDataFlow_enum_count
    End Enum
    _

    Public Enum ERole
        eConsole
        eMultimedia
        eCommunications
        ERole_enum_count
    End Enum

    Const DEVICE_STATE_ACTIVE As Integer = &H1
    Const DEVICE_STATE_DISABLE As Integer = &H2
    Const DEVICE_STATE_NOTPRESENT As Integer = &H4
    Const DEVICE_STATE_UNPLUGGED As Integer = &H8
    Const DEVICE_STATEMASK_ALL As Integer = &HF

End Class