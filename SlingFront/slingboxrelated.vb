Module slingboxrelated

    Public Structure StructSlingboxProxy
        Dim Enabled As Boolean
        Dim Address As String
        Dim Port As Integer
        Dim User As String
        Dim Password As String
    End Structure

    Public Structure StructSlingboxInfo
        Dim ArrayNbr As Integer
        Dim FinderID As String
        Dim IP As String
        Dim Port As Integer
        Dim Name As String
        Dim User As String
        Dim Password As String
        Dim AccountIsAdmin As Boolean
        Dim Aspect As Enum_Aspect
        Dim LoadedChannels As Boolean
        Dim Encoding As StructSlingboxEncodingInfo
        Dim IniID As Integer
        Dim Proxy As StructSlingboxProxy
        Dim HasConnected As Boolean
        Dim IsConnected As Boolean
        Dim LastConnected As DateTime
        Dim UsingRemote As Boolean
        Dim CustomLoaded As Boolean
        Dim IRCodes As String
        Dim IRDigits As String
        Dim ChannelDigits As Integer
    End Structure
    Public Enum Enum_Aspect As Integer
        Aspect_43 = 1
        Aspect_169 = 2
        Aspect_Anamorphic = 80

    End Enum
    Public Enum StreamVideoResolution

        Video320x240 = 1
        Video160x120 = 2
        Video352x240 = 3
        Video176x120 = 4
        Video640x480 = 5
        Video640x240 = 6
        Video320x480 = 7
        Video128x96 = 8
        Video224x176 = 9
        Video448x240 = 10
        Video256x192 = 11
        VideoHD1280x720 = 12
        VideoHD1440x544 = 13
        VideoHD1680x544 = 14
        VideoHD1920x544 = 15
        VideoHD1920x1080 = 16
        VideoResolutionAuto = 512
    End Enum
    Public Structure StructSlingboxEncodingInfo
        Dim Quality As StreamQuality
        Dim Bitrate As StreamBitrate
        Dim Resolution As StreamVideoResolution
        Dim Manual As Boolean
        Dim VideoBitRate As Integer
        Dim AudioBitRate As Integer
        Dim VideoFPS As Integer
        Dim IFRame As Integer
        Dim Smoothing As Integer

    End Structure
    Public Enum StreamQuality
        Auto
        Minimum
        Good
        Better
        Best
        BestHD
    End Enum

    Public Enum StreamBitrate
        Auto
        Minimum
    End Enum

    Public Enum IRControlKey As Byte
        Power = CByte(1)
        PowerOn = CByte(2)
        PowerOff = CByte(3)
        ChannelUp = CByte(4)
        ChannelDown = CByte(5)
        VolumeUp = CByte(6)
        VolumeDown = CByte(7)
        Mute = CByte(8)
        Num_1 = CByte(9)
        Num_2 = CByte(10)
        Num_3 = CByte(11)
        Num_4 = CByte(12)
        Num_5 = CByte(13)
        Num_6 = CByte(14)
        Num_7 = CByte(15)
        Num_8 = CByte(16)
        Num_9 = CByte(17)
        Num_0 = CByte(18)
        Enter = CByte(19)
        Hundred = CByte(20)
        LastChannel = CByte(21)
        TvVcr = CByte(22)
        External = CByte(23)
        Play = CByte(24)
        [Stop] = CByte(25)
        Pause = CByte(26)
        Rewind = CByte(27)
        FastForward = CByte(28)
        Record = CByte(29)
        SkipForward = CByte(30)
        SkipBack = CByte(31)
        Live = CByte(32)
        Menu = CByte(33)
        Setup = CByte(34)
        Guide = CByte(35)
        Cancel = CByte(36)
        [Exit] = CByte(37)
        Up = CByte(38)
        Down = CByte(39)
        Left = CByte(40)
        Right = CByte(41)
        [Select] = CByte(42)
        PageUp = CByte(43)
        PageDown = CByte(44)
        Favorite = CByte(45)
        Info = CByte(46)
        Format = CByte(47)
        Subtitle = CByte(48)
        Surround = CByte(49)
        Slow = CByte(50)
        Eject = CByte(51)
        Random = CByte(52)
        Pip = CByte(53)
        PipFormat = CByte(54)
        PipFreeze = CByte(55)
        PipSwap = CByte(56)
        PipMove = CByte(57)
        PipSource = CByte(58)
        PipChanUp = CByte(59)
        PipChanDown = CByte(60)
        PipMulti = CByte(61)
        Custom10 = CByte(62)
        Custom11 = CByte(63)
        Custom12 = CByte(64)
        Custom13 = CByte(65)
        Custom14 = CByte(66)
        Custom15 = CByte(67)
        Custom16 = CByte(68)
        Custom17 = CByte(69)
        Custom18 = CByte(70)
        Custom19 = CByte(71)
        Custom20 = CByte(72)
        Custom21 = CByte(73)
        Red = CByte(74)
        Green = CByte(75)
        Yellow = CByte(76)
        Blue = CByte(77)
        White = CByte(78)
        Custom27 = CByte(79)
        Custom28 = CByte(80)
        Custom29 = CByte(81)
    End Enum

    Public Slingbox_Current As StructSlingboxInfo
    Public Slingbox_Edit As StructSlingboxInfo

End Module