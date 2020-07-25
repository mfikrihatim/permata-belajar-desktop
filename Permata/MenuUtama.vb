﻿Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class MenuUtama
    Private Sub btnkelas0_Click(sender As Object, e As EventArgs) Handles btnkelas0.Click
        ShowFeature(Integer.Parse(Me.btnkelas0.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnkelas1.Click
        ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnkelas2.Click
        ShowFeature(Integer.Parse(Me.btnkelas2.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnkelas3.Click
        ShowFeature(Integer.Parse(Me.btnkelas3.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnkelas4.Click
        ShowFeature(Integer.Parse(Me.btnkelas4.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnkelas5.Click
        ShowFeature(Integer.Parse(Me.btnkelas5.Tag))
        Panel5.Visible = True

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles btnkelas6.Click
        ShowFeature(Integer.Parse(Me.btnkelas6.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles btnkelas7.Click
        ShowFeature(Integer.Parse(Me.btnkelas7.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnkelas8.Click
        ShowFeature(Integer.Parse(Me.btnkelas8.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles btnkelas9.Click
        ShowFeature(Integer.Parse(Me.btnkelas9.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles btnkelas10.Click
        ShowFeature(Integer.Parse(Me.btnkelas10.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Lainnya.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnfeature0.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
            Case "sbmptnPages"
                'ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
            Case "videoPages"
                Form2.Show()
                'Case Me.btnkelas3.Tag
                '    ShowFeature(Integer.Parse(Me.btnkelas3.Tag))

        End Select
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnfeature1.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
            Case "sbmptnPages"
                'ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
            Case "videoPages"
                Form2.Show()
                'Case Me.btnkelas3.Tag
                '    ShowFeature(Integer.Parse(Me.btnkelas3.Tag))

        End Select
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btnfeature2.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
            Case "sbmptnPages"
                'ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
            Case "videoPages"
                Form2.Show()
                'Case Me.btnkelas3.Tag
                '    ShowFeature(Integer.Parse(Me.btnkelas3.Tag))

        End Select
        Me.Hide()
    End Sub
    Public Function GetKelas() As List(Of Kelas)
        Dim result As New List(Of Kelas)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/kelas")
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of KelasResponse)(response)
            For Each item As ResultKelas In responseConvert.Data.Result
                For Each itemKelas As DataResultKelas In item.Data
                    Dim kelas As New Kelas
                    With kelas
                        .Id_Kelas = itemKelas.Id_Kelas
                        .Kelas = itemKelas.Kelas
                        .Icon = itemKelas.Icon
                        .Image = itemKelas.Image
                    End With
                    result.Add(kelas)
                Next
                'Do something with "item" here
            Next
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

    Public Function GetFeatureByKelasId(kelasId As Integer) As List(Of Feature)
        Dim result As New List(Of Feature)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/feature?id_kelas=" + kelasId.ToString())
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of FeatureResponse)(response)
            For Each item As FeatureWithPage In responseConvert.Data.Feature
                For Each itemFeature As Feature In item.Data
                    Dim feature As New Feature
                    With feature
                        .Id_Feature = itemFeature.Id_Feature
                        .Feature = itemFeature.Feature
                        .Pages = itemFeature.Pages
                        .Icon = itemFeature.Icon
                        .Background = itemFeature.Background
                        .Image = itemFeature.Image
                        .Active = itemFeature.Active
                    End With
                    result.Add(feature)
                Next
                'Do something with "item" here
            Next
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

    Public Function ShowKelas()
        Dim DataKelas As List(Of Kelas) = GetKelas()
        Dim lastIndex As Integer = 0
        For i As Integer = 0 To DataKelas.Count
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)


            Try

                kelasLabel.FirstOrDefault().Text = DataKelas(i).Kelas
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(DataKelas(i).Image)))
                kelasButton.FirstOrDefault().BackgroundImage = downloadImage
                kelasButton.FirstOrDefault().Tag = DataKelas(i).Id_Kelas
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i
        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To DataKelas.Count + 1
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()
            'End If
        Next
    End Function

    Public Function ShowFeature(kelasId As Integer)
        Dim Datafeature As List(Of Feature) = GetFeatureByKelasId(kelasId)
        Dim lastIndex As Integer = 0
        For i As Integer = 0 To Datafeature.Count
            Dim featureButton As Control() = Me.Controls.Find("btnfeature" + i.ToString(), True)

            Dim featureLabel As Control() = Me.Controls.Find("lblfeature" + i.ToString(), True)


            Try
                Dim buttonFeature As Guna.UI2.WinForms.Guna2Button = CType(featureButton.FirstOrDefault(), Guna.UI2.WinForms.Guna2Button)
                featureLabel.FirstOrDefault().Text = Datafeature(i).Feature
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(Datafeature(i).Image)))
                buttonFeature.Image = downloadImage
                featureButton.FirstOrDefault().Tag = Datafeature(i).Pages
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i
        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To Datafeature.Count + 1
            If lastIndex <> Datafeature.Count Then
                Dim featureButton As Control() = Me.Controls.Find("btnfeature" + i.ToString(), True)

                Dim featureLabel As Control() = Me.Controls.Find("lblfeature" + i.ToString(), True)


                featureButton.FirstOrDefault().Hide()
                featureLabel.FirstOrDefault().Hide()
            End If
        Next
    End Function

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ShowKelas()
    End Sub

    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        'Dim BT As Button = CType(sender, Button)
        'Select Case BT.Tag
        '    Case Me.btnkelas0.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas0.Tag))
        '    Case Me.btnkelas1.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
        '    Case Me.btnkelas2.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas2.Tag))
        '    Case Me.btnkelas3.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas3.Tag))
        '    Case Me.btnkelas4.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas4.Tag))
        '    Case Me.btnkelas5.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas5.Tag))
        '    Case Me.btnkelas6.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas6.Tag))
        '    Case Me.btnkelas7.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas7.Tag))
        '    Case Me.btnkelas8.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas8.Tag))
        '    Case Me.btnkelas9.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas9.Tag))
        '    Case Me.btnkelas10.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas10.Tag))
        '    Case Me.btnkelas11.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas11.Tag))
        '    Case Me.btnkelas12.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas12.Tag))
        '    Case Me.btnkelas13.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas13.Tag))
        '    Case Me.btnkelas14.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas14.Tag))
        'End Select
    End Sub

    Private Sub btnkelas11_Click(sender As Object, e As EventArgs) Handles btnkelas11.Click
        ShowFeature(Integer.Parse(Me.btnkelas11.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas12_Click(sender As Object, e As EventArgs) Handles btnkelas12.Click
        ShowFeature(Integer.Parse(Me.btnkelas12.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas13_Click(sender As Object, e As EventArgs) Handles btnkelas13.Click
        ShowFeature(Integer.Parse(Me.btnkelas13.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas14_Click(sender As Object, e As EventArgs) Handles btnkelas14.Click
        ShowFeature(Integer.Parse(Me.btnkelas14.Tag))
        Panel5.Visible = True
    End Sub

    Private Sub btnfeature3_Click(sender As Object, e As EventArgs) Handles btnfeature3.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
            Case "sbmptnPages"
                'ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
            Case "videoPages"
                Form2.Show()
                'Case Me.btnkelas3.Tag
                '    ShowFeature(Integer.Parse(Me.btnkelas3.Tag))

        End Select
    End Sub
End Class