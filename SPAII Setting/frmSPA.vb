Public Class frmSPA

    Public config As String = "modconfig.ini"

    Private Sub frmSPA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As Control In gbApt.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb = CType(ctrl, CheckBox)
                Try
                    cb.Checked = CBool(ReadIniValue(config, "APARTMENT", cb.Tag))
                Catch ex As Exception
                    cb.Checked = True
                End Try
            End If
        Next

        For Each ctrl As Control In gbGarage.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb = CType(ctrl, CheckBox)
                Try
                    cb.Checked = CBool(ReadIniValue(config, "APARTMENT", cb.Tag))
                Catch ex As Exception
                    cb.Checked = True
                End Try
            End If
        Next

        Try
            tbVolume.Value = CInt(ReadIniValue(config, "SOUND", "Volume"))
        Catch ex As Exception
            tbVolume.Value = 100
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For Each ctrl As Control In gbApt.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb = CType(ctrl, CheckBox)
                WriteIniValue(config, "APARTMENT", cb.Tag, cb.Checked)
            End If
        Next

        For Each ctrl As Control In gbGarage.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim cb = CType(ctrl, CheckBox)
                WriteIniValue(config, "APARTMENT", cb.Tag, cb.Checked)
            End If
        Next

        WriteIniValue(config, "SOUND", "Volume", tbVolume.Value)

        MsgBox("Settings saved.", MsgBoxStyle.Information, "SPA II")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
