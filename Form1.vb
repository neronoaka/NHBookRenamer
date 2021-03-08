Imports System.IO
Imports Newtonsoft.Json

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ps As String() = Directory.GetDirectories(TextBox1.Text)
        For Each p As String In ps
            TextBox2.Text += p
            Try
                Dim jsonstr As String = File.ReadAllText(p & "\book.json", System.Text.Encoding.UTF8)
                Dim bk As Book = JsonConvert.DeserializeObject(Of Book)(jsonstr)
                Dim artist As String = Nothing
                For Each art As String In bk.artistsID
                    artist += art & "-"
                Next
                Dim name As String = Directory.GetParent(p).FullName & "\" & artist & rep(bk.titleJP)
                Directory.Move(p, name)
                TextBox2.Text += "[OK]" & vbCrLf
            Catch ex As Exception
                TextBox2.Text += "[ERR]" & ex.Message & vbCrLf
            End Try

        Next

    End Sub
    Private Function rep(ByVal s As String) As String
        Dim un As String() = {"/", "\", "*", "?", ":", "<", ">", "|", """", "？", "：", " ", "[中国翻訳]", "[DL版]"}
        For Each u As String In un
            s = s.Replace(u, Nothing)
        Next
        Return s
    End Function
End Class