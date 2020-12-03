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

        Try
            cbOnlineMap.Checked = CBool(ReadIniValue(config, "SETTING", "OnlineMap"))
        Catch ex As Exception
            cbOnlineMap.Checked = True
        End Try

        Try
            cbMission.Checked = CBool(ReadIniValue(config, "SETTING", "HideBlipsOnMission"))
        Catch ex As Exception
            cbMission.Checked = True
        End Try

        txtSPA1.Text = IO.Path.GetFullPath("..\SinglePlayerApartment\Garage")
        txtSPA2.Text = $"{My.Application.Info.DirectoryPath}\Garages"
        cmbSPA1.Items.AddRange(SPA1Property.Values.ToArray)
        For Each item In SPA2Property
            cmbSPA2.Items.Add(item.Value(0))
        Next
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
        WriteIniValue(config, "SETTING", "OnlineMap", cbOnlineMap.Checked)
        WriteIniValue(config, "SETTING", "HideBlipsOnMission", cbMission.Checked)

        MsgBox("Settings saved.", MsgBoxStyle.Information, "SPA II")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub cmbSPA1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSPA1.SelectedIndexChanged
        SPA1Load()
    End Sub

    Private Sub cmbSPA2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSPA2.SelectedIndexChanged
        SPA2Load()
    End Sub

    Private Sub SPA1Load()
        Try
            lvSPA1.Items.Clear()
            Dim selectedItem As String = $"{txtSPA1.Text}\{SPA1Property.Where(Function(x) x.Value = cmbSPA1.SelectedItem).FirstOrDefault.Key}"
            If Not IO.Directory.Exists(selectedItem) Then IO.Directory.CreateDirectory(selectedItem)

            For Each file As String In IO.Directory.GetFiles(selectedItem, "*.cfg")
                Dim item As New ListViewItem(ReadCfgValue(Of String)("VehicleName", file))
                With item
                    .SubItems.Add(ReadCfgValue(Of String)("PlateNumber", file))
                    .SubItems.Add(IO.Path.GetFileName(file))
                    .Tag = file
                End With
                lvSPA1.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox($"{ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        End Try
    End Sub

    Private Sub SPA2Load()
        Try
            lvSPA2.Items.Clear()
            Dim selectedItem As String = $"{txtSPA2.Text}\{SPA2Property.Where(Function(x) x.Value(0) = cmbSPA2.SelectedItem).FirstOrDefault.Key}"
            If Not IO.Directory.Exists(selectedItem) Then IO.Directory.CreateDirectory(selectedItem)

            For Each file As String In IO.Directory.GetFiles(selectedItem, "*.xml")
                Dim vd As VehicleData = New VehicleData(file).Instance
                Dim item As New ListViewItem($"{vd.Make} {vd.Name}")
                With item
                    .SubItems.Add(vd.PlateNumber)
                    .SubItems.Add(IO.Path.GetFileName(file))
                    .Tag = file
                End With
                lvSPA2.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox($"{ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        End Try
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        Try
            If lvSPA1.SelectedItems.Count = 0 Then
                MsgBox("Please select at least 1 vehicle to transfer.", MsgBoxStyle.Exclamation, "ERR")
            ElseIf cmbSPA1.SelectedIndex = -1 OrElse cmbSPA2.SelectedIndex = -1 Then
                MsgBox("Please select garage.", MsgBoxStyle.Exclamation, "ERR")
            Else
                Dim spa2 = SPA2Property.Where(Function(x) x.Value(0) = cmbSPA2.SelectedItem).FirstOrDefault
                Dim spa2Path = spa2.Key
                Dim spa2Garage = spa2.Value
                Dim spa2PropName = spa2Garage(0)
                Dim spa2GarageSize As Integer = spa2Garage(1)
                Dim spa2PropertyID As Integer = spa2Garage(2)
                Dim selectedCount As Integer = lvSPA1.SelectedItems.Count
                Dim spa2GarageVehCount As Integer = lvSPA2.Items.Count
                Dim spaceLeft As Integer = spa2GarageSize - (spa2GarageVehCount - selectedCount)

                If spaceLeft >= selectedCount Then
                    For Each item As ListViewItem In lvSPA1.SelectedItems
                        Dim spa1File As String = item.Tag
                        Dim spa2Veh As New VehicleData(spa2Path, spa1File, GetAvailableIndex(Vehicles($"{txtSPA2.Text}\{spa2Path}"), spa2GarageSize), spa2PropertyID)
                        spa2Veh.Save()
                        If IO.File.Exists(spa1File) Then IO.File.Delete(spa1File)
                    Next

                    SPA1Load()
                    SPA2Load()
                Else
                    MsgBox("Your garage is full, cannot perform this action", MsgBoxStyle.Exclamation, "ERR_GRG_FULL")
                End If
            End If
        Catch ex As Exception
            MsgBox($"{ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        End Try
    End Sub

    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        Dim fsd = New FolderSelectDialog() With {.Title = "Select Garage Directory...", .InitialDirectory = txtSPA1.Text}
        If fsd.ShowDialog(IntPtr.Zero) Then txtSPA1.Text = fsd.FileName
    End Sub

    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        Dim fsd = New FolderSelectDialog() With {.Title = "Select Garage Directory...", .InitialDirectory = txtSPA2.Text}
        If fsd.ShowDialog(IntPtr.Zero) Then txtSPA2.Text = fsd.FileName
    End Sub
End Class
