Imports System
Imports System.Text
Imports System.Collections
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Public Class IniReader

    Private Declare Ansi Function GetPrivateProfileInt Lib "kernel32.dll" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Ansi Function WritePrivateProfileSection Lib "kernel32.dll" Alias "WritePrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Public Sub New(ByVal file As String)
        Filename = file
    End Sub

    Public Property Filename() As String
        Get
            Return m_Filename
        End Get
        Set(ByVal Value As String)
            m_Filename = Value
        End Set
    End Property

    Public Function ReadInteger(ByVal section As String, ByVal key As String, ByVal defVal As Integer) As Integer
        Return GetPrivateProfileInt(section, key, defVal, Filename)
    End Function
    Public Function ReadKeyCode(ByVal section As String, ByVal key As String, ByRef keycode As Keys) As Keys
        Dim defval As Integer = keycode
        Dim i As Integer = GetPrivateProfileInt(section, key, defval, Filename)
        i = GetValidKey(i)
        If i > 0 Then
            Return CType(i, Keys)
        End If
        Return Keys.None
    End Function

    Public Sub ReadSetKeyCode(ByVal section As String, ByVal key As String, ByRef keycode As Keys)
        Dim defval As Integer = keycode
        Dim i As Integer = GetPrivateProfileInt(section, key, defval, Filename)
        i = GetValidKey(i)
        If i > 0 Then
            keycode = CType(i, Keys)
        End If
    End Sub
    Public Function GetValidKey(ky As Integer) As Integer

        Dim k As Keys
        Try
            k = CType(ky, Keys)
            Return k
        Catch ex As Exception

        End Try

    End Function

    Public Function ReadInteger(ByVal section As String, ByVal key As String) As Integer
        Return ReadInteger(section, key, 0)
    End Function

    Public Function ReadString(ByVal section As String, ByVal key As String, ByVal defVal As String) As String
        Dim sb As New StringBuilder(MAX_ENTRY)
        Dim Ret As Integer = GetPrivateProfileString(section, key, defVal, sb, MAX_ENTRY, Filename)
        Return sb.ToString()
    End Function
    Public Function ReadStringLong(ByVal section As String, ByVal key As String, ByVal defVal As String) As String
        Dim sb As New StringBuilder(MAX_ENTRY_LONG)
        Dim Ret As Integer = GetPrivateProfileString(section, key, defVal, sb, MAX_ENTRY_LONG, Filename)
        Return sb.ToString()
    End Function

    Public Function ReadString(ByVal section As String, ByVal key As String) As String
        Return ReadString(section, key, "")
    End Function

    Public Function ReadLong(ByVal section As String, ByVal key As String, ByVal defVal As Long) As Long
        Return Long.Parse(ReadString(section, key, defVal.ToString()))
    End Function

    Public Function ReadBoolean(ByVal section As String, ByVal key As String, ByVal defVal As Boolean) As Boolean
        Return Boolean.Parse(ReadString(section, key, defVal.ToString()))
    End Function

    Public Function ReadBoolean(ByVal section As String, ByVal key As String) As Boolean
        Return ReadBoolean(section, key, False)
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value As Integer) As Boolean
        Return Write(section, key, value.ToString())
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value As String) As Boolean
        Return (WritePrivateProfileString(section, key, value, Filename) <> 0)
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value As Long) As Boolean
        Return Write(section, key, value.ToString())
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value() As Byte) As Boolean
        If value Is Nothing Then
            Return Write(section, key, CType(Nothing, String))
        Else
            Return Write(section, key, value, 0, value.Length)
        End If
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value() As Byte, ByVal offset As Integer, ByVal length As Integer) As Boolean
        If value Is Nothing Then
            Return Write(section, key, CType(Nothing, String))
        Else
            Return Write(section, key, Convert.ToBase64String(value, offset, length))
        End If
    End Function

    Public Function Write(ByVal section As String, ByVal key As String, ByVal value As Boolean) As Boolean
        Return Write(section, key, value.ToString())
    End Function

    Private m_Filename As String

    Private m_Section As String

    Private Const MAX_ENTRY As Integer = 22768
    Private Const MAX_ENTRY_LONG As Integer = 67768
End Class