﻿Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Signin
    Public Function Login(username As String, password As String) As LoginResponse
        Dim result As New LoginResponse
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/auth/login/pelanggan?username=" + username + "&password=" + password)
        myrequest.Method = "POST"
        'myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of LoginResponse)(response)
            result = responseConvert
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try
        Return result
    End Function

    Public Function GetInfoPelanggan(IdPelanggan As String)
        Dim result As New PelangganResponse
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/auth/user/pelanggan?id_pelanggan=" + IdPelanggan)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of PelangganResponse)(response)
            result = responseConvert
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try
        Return result
    End Function
    Public Function ShowMenuUtama(pelanggan As Pelanggan, pelangganId As String)
        MenuUtama.Show()
        Dim tClient As WebClient = New WebClient
        Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(pelanggan.Foto)))
        MenuUtama.Label13.Text = pelanggan.Nama
        MenuUtama.Guna2PictureBox3.Image = downloadImage
        MenuUtama.Guna2PictureBox3.Tag = pelangganId
        MenuUtama.Label26.Text = ""
        Lainnya.Label13.Text = pelanggan.Nama
        Lainnya.Guna2PictureBox3.Image = downloadImage
        'Guna2PictureBox1.Image
    End Function
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim usernameText As Control() = Me.Controls.Find("Guna2TextBox1", True)
        Dim passwordText As Control() = Me.Controls.Find("Guna2TextBox2", True)

        Dim usernameGuna As Guna.UI2.WinForms.Guna2TextBox = CType(usernameText.FirstOrDefault(), Guna.UI2.WinForms.Guna2TextBox)
        Dim passwordGuna As Guna.UI2.WinForms.Guna2TextBox = CType(passwordText.FirstOrDefault(), Guna.UI2.WinForms.Guna2TextBox)

        Dim username As String = usernameGuna.Text
        Dim password As String = passwordGuna.Text
        Dim checkUser As LoginResponse = Login(username, password)
        If checkUser.Status = "true" Then
            Dim getPelanggan As PelangganResponse = GetInfoPelanggan(checkUser.CekEmail.Id_Pelanggan)
            ShowMenuUtama(getPelanggan.Data, checkUser.CekEmail.Id_Pelanggan)
            Me.Hide()
        Else
            MsgBox("Email dan Password Salah!")
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If Guna2TextBox2.UseSystemPasswordChar = True Then
            Guna2TextBox2.UseSystemPasswordChar = False
            Guna2Button5.Text = "Show"
        Else
            Guna2TextBox2.UseSystemPasswordChar = True
            Guna2Button5.Text = "Hide"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://permatabelajar.com/registrasi")
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        'LoginGoogle.Show()
        MsgBox("Login By Google Hanya bisa dilakukan di web app saja")
        System.Diagnostics.Process.Start("https://permatabelajar.com/registrasi")
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        'LoginFacebook.Show()
        MsgBox("Login By Facebook Hanya bisa dilakukan di web app saja")
        System.Diagnostics.Process.Start("https://permatabelajar.com/registrasi")
    End Sub
End Class