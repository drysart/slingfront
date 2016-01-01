Imports System
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Reflection

Public Class SYC

    Public Enum SymmProvEnum : int
        DES
        RC2
        Rijndael
    End Enum

    Private mobjCryptoService As SymmetricAlgorithm

    Public Function EncryptCode1(ByVal S As String) As String
        Return Me.E(S, "43ewE5H")
    End Function

    Public Function DecryptCode1(ByVal S As String) As String
        Return Me.D(S, "43ewE5H")
    End Function

    Public Function EncryptCode2(ByVal S As String) As String
        Return Me.E(S, "25GEed2T")
    End Function

    Public Function DecryptCode2(ByVal S As String) As String
        Return Me.D(S, "25GEed2T")
    End Function

    Public Function EncryptCode3(ByVal S As String) As String

        Return Me.E(S, "232TfSSa")
    End Function

    Public Function DecryptCode3(ByVal S As String) As String

        Return Me.D(S, "232TfSSa")

    End Function

    Public Function EncryptCode4(ByVal S As String) As String

        Return Me.E(S, "re5Rtip3")
    End Function

    Public Function DecryptCode4(ByVal S As String) As String

        Return Me.D(S, "re5Rtip3")

    End Function

    Public Sub SYC(ByVal NetSelected As SymmProvEnum)
        Select Case (NetSelected)
            Case SymmProvEnum.DES
                mobjCryptoService = New DESCryptoServiceProvider
            Case SymmProvEnum.RC2
                mobjCryptoService = New RC2CryptoServiceProvider
            Case SymmProvEnum.Rijndael
                mobjCryptoService = New RijndaelManaged
        End Select
    End Sub

    Private Function GetLegalKey(ByVal Key As String) As Byte()
        Dim sTemp As String
        If (mobjCryptoService.LegalKeySizes.Length > 0) Then

            Dim lessSize As Integer = 0
            Dim moreSize As Integer = mobjCryptoService.LegalKeySizes(0).MinSize

            Do While (Key.Length * 8 > moreSize)
                lessSize = moreSize
                moreSize += mobjCryptoService.LegalKeySizes(0).SkipSize
            Loop
            sTemp = Key.PadRight(CInt(moreSize / 8), CChar(" "))
        Else
            sTemp = Key
        End If

        Return ASCIIEncoding.ASCII.GetBytes(sTemp)
    End Function
    Public Function GetByteStringFromString(ByVal Str As String) As String
        Dim i As Integer
        Dim buildstring As String = ""
        For i = 1 To Len(Str)
            buildstring = buildstring & Microsoft.VisualBasic.Right("000" & Trim(CStr(Asc(Mid(Str, i, 1)))), 3)
            If Not i = Len(Str) Then buildstring = buildstring & ";"
        Next
        Return buildstring
    End Function
    Public Function GetStringFromByteString(ByVal Str As String) As String
        Dim i As Integer
        Dim rsltstring As String = ""
        If Str = "" Then Return ""
        If Not InStr(Str, ";") > 0 Then
            If IsNumeric(Str) Then
                If CInt(Str) >= 0 And CInt(Str) < 257 Then
                    Return Chr(CInt(Str))
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        Else
            Dim splitstr() As String
            splitstr = Split(Str, ";")
            For i = 0 To UBound(splitstr)
                rsltstring = rsltstring & Chr(CInt(splitstr(i)))
            Next
            Return rsltstring
        End If
    End Function
    Public Function E(ByVal Source As String, ByVal Key As String) As String
        If Source = "" Then Return ""
        Source += "EE3:AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Dim bytIn As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(Source)

        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream

        Dim bytKey As Byte() = GetLegalKey(Key)

        mobjCryptoService.Key = bytKey
        mobjCryptoService.IV = bytKey

        Dim encrypto As ICryptoTransform = mobjCryptoService.CreateEncryptor()

        Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Write)

        cs.Write(bytIn, 0, bytIn.Length)
        cs.FlushFinalBlock()

        Dim bytOut As Byte() = ms.GetBuffer
        Dim i As Integer = 0
        For i = bytOut.Length - 1 To 0 Step -1
            If (bytOut(i) <> 0) Then
                Exit For
            End If
        Next i

        Return "EE3:" + System.Convert.ToBase64String(bytOut, 0, i + 1)
    End Function

    Public Function D(ByVal Source As String, ByVal Key As String) As String
        If Source = "" Then Return ""
        If Not InStr(Source, "EE3:") > 0 Or Len(Source) < 5 Then
            Return Source
        End If
        Source = Split(Source, "EE3:")(1)
        Try
            Dim bytIn As Byte() = System.Convert.FromBase64String(Source)

            Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(bytIn, 0, bytIn.Length)

            Dim bytKey As Byte() = GetLegalKey(Key)

            mobjCryptoService.Key = bytKey
            mobjCryptoService.IV = bytKey

            Dim encrypto As ICryptoTransform = mobjCryptoService.CreateDecryptor()

            Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Read)

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(cs)
            Dim bb As String = sr.ReadToEnd
            Return Split(bb, "EE3:")(0)

        Catch ex As Exception
            Return ""

            'Sleep(3)
            'Dim bytIn As Byte() = System.Convert.FromBase64String(Source)

            'Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(bytIn, 0, bytIn.Length)

            'Dim bytKey As Byte() = GetLegalKey(Key)

            'mobjCryptoService.Key = bytKey
            'mobjCryptoService.IV = bytKey

            'Dim encrypto As ICryptoTransform = mobjCryptoService.CreateDecryptor()

            'Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Read)

            'Dim sr As System.IO.StreamReader = New System.IO.StreamReader(cs)
            'Dim bb As String = sr.ReadToEnd
            'Return Split(bb, "EE3:")(0)
        End Try
    End Function
End Class