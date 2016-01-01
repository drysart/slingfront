#Region " Imports "

Imports System.Runtime.InteropServices

#End Region

Public Class Bass
    Public Const BASS_CTYPE_STREAM_APE As Integer = &H10700
    Public Const BASS_UNICODE As Integer = &H80000000
    Declare Function BASS_ChannelGetTags Lib "bass.dll" (ByVal handle As Integer, ByVal tags As Integer) As IntPtr

    Declare Function BASS_APE_StreamCreateFileUser Lib "bass_ape.dll" (ByVal system As Integer, ByVal flags As Integer, ByVal procs As Integer, ByVal user As Integer) As Integer

    Public Const BASS_CTYPE_STREAM_WV As Integer = &H10500

    Declare Function BASS_WV_StreamCreateFileUser Lib "basswv.dll" (ByVal system As Integer, ByVal flags As Integer, ByVal procs As Integer, ByVal user As Integer) As Integer

    Public Const BASS_ERROR_NOCD As Integer = 12
    Public Const BASS_ERROR_CDTRACK As Integer = 13

    Public Const BASS_CONFIG_CD_FREEOLD As Integer = &H10200

    Public Structure BASS_CD_INFO
        Dim vendor As String
        Dim product As String
        Dim rev As String
        Dim letter As Integer
        Dim rwflags As Long
        Dim canopen As Boolean
        Dim canlock As Boolean
        Dim maxspeed As Long
        Dim cache As Long
        Dim cdtext As Boolean
    End Structure

    Public Const BASS_CD_RWFLAG_READCDR As Integer = 1
    Public Const BASS_CD_RWFLAG_READCDRW As Integer = 2
    Public Const BASS_CD_RWFLAG_READCDRW2 As Integer = 4
    Public Const BASS_CD_RWFLAG_READDVD As Integer = 8
    Public Const BASS_CD_RWFLAG_READDVDR As Integer = 16
    Public Const BASS_CD_RWFLAG_READDVDRAM As Integer = 32
    Public Const BASS_CD_RWFLAG_READANALOG As Integer = &H10000
    Public Const BASS_CD_RWFLAG_READM2F1 As Integer = &H100000
    Public Const BASS_CD_RWFLAG_READM2F2 As Integer = &H200000
    Public Const BASS_CD_RWFLAG_READMULTI As Integer = &H400000
    Public Const BASS_CD_RWFLAG_READCDDA As Integer = &H1000000
    Public Const BASS_CD_RWFLAG_READCDDASIA As Integer = &H2000000
    Public Const BASS_CD_RWFLAG_READSUBCHAN As Integer = &H4000000
    Public Const BASS_CD_RWFLAG_READSUBCHANDI As Integer = &H8000000
    Public Const BASS_CD_RWFLAG_READISRC As Integer = &H20000000
    Public Const BASS_CD_RWFLAG_READUPC As Integer = &H40000000

    Public Const BASS_CD_SUBCHANNEL As Integer = &H200
    Public Const BASS_CD_SUBCHANNEL_NOHW As Integer = &H400

    Public Const BASS_SYNC_CD_ERROR As Integer = 1000

    Public Const BASS_CD_DOOR_CLOSE As Integer = 0
    Public Const BASS_CD_DOOR_OPEN As Integer = 1
    Public Const BASS_CD_DOOR_LOCK As Integer = 2
    Public Const BASS_CD_DOOR_UNLOCK As Integer = 3

    Public Const BASS_CDID_UPC As Integer = 1
    Public Const BASS_CDID_CDDB As Integer = 2
    Public Const BASS_CDID_CDDB2 As Integer = 3
    Public Const BASS_CDID_TEXT As Integer = 4
    Public Const BASS_CDID_CDPLAYER As Integer = 5
    Public Const BASS_CDID_ISRC As Integer = &H100

    Public Const BASS_CHANNEL_STREAM_CD As Integer = &H10200

    Declare Function BASS_CD_GetDriveDescription Lib "basscd.dll" (ByVal drive As Integer) As String

    Declare Function BASS_CD_GetDriveLetter Lib "basscd.dll" (ByVal drive As Integer) As Integer
    Declare Function BASS_CD_GetInfo Lib "basscd.dll" (ByVal drive As Integer, ByRef info As BASS_CD_INFO) As Integer
    Declare Function BASS_CD_Door Lib "basscd.dll" (ByVal drive As Integer, ByVal action As Integer) As Integer
    Declare Function BASS_CD_DoorIsLocked Lib "basscd.dll" (ByVal drive As Integer) As Integer
    Declare Function BASS_CD_DoorIsOpen Lib "basscd.dll" (ByVal drive As Integer) As Boolean
    Declare Function BASS_CD_IsReady Lib "basscd.dll" (ByVal drive As Integer) As Boolean
    Declare Function BASS_CD_GetTracks Lib "basscd.dll" (ByVal drive As Integer) As Integer
    Declare Function BASS_CD_GetTrackLength Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer) As Integer
    Declare Function BASS_CD_GetID Lib "basscd.dll" (ByVal drive As Integer, ByVal id As Integer) As String
    Declare Function BASS_CD_Release Lib "basscd.dll" (ByVal drive As Integer) As Integer

    Declare Function BASS_CD_StreamCreate Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer, ByVal flags As Integer) As Integer
    Declare Function BASS_CD_StreamCreateFile Lib "basscd.dll" (ByVal f As String, ByVal flags As Integer) As Integer
    Declare Function BASS_CD_StreamGetTrack Lib "basscd.dll" (ByVal handle As Integer) As Integer
    Declare Function BASS_CD_StreamSetTrack Lib "basscd.dll" (ByVal handle As Integer, ByVal track As Integer) As Integer

    Declare Function BASS_CD_Analog_Play Lib "basscd.dll" (ByVal drive As Integer, ByVal track As Integer, ByVal pos As Integer) As Integer
    Declare Function BASS_CD_Analog_PlayFile Lib "basscd.dll" (ByVal f As String, ByVal pos As Integer) As Integer
    Declare Function BASS_CD_Analog_Stop Lib "basscd.dll" (ByVal drive As Integer) As Integer
    Declare Function BASS_CD_Analog_IsActive Lib "basscd.dll" (ByVal drive As Integer) As Integer
    Declare Function BASS_CD_Analog_GetPosition Lib "basscd.dll" (ByVal drive As Integer) As Integer

#Region " BASSWMA Constants Declarations "

    Public Const BASS_TAG_APE As Integer = 6

    Public Const BASS_TAG_MP4 As Integer = 7

    Const BASS_AAC_DOWNMATRIX As Integer = &H20000

    Public Const BASS_CTYPE_STREAM_AAC As Integer = &H10B00
    Public Const BASS_CTYPE_STREAM_MP4 As Integer = &H10B01

    Public Const BASS_ERROR_WMA_LICENSE As Integer = 1000
    Public Const BASS_ERROR_WMA_WM9 As Short = 1001
    Public Const BASS_ERROR_WMA_DENIED As Short = 1002

    Public Const BASS_WMA_ENCODE_TAGS As Integer = &H10000
    Public Const BASS_WMA_ENCODE_SCRIPT As Integer = &H20000

    Public Const BASS_WMA_ENCODE_RATES_VBR As Integer = &H10000

    Public Const BASS_WMA_ENCODE_HEAD As Short = 0
    Public Const BASS_WMA_ENCODE_DATA As Short = 1
    Public Const BASS_WMA_ENCODE_DONE As Short = 2

#End Region

#Region " BASSWMA Public Enumerations "

    Public Enum WMACreateFile
        BASS_CREATEFILE_DEFAULT = 0
        BASS_SAMPLE_FLOAT = 256
        BASS_SAMPLE_3D = 8
        BASS_SAMPLE_LOOP = 4
        BASS_SAMPLE_FX = 128
        BASS_SAMPLE_SOFTWARE = 16
        BASS_STREAM_AUTOFREE = 262144
        BASS_STREAM_DECODE = &H200000
        BASS_SPEAKER_FRONT = &H1000000
        BASS_SPEAKER_REAR = &H2000000
        BASS_SPEAKER_CENLFE = &H3000000
        BASS_SPEAKER_REAR2 = &H4000000
        BASS_SPEAKER_LEFT = &H10000000
        BASS_SPEAKER_RIGHT = &H20000000
        BASS_SPEAKER_FRONTLEFT = BASS_SPEAKER_FRONT Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_FRONTRIGHT = BASS_SPEAKER_FRONT Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_REARLEFT = BASS_SPEAKER_REAR Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_REARRIGHT = BASS_SPEAKER_REAR Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_CENTER = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_LFE = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_REAR2LEFT = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_REAR2RIGHT = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_RIGHT
    End Enum

#End Region

#Region " BASSWMA API Declarations "

    Public Const BASS_CHANNEL_STREAM_FLAC As Integer = &H10900

    Declare Function BASS_AAC_StreamCreateFile Lib "bass_aac.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer
    Declare Function BASS_MP4_StreamCreateFile Lib "bass_aac.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer

    Declare Function BASS_FLAC_StreamCreateFile Lib "bassflac.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer
    Declare Function BASS_FLAC_StreamCreateURL Lib "bassflac.dll" (ByVal url As String, ByVal offset As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
    Declare Function BASS_FLAC_StreamCreateFileUser Lib "bassflac.dll" (ByVal buffered As Integer, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
    Declare Function BASS_APE_StreamCreateFile Lib "bass_ape.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer
    Declare Function BASS_WMA_StreamCreateFile Lib "basswma.dll" (ByVal mem As Bass.BassBool, ByVal file As String, ByVal offset As Long, ByVal Length As Long, ByVal flags As WMACreateFile) As Integer
    Declare Function BASS_WV_StreamCreateFile Lib "basswv.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer
    Declare Function BASS_ALAC_StreamCreateFile Lib "bass_alac.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer
    Declare Function BASS_MIDI_StreamCreate Lib "bassmidi.dll" (ByVal channels As Integer, ByVal flags As Integer, ByVal freq As Integer) As Integer
    Declare Function BASS_MIDI_StreamCreateFile Lib "bassmidi.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer, ByVal freq As Integer) As Integer
    Declare Function BASS_MPC_StreamCreateFile Lib "bass_mpc.dll" (ByVal mem As Bass.BassBool, ByVal f As String, ByVal offset As Long, ByVal length As Long, ByVal flags As Integer) As Integer

    Declare Function BASS_ChannelGetLength Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer) As Long
    Private Declare Function BASS_WMA_ChannelSetSync Lib "basswma.dll" (ByVal handle As Integer, ByVal atype As Integer, ByVal param As Long, ByVal proc As Integer, ByVal user As Integer) As Integer

    Declare Function BASS_WMA_GetIWMReader Lib "basswma.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_WMA_EncodeGetRates Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer) As Integer

    Declare Function BASS_WMA_EncodeOpen Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal proc As WMENCODEPROC_handler, ByVal user As Integer) As Integer

    Declare Function BASS_WMA_EncodeOpenFile Lib "basswma.dll" (ByVal freq As Integer, ByVal chans As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal file As String) As Integer

    Declare Function BASS_WMA_EncodeOpenNetwork Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal port As Integer, ByVal clients As Integer) As Integer

    Declare Function BASS_WMA_EncodeOpenPublish Lib "basswma.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal bitrate As Integer, ByVal url As String, ByVal user As String, ByVal pass As String) As Integer

    Declare Function BASS_WMA_EncodeGetPort Lib "basswma.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_WMA_EncodeSetNotify Lib "basswma.dll" (ByVal handle As Integer, ByVal proc As CLIENTCONNECTPROC_handler, ByVal user As Integer) As Integer

    Declare Function BASS_WMA_EncodeGetClients Lib "basswma.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_WMA_EncodeSetTag Lib "basswma.dll" (ByVal handle As Integer, ByVal tag As String, ByVal text As String, ByVal type As Integer) As Integer

    Declare Function BASS_WMA_EncodeWrite Lib "basswma.dll" (ByVal handle As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer

    Declare Sub BASS_WMA_EncodeClose Lib "basswma.dll" (ByVal handle As Integer)

#End Region

#Region " BASSWMA Callback Procedures "

    Sub CLIENTCONNECTPROC(ByVal handle As Integer, ByVal connect As Integer, ByVal ip As Integer, ByVal user As Integer)

    End Sub

    Sub WMENCODEPROC(ByVal handle As Integer, ByVal dtype As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

    End Sub

#End Region

#Region " BASSWMA Callback Delegate Functions "

    Public Delegate Sub CLIENTCONNECTPROC_handler(ByVal handle As Integer, ByVal connect As Integer, ByVal ip As Integer, ByVal user As Integer)

    Public Delegate Sub WMENCODEPROC_handler(ByVal handle As Integer, ByVal dtype As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

#End Region

#Region " BASS Constants Declarations "

    Public Const BASS_CHANNEL_SAMPLE As Integer = 1
    Public Const BASS_CHANNEL_RECORD As Integer = 2
    Public Const BASS_CHANNEL_STREAM As Integer = &H10000
    Public Const BASS_CHANNEL_STREAM_WAV As Integer = &H10001
    Public Const BASS_CHANNEL_STREAM_OGG As Integer = &H10002
    Public Const BASS_CHANNEL_STREAM_MP1 As Integer = &H10003
    Public Const BASS_CHANNEL_STREAM_MP2 As Integer = &H10004
    Public Const BASS_CHANNEL_STREAM_MP3 As Integer = &H10005
    Public Const BASS_CHANNEL_MUSIC_MOD As Integer = &H20000
    Public Const BASS_CHANNEL_MUSIC_MTM As Integer = &H20001
    Public Const BASS_CHANNEL_MUSIC_S3M As Integer = &H20002
    Public Const BASS_CHANNEL_MUSIC_XM As Integer = &H20003
    Public Const BASS_CHANNEL_MUSIC_IT As Integer = &H20004
    Public Const BASS_CHANNEL_MUSIC_MO3 As Integer = &H20100

    Public Const BASSTRUE As Integer = 1
    Public Const BASSFALSE As Integer = 0

    Public Const BASS_OK As Integer = 0
    Public Const BASS_ERROR_MEM As Integer = 1
    Public Const BASS_ERROR_FILEOPEN As Integer = 2
    Public Const BASS_ERROR_DRIVER As Integer = 3
    Public Const BASS_ERROR_BUFLOST As Integer = 4
    Public Const BASS_ERROR_HANDLE As Integer = 5
    Public Const BASS_ERROR_FORMAT As Integer = 6
    Public Const BASS_ERROR_POSITION As Integer = 7
    Public Const BASS_ERROR_INIT As Integer = 8
    Public Const BASS_ERROR_START As Integer = 9
    Public Const BASS_ERROR_ALREADY As Integer = 14
    Public Const BASS_ERROR_NOPAUSE As Integer = 16
    Public Const BASS_ERROR_NOTAUDIO As Integer = 17
    Public Const BASS_ERROR_NOCHAN As Integer = 18
    Public Const BASS_ERROR_ILLTYPE As Integer = 19
    Public Const BASS_ERROR_ILLPARAM As Integer = 20
    Public Const BASS_ERROR_NO3D As Integer = 21
    Public Const BASS_ERROR_NOEAX As Integer = 22
    Public Const BASS_ERROR_DEVICE As Integer = 23
    Public Const BASS_ERROR_NOPLAY As Integer = 24
    Public Const BASS_ERROR_FREQ As Integer = 25
    Public Const BASS_ERROR_NOTFILE As Integer = 27
    Public Const BASS_ERROR_NOHW As Integer = 29
    Public Const BASS_ERROR_EMPTY As Integer = 31
    Public Const BASS_ERROR_NONET As Integer = 32
    Public Const BASS_ERROR_CREATE As Integer = 33
    Public Const BASS_ERROR_NOFX As Integer = 34
    Public Const BASS_ERROR_PLAYING As Integer = 35
    Public Const BASS_ERROR_NOTAVAIL As Integer = 37
    Public Const BASS_ERROR_DECODE As Integer = 38
    Public Const BASS_ERROR_DX As Integer = 39
    Public Const BASS_ERROR_TIMEOUT As Integer = 40
    Public Const BASS_ERROR_FILEFORM As Integer = 41
    Public Const BASS_ERROR_SPEAKER As Integer = 42
    Public Const BASS_ERROR_UNKNOWN As Integer = -1

    Public Const BASS_DEVICE_8BITS As Integer = 1
    Public Const BASS_DEVICE_MONO As Integer = 2
    Public Const BASS_DEVICE_3D As Integer = 4

    Public Const BASS_DEVICE_LATENCY As Integer = 256
    Public Const BASS_DEVICE_SPEAKERS As Integer = 2048

    Public Const DSCAPS_CONTINUOUSRATE As Integer = 16

    Public Const DSCAPS_EMULDRIVER As Integer = 32

    Public Const DSCAPS_CERTIFIED As Integer = 64

    Public Const DSCAPS_SECONDARYMONO As Integer = 256
    Public Const DSCAPS_SECONDARYSTEREO As Integer = 512
    Public Const DSCAPS_SECONDARY8BIT As Integer = 1024
    Public Const DSCAPS_SECONDARY16BIT As Integer = 2048

    Public Const DSCCAPS_EMULDRIVER As Integer = DSCAPS_EMULDRIVER

    Public Const DSCCAPS_CERTIFIED As Integer = DSCAPS_CERTIFIED

    Public Const WAVE_FORMAT_1M08 As Integer = &H1S
    Public Const WAVE_FORMAT_1S08 As Integer = &H2S
    Public Const WAVE_FORMAT_1M16 As Integer = &H4S
    Public Const WAVE_FORMAT_1S16 As Integer = &H8S
    Public Const WAVE_FORMAT_2M08 As Integer = &H10S
    Public Const WAVE_FORMAT_2S08 As Integer = &H20S
    Public Const WAVE_FORMAT_2M16 As Integer = &H40S
    Public Const WAVE_FORMAT_2S16 As Integer = &H80S
    Public Const WAVE_FORMAT_4M08 As Integer = &H100S
    Public Const WAVE_FORMAT_4S08 As Integer = &H200S
    Public Const WAVE_FORMAT_4M16 As Integer = &H400S
    Public Const WAVE_FORMAT_4S16 As Integer = &H800S

    Public Const BASS_MUSIC_FLOAT As Integer = BASS_SAMPLE_FLOAT
    Public Const BASS_MUSIC_MONO As Integer = BASS_SAMPLE_MONO
    Public Const BASS_MUSIC_LOOP As Integer = BASS_SAMPLE_LOOP
    Public Const BASS_MUSIC_3D As Integer = BASS_SAMPLE_3D
    Public Const BASS_MUSIC_FX As Integer = BASS_SAMPLE_FX
    Public Const BASS_MUSIC_AUTOFREE As Integer = BASS_STREAM_AUTOFREE
    Public Const BASS_MUSIC_DECODE As Integer = BASS_STREAM_DECODE
    Public Const BASS_MUSIC_RAMP As Integer = &H200
    Public Const BASS_MUSIC_RAMPS As Integer = &H400
    Public Const BASS_MUSIC_SURROUND As Integer = &H800
    Public Const BASS_MUSIC_SURROUND2 As Integer = &H1000
    Public Const BASS_MUSIC_FT2MOD As Integer = &H2000
    Public Const BASS_MUSIC_PT1MOD As Integer = &H4000
    Public Const BASS_MUSIC_CALCLEN As Integer = &H8000
    Public Const BASS_MUSIC_NONINTER As Integer = &H10000
    Public Const BASS_MUSIC_POSRESET As Integer = &H20000
    Public Const BASS_MUSIC_STOPBACK As Integer = &H80000
    Public Const BASS_MUSIC_NOSAMPLE As Integer = &H100000

    Public Const BASS_SAMPLE_8BITS As Integer = 1
    Public Const BASS_SAMPLE_FLOAT As Short = 256
    Public Const BASS_SAMPLE_MONO As Integer = 2
    Public Const BASS_SAMPLE_LOOP As Integer = 4
    Public Const BASS_SAMPLE_3D As Integer = 8
    Public Const BASS_SAMPLE_SOFTWARE As Integer = 16
    Public Const BASS_SAMPLE_MUTEMAX As Integer = 32
    Public Const BASS_SAMPLE_VAM As Integer = 64
    Public Const BASS_SAMPLE_FX As Integer = 128
    Public Const BASS_SAMPLE_OVER_VOL As Integer = 65536
    Public Const BASS_SAMPLE_OVER_POS As Integer = 131072
    Public Const BASS_SAMPLE_OVER_DIST As Integer = 196608

    Public Const BASS_MP3_SETPOS As Integer = 131072

    Public Const BASS_STREAM_AUTOFREE As Integer = &H40000
    Public Const BASS_STREAM_RESTRATE As Integer = 524288
    Public Const BASS_STREAM_BLOCK As Integer = 1048576
    Public Const BASS_STREAM_DECODE As Integer = &H200000
    Public Const BASS_STREAM_META As Integer = &H400000
    Public Const BASS_STREAM_FILEPROC As Integer = &H800000

    Public Const BASS_SPEAKER_FRONT As Integer = &H1000000
    Public Const BASS_SPEAKER_REAR As Integer = &H2000000
    Public Const BASS_SPEAKER_CENLFE As Integer = &H3000000
    Public Const BASS_SPEAKER_REAR2 As Integer = &H4000000
    Public Const BASS_SPEAKER_LEFT As Integer = &H10000000
    Public Const BASS_SPEAKER_RIGHT As Integer = &H20000000
    Public Const BASS_SPEAKER_FRONTLEFT As Integer = BASS_SPEAKER_FRONT Or BASS_SPEAKER_LEFT
    Public Const BASS_SPEAKER_FRONTRIGHT As Integer = BASS_SPEAKER_FRONT Or BASS_SPEAKER_RIGHT
    Public Const BASS_SPEAKER_REARLEFT As Integer = BASS_SPEAKER_REAR Or BASS_SPEAKER_LEFT
    Public Const BASS_SPEAKER_REARRIGHT As Integer = BASS_SPEAKER_REAR Or BASS_SPEAKER_RIGHT
    Public Const BASS_SPEAKER_CENTER As Integer = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_LEFT
    Public Const BASS_SPEAKER_LFE As Integer = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_RIGHT
    Public Const BASS_SPEAKER_REAR2LEFT As Integer = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_LEFT
    Public Const BASS_SPEAKER_REAR2RIGHT As Integer = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_RIGHT

    Public Const BASS_TAG_ID3 As Integer = 0
    Public Const BASS_TAG_ID3V2 As Integer = 1
    Public Const BASS_TAG_OGG As Integer = 2
    Public Const BASS_TAG_HTTP As Integer = 3
    Public Const BASS_TAG_ICY As Integer = 4
    Public Const BASS_TAG_META As Integer = 5

    Public Const BASS_3DMODE_NORMAL As Integer = 0

    Public Const BASS_3DMODE_RELATIVE As Integer = 1

    Public Const BASS_3DMODE_OFF As Integer = 2

    Public Const EAX_ENVIRONMENT_GENERIC As Integer = 0
    Public Const EAX_ENVIRONMENT_PADDEDCELL As Integer = 1
    Public Const EAX_ENVIRONMENT_ROOM As Integer = 2
    Public Const EAX_ENVIRONMENT_BATHROOM As Integer = 3
    Public Const EAX_ENVIRONMENT_LIVINGROOM As Integer = 4
    Public Const EAX_ENVIRONMENT_STONEROOM As Integer = 5
    Public Const EAX_ENVIRONMENT_AUDITORIUM As Integer = 6
    Public Const EAX_ENVIRONMENT_CONCERTHALL As Integer = 7
    Public Const EAX_ENVIRONMENT_CAVE As Integer = 8
    Public Const EAX_ENVIRONMENT_ARENA As Integer = 9
    Public Const EAX_ENVIRONMENT_HANGAR As Integer = 10
    Public Const EAX_ENVIRONMENT_CARPETEDHALLWAY As Integer = 11
    Public Const EAX_ENVIRONMENT_HALLWAY As Integer = 12
    Public Const EAX_ENVIRONMENT_STONECORRIDOR As Integer = 13
    Public Const EAX_ENVIRONMENT_ALLEY As Integer = 14
    Public Const EAX_ENVIRONMENT_FOREST As Integer = 15
    Public Const EAX_ENVIRONMENT_CITY As Integer = 16
    Public Const EAX_ENVIRONMENT_MOUNTAINS As Integer = 17
    Public Const EAX_ENVIRONMENT_QUARRY As Integer = 18
    Public Const EAX_ENVIRONMENT_PLAIN As Integer = 19
    Public Const EAX_ENVIRONMENT_PARKINGLOT As Integer = 20
    Public Const EAX_ENVIRONMENT_SEWERPIPE As Integer = 21
    Public Const EAX_ENVIRONMENT_UNDERWATER As Integer = 22
    Public Const EAX_ENVIRONMENT_DRUGGED As Integer = 23
    Public Const EAX_ENVIRONMENT_DIZZY As Integer = 24
    Public Const EAX_ENVIRONMENT_PSYCHOTIC As Integer = 25

    Public Const EAX_ENVIRONMENT_COUNT As Integer = 26

    Public Const EAX_PRESET_GENERIC As Integer = 1
    Public Const EAX_PRESET_PADDEDCELL As Integer = 2
    Public Const EAX_PRESET_ROOM As Integer = 3
    Public Const EAX_PRESET_BATHROOM As Integer = 4
    Public Const EAX_PRESET_LIVINGROOM As Integer = 5
    Public Const EAX_PRESET_STONEROOM As Integer = 6
    Public Const EAX_PRESET_AUDITORIUM As Integer = 7
    Public Const EAX_PRESET_CONCERTHALL As Integer = 8
    Public Const EAX_PRESET_CAVE As Integer = 9
    Public Const EAX_PRESET_ARENA As Integer = 10
    Public Const EAX_PRESET_HANGAR As Integer = 11
    Public Const EAX_PRESET_CARPETEDHALLWAY As Integer = 12
    Public Const EAX_PRESET_HALLWAY As Integer = 13
    Public Const EAX_PRESET_STONECORRIDOR As Integer = 14
    Public Const EAX_PRESET_ALLEY As Integer = 15
    Public Const EAX_PRESET_FOREST As Integer = 16
    Public Const EAX_PRESET_CITY As Integer = 17
    Public Const EAX_PRESET_MOUNTAINS As Integer = 18
    Public Const EAX_PRESET_QUARRY As Integer = 19
    Public Const EAX_PRESET_PLAIN As Integer = 20
    Public Const EAX_PRESET_PARKINGLOT As Integer = 21
    Public Const EAX_PRESET_SEWERPIPE As Integer = 22
    Public Const EAX_PRESET_UNDERWATER As Integer = 23
    Public Const EAX_PRESET_DRUGGED As Integer = 24
    Public Const EAX_PRESET_DIZZY As Integer = 25
    Public Const EAX_PRESET_PSYCHOTIC As Integer = 26

    Public Const BASS_SYNC_POS As Integer = 0
    Public Const BASS_SYNC_MUSICPOS As Integer = 0

    Public Const BASS_SYNC_MUSICINST As Integer = 1

    Public Const BASS_SYNC_END As Integer = 2

    Public Const BASS_SYNC_MUSICFX As Integer = 3

    Public Const BASS_SYNC_META As Integer = 4

    Public Const BASS_SYNC_SLIDE As Integer = 5

    Public Const BASS_SYNC_MESSAGE As Integer = &H20000000

    Public Const BASS_SYNC_MIXTIME As Integer = &H40000000

    Public Const BASS_SYNC_ONETIME As Integer = &H80000000

    Public Const RECORDCHAN As Integer = 1

    Public Const BASS_ACTIVE_STOPPED As Integer = 0
    Public Const BASS_ACTIVE_PLAYING As Integer = 1
    Public Const BASS_ACTIVE_STALLED As Integer = 2
    Public Const BASS_ACTIVE_PAUSED As Integer = 3

    Public Const BASS_SLIDE_FREQ As Integer = 1
    Public Const BASS_SLIDE_VOL As Integer = 2
    Public Const BASS_SLIDE_PAN As Integer = 4

    Public Const BASS_DATA_AVAILABLE As Integer = 0
    Public Const BASS_DATA_FFT512 As Integer = &H80000000
    Public Const BASS_DATA_FFT1024 As Integer = &H80000001
    Public Const BASS_DATA_FFT2048 As Integer = &H80000002
    Public Const BASS_DATA_FFT_INDIVIDUAL As Integer = &H10
    Public Const BASS_DATA_FFT_NOWINDOW As Integer = &H20

    Public Const BASS_INPUT_OFF As Integer = &H10000
    Public Const BASS_INPUT_ON As Integer = &H20000
    Public Const BASS_INPUT_LEVEL As Integer = &H40000

    Public Const BASS_INPUT_TYPE_MASK As Integer = &HFF000000
    Public Const BASS_INPUT_TYPE_UNDEF As Integer = &H0
    Public Const BASS_INPUT_TYPE_DIGITAL As Integer = &H1000000
    Public Const BASS_INPUT_TYPE_LINE As Integer = &H2000000
    Public Const BASS_INPUT_TYPE_MIC As Integer = &H3000000
    Public Const BASS_INPUT_TYPE_SYNTH As Integer = &H4000000
    Public Const BASS_INPUT_TYPE_CD As Integer = &H5000000
    Public Const BASS_INPUT_TYPE_PHONE As Integer = &H6000000
    Public Const BASS_INPUT_TYPE_SPEAKER As Integer = &H7000000
    Public Const BASS_INPUT_TYPE_WAVE As Integer = &H8000000
    Public Const BASS_INPUT_TYPE_AUX As Integer = &H9000000
    Public Const BASS_INPUT_TYPE_ANALOG As Integer = &HA000000

    Public Const BASS_NET_TIMEOUT As Integer = 0
    Public Const BASS_NET_BUFFER As Integer = 1

    Public Const BASS_CONFIG_BUFFER As Short = 0
    Public Const BASS_CONFIG_UPDATEPERIOD As Short = 1
    Public Const BASS_CONFIG_MAXVOL As Short = 3
    Public Const BASS_CONFIG_GVOL_SAMPLE As Short = 4
    Public Const BASS_CONFIG_GVOL_STREAM As Short = 5
    Public Const BASS_CONFIG_GVOL_MUSIC As Short = 6
    Public Const BASS_CONFIG_CURVE_VOL As Short = 7
    Public Const BASS_CONFIG_CURVE_PAN As Short = 8
    Public Const BASS_CONFIG_FLOATDSP As Short = 9
    Public Const BASS_CONFIG_3DALGORITHM As Short = 10
    Public Const BASS_CONFIG_NET_TIMEOUT As Short = 11
    Public Const BASS_CONFIG_NET_BUFFER As Short = 12

    Public Const BASS_FILEPOS_DECODE As Integer = 0
    Public Const BASS_FILEPOS_DOWNLOAD As Integer = 1
    Public Const BASS_FILEPOS_END As Integer = 2

    Public Const BASS_FILE_CLOSE As Integer = 0
    Public Const BASS_FILE_READ As Integer = 1
    Public Const BASS_FILE_QUERY As Integer = 2
    Public Const BASS_FILE_LEN As Integer = 3

    Public Const BASS_STREAMPROC_END As Integer = &H80000000

    Public Const BASS_OBJECT_DS As Integer = 1
    Public Const BASS_OBJECT_DS3DL As Integer = 2

    Public Const BASS_VAM_HARDWARE As Integer = 1

    Public Const BASS_VAM_SOFTWARE As Integer = 2

    Public Const BASS_VAM_TERM_TIME As Integer = 4

    Public Const BASS_VAM_TERM_DIST As Integer = 8

    Public Const BASS_VAM_TERM_PRIO As Integer = 16

    Public Const BASS_3DALG_DEFAULT As Integer = 0

    Public Const BASS_3DALG_OFF As Integer = 1

    Public Const BASS_3DALG_FULL As Integer = 2

    Public Const BASS_3DALG_LIGHT As Integer = 3

    Public Const BASS_FX_CHORUS As Integer = 0
    Public Const BASS_FX_COMPRESSOR As Integer = 1
    Public Const BASS_FX_DISTORTION As Integer = 2
    Public Const BASS_FX_ECHO As Integer = 3
    Public Const BASS_FX_FLANGER As Integer = 4
    Public Const BASS_FX_GARGLE As Integer = 5
    Public Const BASS_FX_I3DL2REVERB As Integer = 6
    Public Const BASS_FX_PARAMEQ As Integer = 7
    Public Const BASS_FX_REVERB As Integer = 8

    Public Const BASS_FX_PHASE_NEG_180 As Integer = 0
    Public Const BASS_FX_PHASE_NEG_90 As Integer = 1
    Public Const BASS_FX_PHASE_ZERO As Integer = 2
    Public Const BASS_FX_PHASE_90 As Integer = 3
    Public Const BASS_FX_PHASE_180 As Integer = 4

#End Region

#Region " BASS Public Enumerations "

    Public Enum BassConfigOptions As Short

        BASS_CONFIG_BUFFER = 0
        BASS_CONFIG_UPDATEPERIOD = 1
        BASS_CONFIG_MAXVOL = 3
        BASS_CONFIG_GVOL_SAMPLE = 4
        BASS_CONFIG_GVOL_STREAM = 5
        BASS_CONFIG_GVOL_MUSIC = 6
        BASS_CONFIG_CURVE_VOL = 7
        BASS_CONFIG_CURVE_PAN = 8
        BASS_CONFIG_FLOATDSP = 9
        BASS_CONFIG_3DALGORITHM = 10
        BASS_CONFIG_NET_TIMEOUT = 11
        BASS_CONFIG_NET_BUFFER = 12
    End Enum

    Public Enum BassBool
        BassFalse = 0
        BassTrue = 1
    End Enum

    Public Enum Bass_ErrorCodes

        Bass_Error_Ok = 0
        Bass_Error_Mem = 1
        Bass_Error_Fileopen = 2
        Bass_Error_Driver = 3
        Bass_Error_Buflost = 4
        Bass_Error_Handle = 5
        Bass_Error_Format = 6
        Bass_Error_Position = 7
        Bass_Error_Init = 8
        Bass_Error_Start = 9
        Bass_Error_Already = 14
        Bass_Error_Nopause = 16
        Bass_Error_Notaudio = 17
        Bass_Error_Nochan = 18
        Bass_Error_Illtype = 19
        Bass_Error_Illparam = 20
        Bass_Error_No3D = 21
        Bass_Error_Noeax = 22
        Bass_Error_Device = 23
        Bass_Error_Noplay = 24
        Bass_Error_Freq = 25
        Bass_Error_Notfile = 27
        Bass_Error_Nohw = 29
        Bass_Error_Empty = 31
        Bass_Error_Nonet = 32
        Bass_Error_Create = 33
        Bass_Error_Nofx = 34
        Bass_Error_Playing = 35
        Bass_Error_Notavail = 37
        Bass_Error_Decode = 38
        Bass_Error_Dx = 39
        Bass_Error_Timeout = 40
        Bass_Error_Fileform = 41
        Bass_Error_Speaker = 42
        Bass_Error_Unknown = -1
    End Enum

    Public Enum Bass_Tag

        Bass_Tag_Id3 = 0

        Bass_Tag_Id3V2 = 1

        Bass_Tag_Http = 3

        Bass_Tag_Icy = 4

        Bass_Tag_Meta = 5
    End Enum

    Public Enum Bass_Device

        Device_Default = 0
        Device_8Bits = 1
        Device_Mono = 2
        Device_3D = 4

        Device_Latency = 256

        Device_Speakers = 2048
    End Enum

    Public Enum ChanType As Integer
        BASS_CTYPE_SAMPLE = 1
        BASS_CTYPE_RECORD = 2
        BASS_CTYPE_STREAM = &H10000
        BASS_CTYPE_STREAM_WAV = &H10001
        BASS_CTYPE_STREAM_OGG = &H10002
        BASS_CTYPE_STREAM_MP1 = &H10003
        BASS_CTYPE_STREAM_MP2 = &H10004
        BASS_CTYPE_STREAM_MP3 = &H10005
        BASS_CTYPE_MUSIC_MOD = &H20000
        BASS_CTYPE_MUSIC_MTM = &H20001
        BASS_CTYPE_MUSIC_S3M = &H20002
        BASS_CTYPE_MUSIC_XM = &H20003
        BASS_CTYPE_MUSIC_IT = &H20004
        BASS_CTYPE_MUSIC_MO3 = &H20100
    End Enum

    Public Enum PlayingMode As Integer

        Stopped = 0
        Playing = 1
        Stalled = 2
        Paused = 3
    End Enum

    Public Enum StreamCreateFile
        BASS_CREATEFILE_DEFAULT = 0
        BASS_SAMPLE_FLOAT = 256
        BASS_SAMPLE_MONO = 2
        BASS_SAMPLE_3D = 8
        BASS_SAMPLE_LOOP = 4
        BASS_SAMPLE_FX = 128
        BASS_MP3_SETPOS = 131072
        BASS_STREAM_AUTOFREE = 262144
        BASS_STREAM_DECODE = &H200000
        BASS_SPEAKER_FRONT = &H1000000
        BASS_SPEAKER_REAR = &H2000000
        BASS_SPEAKER_CENLFE = &H3000000
        BASS_SPEAKER_REAR2 = &H4000000
        BASS_SPEAKER_LEFT = &H10000000
        BASS_SPEAKER_RIGHT = &H20000000
        BASS_SPEAKER_FRONTLEFT = BASS_SPEAKER_FRONT Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_FRONTRIGHT = BASS_SPEAKER_FRONT Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_REARLEFT = BASS_SPEAKER_REAR Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_REARRIGHT = BASS_SPEAKER_REAR Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_CENTER = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_LFE = BASS_SPEAKER_CENLFE Or BASS_SPEAKER_RIGHT
        BASS_SPEAKER_REAR2LEFT = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_LEFT
        BASS_SPEAKER_REAR2RIGHT = BASS_SPEAKER_REAR2 Or BASS_SPEAKER_RIGHT
    End Enum

    Public Enum SetSyncSyncType As Integer
        BASS_SYNC_MESSAGE = &H20000000

        BASS_SYNC_MIXTIME = &H40000000

        BASS_SYNC_ONETIME = &H80000000

        BASS_SYNC_POS = 0
        BASS_SYNC_END = 2
        BASS_SYNC_MUSICINST = 1
        BASS_SYNC_MUSICFX = 3
        BASS_SYNC_META = 4
        BASS_SYNC_SLIDE = 5
        BASS_SYNC_STALL = 6
        BASS_SYNC_DOWNLOAD = 7
    End Enum

#End Region

#Region " BASS Public Structures "

    Public Structure BASS_INFO
        Dim size As Integer
        Dim flags As Integer
        Dim hwsize As Integer
        Dim hwfree As Integer
        Dim freesam As Integer
        Dim free3d As Integer
        Dim minrate As Integer
        Dim maxrate As Integer
        Dim eax As Integer
        Dim minbuf As Integer
        Dim dsver As Integer
        Dim latency As Integer
        Dim initflags As Integer
        Dim speakers As Integer
        Dim driver As Integer
    End Structure

    Public Structure BASS_RECORDINFO
        Dim size As Integer
        Dim flags As Integer
        Dim formats As Integer
        Dim inputs As Integer
        Dim singlein As Integer
        Dim driver As Integer
    End Structure

    Public Structure BASS_SAMPLE
        Dim freq As Integer
        Dim volume As Integer
        Dim pan As Integer
        Dim flags As Integer
        Dim Length As Integer
        Dim max As Integer

        Dim mode3d As Integer
        Dim mindist As Single
        Dim MAXDIST As Single
        Dim iangle As Integer
        Dim oangle As Integer
        Dim outvol As Integer

        Dim vam As Integer
        Dim priority As Integer
    End Structure

    Public Structure BASS_3DVECTOR
        Dim X As Single
        Dim Y As Single
        Dim Z As Single
    End Structure

    Public Structure BASS_FXCHORUS
        Dim fWetDryMix As Single
        Dim fDepth As Single
        Dim fFeedback As Single
        Dim fFrequency As Single
        Dim lWaveform As Integer
        Dim fDelay As Single
        Dim lPhase As Integer
    End Structure

    Public Structure BASS_FXCOMPRESSOR
        Dim fGain As Single
        Dim fAttack As Single
        Dim fRelease As Single
        Dim fThreshold As Single
        Dim fRatio As Single
        Dim fPredelay As Single
    End Structure

    Public Structure BASS_FXDISTORTION
        Dim fGain As Single
        Dim fEdge As Single
        Dim fPostEQCenterFrequency As Single
        Dim fPostEQBandwidth As Single
        Dim fPreLowpassCutoff As Single
    End Structure

    Public Structure BASS_FXECHO
        Dim fWetDryMix As Single
        Dim fFeedback As Single
        Dim fLeftDelay As Single
        Dim fRightDelay As Single
        Dim lPanDelay As Integer
    End Structure

    Public Structure BASS_FXFLANGER
        Dim fWetDryMix As Single
        Dim fDepth As Single
        Dim fFeedback As Single
        Dim fFrequency As Single
        Dim lWaveform As Integer
        Dim fDelay As Single
        Dim lPhase As Integer
    End Structure

    Public Structure BASS_FXGARGLE
        Dim dwRateHz As Integer
        Dim dwWaveShape As Integer
    End Structure

    Public Structure BASS_FXI3DL2REVERB
        Dim lRoom As Integer
        Dim lRoomHF As Integer
        Dim flRoomRolloffFactor As Single
        Dim flDecayTime As Single
        Dim flDecayHFRatio As Single
        Dim lReflections As Integer
        Dim flReflectionsDelay As Single
        Dim lReverb As Integer
        Dim flReverbDelay As Single
        Dim flDiffusion As Single
        Dim flDensity As Single
        Dim flHFReference As Single
    End Structure

    Public Structure BASS_FXPARAMEQ
        Dim fCenter As Single
        Dim fBandwidth As Single
        Dim fGain As Single
    End Structure

    Public Structure BASS_FXREVERB
        Dim fInGain As Single
        Dim fReverbMix As Single
        Dim fReverbTime As Single
        Dim fHighFreqRTRatio As Single
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure GUID
        Dim Data1 As Integer
        Dim Data2 As Short
        Dim Data3 As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> _
        Dim Data4 As Byte()
    End Structure

    Public Structure BASS_CHANNELINFO

        Dim freq As Integer
        Dim chans As Integer
        Dim flags As Integer
        Dim ctypex As Integer
        Dim origres As Integer
        Dim plugin As Integer
        Dim sample As Integer
        Dim filename As Integer
    End Structure
    Public Const BASS_ENCODE_NOHEAD As Integer = 1
    Public Const BASS_ENCODE_FP_8BIT As Integer = 2
    Public Const BASS_ENCODE_FP_16BIT As Integer = 4
    Public Const BASS_ENCODE_FP_24BIT As Integer = 6
    Public Const BASS_ENCODE_BIGEND As Integer = 16
    Public Const BASS_ENCODE_PAUSE As Integer = 32

    Declare Function BASS_Encode_Start Lib "bassenc.dll" (ByVal chan As Integer, ByVal cmdline As String, ByVal flags As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
    Declare Function BASS_Encode_IsActive Lib "bassenc.dll" (ByVal chan As Integer) As Integer
    Declare Function BASS_Encode_Stop Lib "bassenc.dll" (ByVal chan As Integer) As Integer
    Declare Function BASS_Encode_SetPaused Lib "bassenc.dll" (ByVal chan As Integer, ByVal paused As Integer) As Integer
    Declare Function BASS_Encode_Write Lib "bassenc.dll" (ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer) As Integer

    Sub ENCODEPROC(ByVal channel As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

    End Sub

#End Region

#Region " BASS API Declarations "

#Region " Standard Win32 DLL Calls "

    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal pDst As IntPtr, _
     ByVal pSrc As String, _
     ByVal ByteLen As Long)

    Private Declare Function lstrlen Lib "kernel32" Alias "lstrlenA" (ByVal lpString As Integer) As Integer

#End Region

#Region " BASS General Declarations "

    Declare Function BASS_SetConfig Lib "bass.dll" (ByVal opt As BassConfigOptions, ByVal value As Integer) As Integer
    Declare Function BASS_GetConfig Lib "bass.dll" (ByVal opt As BassConfigOptions) As Integer

    Declare Function BASS_GetVersion Lib "bass.dll" () As Integer

    Declare Function BASS_GetDeviceDescription Lib "bass.dll" (ByVal devnum As Integer) As IntPtr

    Declare Function BASS_SetBufferLength Lib "bass.dll" (ByVal Length As Single) As Single

    Declare Sub BASS_SetGlobalVolumes Lib "bass.dll" (ByVal musvol As Integer, ByVal samvol As Integer, ByVal strvol As Integer)

    Declare Sub BASS_GetGlobalVolumes Lib "bass.dll" (ByRef musvol As Integer, ByRef samvol As Integer, ByRef strvol As Integer)

    Declare Sub BASS_SetLogCurves Lib "bass.dll" (ByVal volume As Integer, ByVal pan As Integer)

    Declare Sub BASS_Set3DAlgorithm Lib "bass.dll" (ByVal algo As Integer)

    Declare Function BASS_ErrorGetCode Lib "bass.dll" () As Bass_ErrorCodes

    Declare Sub BASS_SetCLSID Lib "bass.dll" (ByRef clsid As GUID)

    Declare Function BASS_Init Lib "bass.dll" (ByVal device As Integer, ByVal freq As Integer, ByVal flags As Bass_Device, ByVal win As Integer, ByVal guid As Integer) As BassBool

    Declare Function BASS_SetDevice Lib "bass.dll" (ByVal device As Integer) As BassBool
    Declare Function BASS_GetDevice Lib "bass.dll" () As Integer
    Declare Function BASS_Free Lib "bass.dll" () As BassBool

    Declare Function BASS_GetDSoundObject Lib "bass.dll" (ByVal object_Renamed As Integer) As Integer

    Declare Function BASS_GetInfo Lib "bass.dll" (ByRef info As BASS_INFO) As BassBool

    Declare Function BASS_Update Lib "bass.dll" () As BassBool

    Declare Function BASS_GetCPU Lib "bass.dll" () As Single

    Declare Function BASS_Start Lib "bass.dll" () As BassBool

    Declare Function BASS_Stop Lib "bass.dll" () As BassBool

    Declare Function BASS_Pause Lib "bass.dll" () As BassBool

    Declare Function BASS_SetVolume Lib "bass.dll" (ByVal volume As Integer) As BassBool

    Declare Function BASS_GetVolume Lib "bass.dll" () As Integer

    Declare Function BASS_Set3DFactors Lib "bass.dll" (ByVal distf As Single, ByVal rollf As Single, ByVal doppf As Single) As BassBool

    Declare Function BASS_Get3DFactors Lib "bass.dll" (ByRef distf As Single, ByRef rollf As Single, ByRef doppf As Single) As BassBool

    Declare Function BASS_Set3DPosition Lib "bass.dll" (ByRef pos As Integer, ByRef vel As Integer, ByRef front As Integer, ByRef top As Integer) As BassBool

    Declare Function BASS_Get3DPosition Lib "bass.dll" (ByRef pos As Integer, ByRef vel As Integer, ByRef front As Integer, ByRef top As Integer) As BassBool

    Declare Function BASS_Apply3D Lib "bass.dll" () As BassBool

    Declare Function BASS_SetEAXParameters Lib "bass.dll" (ByVal env As Integer, ByVal vol As Single, ByVal decay As Single, ByVal damp As Single) As BassBool

    Declare Function BASS_GetEAXParameters Lib "bass.dll" (ByRef env As Integer, ByRef vol As Single, ByRef decay As Single, ByRef damp As Single) As BassBool

#End Region

#Region " BASS Music Declarations "

    Public Const BASS_CONFIG_MIXER_FILTER As Integer = &H10600
    Public Const BASS_CONFIG_MIXER_BUFFER As Integer = &H10601

    Public Const BASS_MIXER_END As Integer = &H10000
    Public Const BASS_MIXER_NONSTOP As Integer = &H20000
    Public Const BASS_MIXER_RESUME As Integer = &H1000

    Public Const BASS_MIXER_FILTER As Integer = &H1000
    Public Const BASS_MIXER_BUFFER As Integer = &H2000
    Public Const BASS_MIXER_MATRIX As Integer = &H10000
    Public Const BASS_MIXER_PAUSE As Integer = &H20000
    Public Const BASS_MIXER_DOWNMIX As Integer = &H400000
    Public Const BASS_MIXER_NORAMPIN As Integer = &H800000

    Public Structure BASS_MIXER_NODE
        Dim pos As Integer
        Dim poshi As Integer
        Dim value As Single
    End Structure

    Public Const BASS_MIXER_ENV_FREQ As Integer = 1
    Public Const BASS_MIXER_ENV_VOL As Integer = 2
    Public Const BASS_MIXER_ENV_PAN As Integer = 3
    Public Const BASS_MIXER_ENV_LOOP As Integer = &H10000

    Public Const BASS_SYNC_MIXER_ENVELOPE As Integer = &H10200

    Public Const BASS_CTYPE_STREAM_MIXER As Integer = &H10800

    Declare Function BASS_Mixer_GetVersion Lib "bassmix.dll" () As Integer

    Declare Function BASS_Mixer_StreamCreate Lib "bassmix.dll" (ByVal freq As Integer, ByVal chans As Integer, ByVal flags As Integer) As Integer
    Declare Function BASS_Mixer_StreamAddChannel Lib "bassmix.dll" (ByVal handle As Integer, ByVal channel As Integer, ByVal flags As Integer) As Integer
    Declare Function BASS_Mixer_StreamAddChannelEx64 Lib "bassmix.dll" Alias "BASS_Mixer_StreamAddChannelEx" (ByVal handle As Integer, ByVal channel As Integer, ByVal flags As Integer, ByVal start As Integer, ByVal starthi As Integer, ByVal length As Integer, ByVal lengthhi As Integer) As Integer

    Declare Function BASS_Mixer_ChannelGetMixer Lib "bassmix.dll" (ByVal handle As Integer) As Integer
    Declare Function BASS_Mixer_ChannelFlags Lib "bassmix.dll" (ByVal handle As Integer, ByVal flags As Integer, ByVal mask As Integer) As Integer
    Declare Function BASS_Mixer_ChannelRemove Lib "bassmix.dll" (ByVal handle As Integer) As Integer
    Declare Function BASS_Mixer_ChannelSetPosition64 Lib "bassmix.dll" Alias "BASS_Mixer_ChannelSetPosition" (ByVal handle As Integer, ByVal pos As Integer, ByVal poshi As Integer, ByVal mode As Integer) As Integer
    Declare Function BASS_Mixer_ChannelGetPosition Lib "bassmix.dll" (ByVal handle As Integer, ByVal mode As Integer) As Integer
    Declare Function BASS_Mixer_ChannelGetLevel Lib "bassmix.dll" (ByVal handle As Integer) As Integer
    Declare Function BASS_Mixer_ChannelGetData Lib "bassmix.dll" (ByVal handle As Integer, ByRef buffer As Byte, ByVal length As Integer) As Integer
    Declare Function BASS_Mixer_ChannelSetSync64 Lib "bassmix.dll" Alias "BASS_Mixer_ChannelSetSync" (ByVal handle As Integer, ByVal type_ As Integer, ByVal param As Integer, ByVal paramhi As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
    Declare Function BASS_Mixer_ChannelRemoveSync Lib "bassmix.dll" (ByVal handle As Integer, ByVal sync As Integer) As Integer
    Declare Function BASS_Mixer_ChannelSetMatrix Lib "bassmix.dll" (ByVal handle As Integer, ByRef matrix As Single) As Integer
    Declare Function BASS_Mixer_ChannelGetMatrix Lib "bassmix.dll" (ByVal handle As Integer, ByRef matrix As Single) As Integer
    Declare Function BASS_Mixer_ChannelSetEnvelope Lib "bassmix.dll" (ByVal handle As Integer, ByVal type_ As Integer, ByRef nodes As BASS_MIXER_NODE, ByVal count As Integer) As Integer
    Declare Function BASS_Mixer_ChannelSetEnvelopePos64 Lib "bassmix.dll" Alias "BASS_Mixer_ChannelSetEnvelopePos" (ByVal handle As Integer, ByVal type_ As Integer, ByVal pos As Integer, ByVal poshi As Integer) As Integer
    Declare Function BASS_Mixer_ChannelGetEnvelopePos Lib "bassmix.dll" (ByVal handle As Integer, ByVal type_ As Integer, ByRef value As Single) As Integer

    Function BASS_Mixer_StreamAddChannelEx(ByVal handle As Integer, ByVal channel As Integer, ByVal flags As Integer, ByVal start As Integer, ByVal length As Integer) As Integer
        BASS_Mixer_StreamAddChannelEx = BASS_Mixer_StreamAddChannelEx64(handle, channel, flags, start, 0, length, 0)
    End Function

    Function BASS_Mixer_ChannelSetPosition(ByVal handle As Integer, ByVal pos As Integer, ByVal mode As Integer) As Integer
        BASS_Mixer_ChannelSetPosition = BASS_Mixer_ChannelSetPosition64(handle, pos, 0, mode)
    End Function

    Function BASS_Mixer_ChannelSetSync(ByVal handle As Integer, ByVal type_ As Integer, ByVal param As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer
        BASS_Mixer_ChannelSetSync = BASS_Mixer_ChannelSetSync64(handle, type_, param, 0, proc, user)
    End Function

    Function BASS_Mixer_ChannelSetEnvelopePos(ByVal handle As Integer, ByVal type_ As Integer, ByVal pos As Integer) As Integer
        BASS_Mixer_ChannelSetEnvelopePos = BASS_Mixer_ChannelSetEnvelopePos64(handle, type_, pos, 0)
    End Function

    Declare Function BASS_MusicLoad Lib "bass.dll" (ByVal mem As BassBool, ByVal f As String, ByVal offset As Long, ByVal Length As Integer, ByVal flags As Integer, ByVal freq As Integer) As Integer

    Declare Sub BASS_MusicFree Lib "bass.dll" (ByVal handle As Integer)
    Public Const BASS_STREAM_PRESCAN As Integer = &H20000
    Public Const BASS_MUSIC_PRESCAN As Integer = &H20000

    Declare Function BASS_MusicGetName Lib "bass.dll" (ByVal handle As Integer) As IntPtr

    Declare Function BASS_MusicGetLength Lib "bass.dll" (ByVal handle As Integer, ByVal playlen As Integer) As Integer

    Declare Function BASS_MusicPreBuf Lib "bass.dll" (ByVal handle As Integer) As BassBool

    Declare Function BASS_MusicPlay Lib "bass.dll" (ByVal handle As Integer) As BassBool

    Declare Function BASS_MusicPlayEx Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Integer, ByVal flags As Integer, ByVal reset_Renamed As Integer) As BassBool

    Declare Function BASS_MusicSetAmplify Lib "bass.dll" (ByVal handle As Integer, ByRef amp As Integer) As BassBool

    Declare Function BASS_MusicSetPanSep Lib "bass.dll" (ByVal handle As Integer, ByRef pan As Integer) As BassBool

    Declare Function BASS_MusicSetPositionScaler Lib "bass.dll" (ByVal handle As Integer, ByVal pscale As Integer) As BassBool

    Declare Function BASS_MusicSetVolume Lib "bass.dll" (ByVal handle As Integer, ByVal channel As Integer, ByVal volume As Integer) As BassBool

    Declare Function BASS_MusicGetVolume Lib "bass.dll" (ByVal handle As Integer, ByVal channel As Integer) As Integer

#End Region

#Region " BASS Sample Declarations "

    Declare Function BASS_SampleLoad Lib "bass.dll" (ByVal mem As BassBool, ByVal f As String, ByVal offset As Integer, ByVal Length As Integer, ByVal max As Integer, ByVal flags As Integer) As Integer

    Declare Function BASS_SampleCreate Lib "bass.dll" (ByVal Length As Integer, ByVal freq As Integer, ByVal max As Integer, ByVal flags As Integer) As Integer

    Declare Function BASS_SampleCreateDone Lib "bass.dll" () As Integer

    Declare Sub BASS_SampleFree Lib "bass.dll" (ByVal handle As Integer)

    Declare Function BASS_SampleGetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_SAMPLE) As BassBool

    Declare Function BASS_SampleSetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_SAMPLE) As BassBool

    Declare Function BASS_SamplePlay Lib "bass.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_SamplePlayEx Lib "bass.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer, ByVal pLoop As Integer) As Integer

    Declare Function BASS_SamplePlay3D Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Integer, ByRef orient As Integer, ByRef vel As Integer) As Integer

    Declare Function BASS_SamplePlay3DEx Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Integer, ByRef orient As Integer, ByRef vel As Integer, ByVal start As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pLoop As Integer) As Integer

    Declare Function BASS_SampleStop Lib "bass.dll" (ByVal handle As Integer) As BassBool

#End Region

#Region " BASS Stream Declarations "

    Declare Function BASS_StreamCreate Lib "bass.dll" (ByVal freq As Integer, ByVal chans As Integer, ByVal flags As Integer, ByVal proc As STREAMPROC_Handler, ByVal user As Integer) As Integer

    Declare Function BASS_StreamCreateFile Lib "bass.dll" (ByVal mem As BassBool, ByVal f As String, ByVal offset As Long, ByVal Length As Long, ByVal flags As StreamCreateFile) As Integer

    Declare Function BASS_StreamCreateFileUser Lib "bass.dll" (ByVal buffered As BassBool, ByVal flags As Integer, ByVal proc As STREAMFILEPROC_Handler, ByVal user As Integer) As Integer

    Declare Function BASS_StreamCreateURL Lib "bass.dll" (ByVal url As String, ByVal offset As Integer, ByVal flags As Integer, ByVal proc As DOWNLOADPROC_Handler, ByVal user As Integer) As Integer

    Declare Sub BASS_StreamFree Lib "bass.dll" (ByVal handle As Integer)

    Declare Function BASS_StreamGetLength Lib "bass.dll" (ByVal handle As Integer) As Long

    Declare Function BASS_StreamGetTags Lib "bass.dll" (ByVal handle As Integer, ByVal tags As Bass_Tag) As Integer

    Declare Function BASS_StreamPreBuf Lib "bass.dll" (ByVal handle As Integer) As BassBool

    Declare Function BASS_StreamPlay Lib "bass.dll" (ByVal handle As Integer, ByVal flush As BassBool, ByVal flags As Integer) As BassBool

    Declare Function BASS_StreamGetFilePosition Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer) As Integer

#End Region

#Region " BASS Recording Declarations "

    Declare Function BASS_RecordInit Lib "bass.dll" (ByVal device As Integer) As BassBool

    Declare Function BASS_RecordFree Lib "bass.dll" () As BassBool

    Declare Sub BASS_RecordGetInfo Lib "bass.dll" (ByRef info As BASS_RECORDINFO)

    Declare Function BASS_RecordGetInputName Lib "bass.dll" (ByVal inputn As Integer) As Integer

    Declare Function BASS_RecordSetInput Lib "bass.dll" (ByVal inputn As Integer, ByVal setting As Integer) As BassBool

    Declare Function BASS_RecordGetInput Lib "bass.dll" (ByVal inputn As Integer) As Integer

    Declare Function BASS_RecordStart Lib "bass.dll" (ByVal freq As Integer, ByVal flags As Integer, ByVal proc As RECORDPROC_Handler, ByVal user As Integer) As Integer

    Declare Function BASS_RecordGetDeviceDescription Lib "bass.dll" (ByVal devnum As Integer) As IntPtr

    Declare Function BASS_RecordSetDevice Lib "bass.dll" (ByVal device As Integer) As BassBool

    Declare Function BASS_RecordGetDevice Lib "bass.dll" () As Integer

#End Region

#Region " BASS Channel Declarations "

    Declare Function BASS_ChannelBytes2Seconds Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Long) As Single

    Declare Function BASS_ChannelSeconds2Bytes Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Single) As Long

    Declare Function BASS_ChannelGetDevice Lib "bass.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_ChannelIsActive Lib "bass.dll" (ByVal handle As Integer) As PlayingMode

    Declare Function BASS_ChannelGetFlags Lib "bass.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_ChannelGetInfo Lib "bass.dll" (ByVal handle As Integer, ByRef info As BASS_CHANNELINFO) As Bass.BassBool

    Declare Function BASS_ChannelStop Lib "bass.dll" (ByVal handle As Integer) As BassBool

    Declare Function BASS_ChannelPause Lib "bass.dll" (ByVal handle As Integer) As BassBool
    Declare Function BASS_ChannelPlay Lib "bass.dll" (ByVal handle As Integer, Optional ByVal restart As Integer = 0) As Integer

    Declare Function BASS_channelresume Lib "bass.dll" (ByVal handle As Integer) As BassBool

    Declare Function BASS_ChannelSetAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer) As BassBool
    Declare Function BASS_ChannelSetAttribute Lib "bass.dll" (ByVal handle As Integer, ByVal attrib As Integer, ByVal volume As Double) As BassBool

    Public Const BASS_ATTRIB_FREQ As Integer = 1
    Public Const BASS_ATTRIB_VOL As Integer = 2
    Public Const BASS_ATTRIB_PAN As Integer = 3

    Declare Function BASS_ChannelGetAttributes Lib "bass.dll" (ByVal handle As Integer, ByRef freq As Integer, ByRef volume As Integer, ByRef pan As Integer) As BassBool

    Declare Function BASS_ChannelSlideAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal freq As Integer, ByVal volume As Integer, ByVal pan As Integer, ByVal time As Integer) As BassBool

    Declare Function BASS_ChannelIsSliding Lib "bass.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_ChannelSet3DAttributes Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer, ByVal min As Single, ByVal max As Single, ByVal iangle As Integer, ByVal oangle As Integer, ByVal outvol As Integer) As BassBool

    Declare Function BASS_ChannelGet3DAttributes Lib "bass.dll" (ByVal handle As Integer, ByRef mode As Integer, ByRef min As Single, ByRef max As Single, ByRef iangle As Integer, ByRef oangle As Integer, ByRef outvol As Integer) As BassBool

    Declare Function BASS_ChannelSet3DPosition Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Integer, ByRef orient As Integer, ByRef vel As Integer) As BassBool

    Declare Function BASS_ChannelGet3DPosition Lib "bass.dll" (ByVal handle As Integer, ByRef pos As Integer, ByRef orient As Integer, ByRef vel As Integer) As BassBool

    Declare Function BASS_ChannelSetPosition Lib "bass.dll" (ByVal handle As Integer, ByVal pos As Long, ByVal mode As Integer) As BassBool

    Declare Function BASS_ChannelGetPosition Lib "bass.dll" (ByVal handle As Integer, ByVal mode As Integer) As Long

    Declare Function BASS_ChannelGetLevel Lib "bass.dll" (ByVal handle As Integer) As Integer

    Declare Function BASS_ChannelGetData Lib "bass.dll" (ByVal handle As Integer, ByRef buffer As Single, ByVal Length As Integer) As Integer
    Declare Function BASS_ChannelGetData Lib "bass.dll" (ByVal handle As Integer, ByRef buffer As Integer, ByVal Length As Integer) As Integer
    Declare Function BASS_ChannelGetData Lib "bass.dll" (ByVal handle As Integer, ByRef buffer As Short, ByVal Length As Integer) As Integer
    Declare Function BASS_ChannelGetData Lib "bass.dll" (ByVal handle As Integer, ByRef buffer As Byte, ByVal Length As Integer) As Integer

    Declare Function BASS_ChannelSetSync Lib "bass.dll" (ByVal handle As Integer, ByVal atype As SetSyncSyncType, ByVal param As Long, ByVal proc As SYNCPROC_Handler, ByVal user As Integer) As Integer

    Declare Function BASS_ChannelRemoveSync Lib "bass.dll" (ByVal handle As Integer, ByVal sync As Integer) As BassBool

    Declare Function BASS_ChannelSetDSP Lib "bass.dll" (ByVal handle As Integer, ByVal proc As Integer, ByVal user As Integer) As Integer

    Declare Function BASS_ChannelRemoveDSP Lib "bass.dll" (ByVal handle As Integer, ByVal dsp As Integer) As BassBool

    Declare Function BASS_ChannelSetEAXMix Lib "bass.dll" (ByVal handle As Integer, ByVal mix As Single) As BassBool

    Declare Function BASS_ChannelGetEAXMix Lib "bass.dll" (ByVal handle As Integer, ByRef mix As Single) As BassBool

    Declare Function BASS_ChannelSetLink Lib "bass.dll" (ByVal handle As Integer, ByVal chan As Integer) As BassBool

    Declare Function BASS_ChannelRemoveLink Lib "bass.dll" (ByVal handle As Integer, ByVal chan As Integer) As BassBool

    Declare Function BASS_ChannelSetFX Lib "bass.dll" (ByVal handle As Integer, ByVal atype As Integer) As Integer

    Declare Function BASS_ChannelRemoveFX Lib "bass.dll" (ByVal handle As Integer, ByVal fx As Integer) As BassBool

    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As Integer) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXCHORUS) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXCOMPRESSOR) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXDISTORTION) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXECHO) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXFLANGER) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXGARGLE) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXI3DL2REVERB) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXPARAMEQ) As BassBool
    Declare Function BASS_FXSetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXREVERB) As BassBool

    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As Integer) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXCHORUS) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXCOMPRESSOR) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXDISTORTION) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXECHO) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXFLANGER) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXGARGLE) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXI3DL2REVERB) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXPARAMEQ) As BassBool
    Declare Function BASS_FXGetParameters Lib "bass.dll" (ByVal handle As Integer, ByRef par As BASS_FXREVERB) As BassBool

#End Region

#End Region

#Region " BASS Callback Delegate Functions "

    Public Delegate Function STREAMFILEPROC_Handler(ByVal action As Integer, ByVal param1 As Integer, ByVal param2 As Integer, ByVal user As Integer) As Integer

    Public Delegate Function STREAMPROC_Handler(ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer

    Public Delegate Sub SYNCPROC_Handler(ByVal handle As Integer, ByVal channel As Integer, ByVal data As Integer, ByVal user As Integer)

    Public Delegate Sub DSPPROC_Handler(ByVal handle As Integer, ByVal channel As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

    Public Delegate Function RECORDPROC_Handler(ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer

    Public Delegate Sub DOWNLOADPROC_Handler(ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

#End Region

#Region " BASS Callback Procedures "

    Function STREAMPROC(ByVal handle As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer

    End Function

    Function STREAMFILEPROC(ByVal action As Integer, ByVal param1 As Integer, ByVal param2 As Integer, ByVal user As Integer) As Integer

    End Function

    Sub SYNCPROC(ByVal handle As Integer, ByVal channel As Integer, ByVal data As Integer, ByVal user As Integer)

    End Sub

    Sub DSPPROC(ByVal handle As Integer, ByVal channel As Integer, ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

    End Sub

    Function RECORDPROC(ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer) As Integer

    End Function

    Sub DOWNLOADPROC(ByVal buffer As Integer, ByVal length As Integer, ByVal user As Integer)

    End Sub

#End Region

#Region " Helper Functions "

    Function BASS_GetStringVersion() As String

        BASS_GetStringVersion = Trim(Str(GetLoWord(BASS_GetVersion))) & "." & Trim(Str(GetHiWord(BASS_GetVersion)))
    End Function

    Public Function GetHiWord(ByRef lparam As Integer) As Integer

        GetHiWord = lparam \ &H10000 And &HFFFF
    End Function
    Public Function GetLoWord(ByRef lparam As Integer) As Integer

        GetLoWord = lparam And &HFFFF
    End Function

    Public Function BASS_GetErrorDescription(ByRef ErrorCode As Bass_ErrorCodes) As String
        Select Case ErrorCode
            Case Bass_ErrorCodes.Bass_Error_Ok
                Return "All is OK"
            Case Bass_ErrorCodes.Bass_Error_Mem
                Return "Memory Error"
            Case Bass_ErrorCodes.Bass_Error_Fileopen
                Return "Can"
            Case Bass_ErrorCodes.Bass_Error_Driver
                Return "Can"
            Case Bass_ErrorCodes.Bass_Error_Buflost
                Return "The Sample Buffer Was Lost - Please Report This!"
            Case Bass_ErrorCodes.Bass_Error_Handle
                Return "Invalid Handle"
            Case Bass_ErrorCodes.Bass_Error_Format
                Return "Unsupported Format"
            Case Bass_ErrorCodes.Bass_Error_Position
                Return "Invalid Playback Position"
            Case Bass_ErrorCodes.Bass_Error_Init
                Return "BASS_Init Has Not Been Successfully Called"
            Case Bass_ErrorCodes.Bass_Error_Start
                Return "BASS_Start Has Not Been Successfully Called"
            Case Bass_ErrorCodes.Bass_Error_Already
                Return "Already Initialized"
            Case Bass_ErrorCodes.Bass_Error_Nopause
                Return "Not Paused"
            Case Bass_ErrorCodes.Bass_Error_Notaudio
                Return "Not An Audio Track"
            Case Bass_ErrorCodes.Bass_Error_Nochan
                Return "Can"
            Case Bass_ErrorCodes.Bass_Error_Illtype
                Return "An Illegal Type Was Specified"
            Case Bass_ErrorCodes.Bass_Error_Illparam
                Return "An Illegal Parameter Was Specified"
            Case Bass_ErrorCodes.Bass_Error_No3D
                Return "No 3D Support"
            Case Bass_ErrorCodes.Bass_Error_Noeax
                Return "No EAX Support"
            Case Bass_ErrorCodes.Bass_Error_Device
                Return "Illegal Device Number"
            Case Bass_ErrorCodes.Bass_Error_Noplay
                Return "Not Playing"
            Case Bass_ErrorCodes.Bass_Error_Freq
                Return "Illegal Sample Rate"
            Case Bass_ErrorCodes.Bass_Error_Notfile
                Return "The Stream is Not a File Stream (WAV/MP3)"
            Case Bass_ErrorCodes.Bass_Error_Nohw
                Return "No Hardware Voices Available"
            Case Bass_ErrorCodes.Bass_Error_Empty
                Return "The MOD music has no sequence data"
            Case Bass_ErrorCodes.Bass_Error_Nonet
                Return "No Internet connection could be opened"
            Case Bass_ErrorCodes.Bass_Error_Create
                Return "Couldn"
            Case Bass_ErrorCodes.Bass_Error_Nofx
                Return "Effects are not enabled"
            Case Bass_ErrorCodes.Bass_Error_Playing
                Return "The channel is playing"
            Case Bass_ErrorCodes.Bass_Error_Notavail
                Return "The requested data is not available"
            Case Bass_ErrorCodes.Bass_Error_Decode
                Return "The channel is a"
            Case Bass_ErrorCodes.Bass_Error_Unknown
                Return "Some Other Mystery Error"
            Case Else
                Return ""
        End Select
    End Function

    Public Function VBStrFromAnsiInteger(ByVal lpStr As Integer) As String

        Return Marshal.PtrToStringAnsi(New IntPtr(lpStr))
    End Function

    Public Function VBStrFromAnsiPtr(ByVal lpStr As IntPtr) As String

        Return Marshal.PtrToStringAnsi(lpStr)
    End Function

    Public Function FixTimespan(ByVal inPos As Double) As String
        Return Mid(TimeSpan.FromSeconds(inPos).ToString, 4, 5)
    End Function

    Public Function GetChannelDescription(ByVal chan As Integer) As String
        Select Case chan
            Case 1
                Return chan.ToString & " (Mono)"
            Case 2
                Return chan.ToString & " (Stereo)"
            Case Else
                Return chan.ToString
        End Select
    End Function
#End Region

    Public Declare Function TAGS_Read Lib "tags.dll" Alias "TAGS_Read" (ByVal handle As Integer, ByVal fmt As String) As String
    Public Declare Function TAGS_GetLastErrorDesc Lib "tags.dll" Alias "TAGS_GetLastErrorDesc" () As Integer
    Public Declare Function TAGS_GetVersion Lib "tags.dll" Alias "TAGS_GetVersion" () As Integer

End Class