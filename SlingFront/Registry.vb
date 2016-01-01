Imports Microsoft.Win32

Public Class CRegistry
    Public Enum RootKey
        HKEY_CURRENT_USER = 0
        HKEY_LOCAL_MACHINE = 1
        HKEY_CLASSES_ROOT = 2
        HKEY_USERS = 3
        HKEY_CURRENT_CONFIG = 4
    End Enum

    Public Function GetValueString(ByVal Key As RootKey, ByVal SubKey As String, ByVal Entry As String, ByVal DefaultValue As String) As String
        Dim reg As RegistryKey

        Try
            Select Case Key
                Case RootKey.HKEY_CURRENT_USER : reg = Registry.CurrentUser.OpenSubKey(SubKey)
                Case RootKey.HKEY_LOCAL_MACHINE : reg = Registry.LocalMachine.OpenSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey)
                Case RootKey.HKEY_CURRENT_CONFIG : reg = Registry.CurrentConfig.OpenSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey)
            End Select
            Return reg.GetValue(Entry, DefaultValue).ToString
        Catch ex As System.Exception
            Return DefaultValue
        End Try
    End Function

    Public Function GetValueInteger(ByVal Key As RootKey, ByVal SubKey As String, ByVal Entry As String, ByVal DefaultValue As Integer) As Integer
        Dim reg As RegistryKey

        Try
            Select Case Key
                Case RootKey.HKEY_CURRENT_USER : reg = Registry.CurrentUser.OpenSubKey(SubKey)
                Case RootKey.HKEY_LOCAL_MACHINE : reg = Registry.LocalMachine.OpenSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey)
                Case RootKey.HKEY_CURRENT_CONFIG : reg = Registry.CurrentConfig.OpenSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey)
            End Select
            Return CInt(reg.GetValue(Entry, DefaultValue))
        Catch ex As System.Exception
            Return DefaultValue
        End Try
    End Function

    Public Function CreateKey(ByVal Key As RootKey, _
          ByVal SubKey As String) As Boolean
        Dim reg As RegistryKey

        Try
            Select Case Key
                Case RootKey.HKEY_CURRENT_USER : reg = Registry.CurrentUser.CreateSubKey(SubKey)
                Case RootKey.HKEY_LOCAL_MACHINE : reg = Registry.LocalMachine.CreateSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.CreateSubKey(SubKey)
                Case RootKey.HKEY_CURRENT_CONFIG : reg = Registry.CurrentConfig.CreateSubKey(SubKey)
                Case RootKey.HKEY_USERS : reg = Registry.Users.CreateSubKey(SubKey)
            End Select
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function
    Public Function SetValue(ByVal Key As RootKey, _
      ByVal SubKey As String, ByVal Item As String, _
      ByVal Value As Object, ByVal CreateIfNotExist As Boolean) As Boolean
        Dim reg As RegistryKey

        Try
            Select Case Key
                Case RootKey.HKEY_CURRENT_USER : reg = Registry.CurrentUser.OpenSubKey(SubKey, True)
                Case RootKey.HKEY_LOCAL_MACHINE : reg = Registry.LocalMachine.OpenSubKey(SubKey, True)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey, True)
                Case RootKey.HKEY_CURRENT_CONFIG : reg = Registry.CurrentConfig.OpenSubKey(SubKey, True)
                Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey, True)
            End Select
        Catch
            If CreateIfNotExist Then
                If Not Me.CreateKey(Key, SubKey) Then

                    Return False
                Else
                    Try
                        Select Case Key
                            Case RootKey.HKEY_CURRENT_USER : reg = Registry.CurrentUser.OpenSubKey(SubKey, True)
                            Case RootKey.HKEY_LOCAL_MACHINE : reg = Registry.LocalMachine.OpenSubKey(SubKey, True)
                            Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey, True)
                            Case RootKey.HKEY_CURRENT_CONFIG : reg = Registry.CurrentConfig.OpenSubKey(SubKey, True)
                            Case RootKey.HKEY_USERS : reg = Registry.Users.OpenSubKey(SubKey, True)
                        End Select
                    Catch
                        Return False
                    End Try
                End If
            Else
                Return False
            End If
        End Try
        Try

            reg.SetValue(Item, Value)
            reg.Close()
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function
End Class