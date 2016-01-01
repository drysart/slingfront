Imports System.Net

Public Class CookieAwareWebClient
    Inherits WebClient

    Private cc As New CookieContainer()

    Private lastPage As String

    Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
        Dim R As WebRequest = MyBase.GetWebRequest(address)
        If TypeOf R Is HttpWebRequest Then
            With DirectCast(R, HttpWebRequest)

                .CookieContainer = cc
                .AllowAutoRedirect = True
                .UseDefaultCredentials = True
                .Method = "post"
                .UnsafeAuthenticatedConnectionSharing = True
                If Not lastPage Is Nothing Then

                End If
            End With
        End If
        lastPage = address.ToString()
        Return DirectCast(R, HttpWebRequest)
    End Function
End Class