Public Class frmSPA

    Public config As String = "modconfig.ini"
    Public cutProp() As Integer = {82, 88, 91, 93}
    Public iplProp() As Integer = {79, 80, 81}

    Private Sub frmSPA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Apartment toggle
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

        'Load Garage toggle
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

        'Load Volume
        Try
            tbVolume.Value = CInt(ReadIniValue(config, "SOUND", "Volume"))
        Catch ex As Exception
            tbVolume.Value = 100
        End Try

        'Load Settings
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
        Try
            cbDebug.Checked = CBool(ReadIniValue(config, "SETTING", "DebugMode"))
        Catch ex As Exception
            cbDebug.Checked = False
        End Try

        'Load Vehicle Transfers
        txtSPA1.Text = IO.Path.GetFullPath("..\SinglePlayerApartment\Garage")
        txtSPA2.Text = $"{My.Application.Info.DirectoryPath}\Garages"
        cmbSPA1.Items.AddRange(SPA1Property.Values.ToArray)
        For Each item In SPA2Property
            cmbSPA2.Items.Add(item.Value(0))
        Next

        'Load Properties Editor
        cmbPropOwner.Items.AddRange({"Nobody", "Michael", "Franklin", "Trevor", "Others"})
        cmbPropStyle.Items.AddRange(AptStyleDic.Keys.ToArray)
        For i As Integer = 1 To 95
            If Not cutProp.Contains(i) Then
                Dim gxt As String = $"MP_PROP_{i}"
                Dim dict = BuildingDic.Where(Function(x) x.Value = gxt).FirstOrDefault
                Dim owner = ReadIniValue(config, "BUILDING", gxt)
                If owner = "" Then owner = "Nobody"
                Dim ipl As String = "N/A"
                If iplProp.Contains(i) Then ipl = ConvertAptStyle(ReadIniValue(config, "IPL", gxt))
                If ipl = "" Then ipl = "Modern"
                Dim item As New ListViewItem(dict.Key)
                With item
                    .SubItems.Add(gxt)
                    .SubItems.Add(owner)
                    .SubItems.Add(ipl)
                    .Tag = New Tuple(Of String, String, String, String, Integer)(dict.Key, dict.Value, owner, ipl, i)
                End With
                lvBuilding.Items.Add(item)
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim gotError As Boolean = False
        Dim errorTuple As Tuple(Of String, String, String, String, Integer) = Nothing
        Try
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
            WriteIniValue(config, "SETTING", "DebugMode", cbDebug.Checked)

            For Each item As ListViewItem In lvBuilding.Items
                Dim itemTag As Tuple(Of String, String, String, String, Integer) = item.Tag
                errorTuple = item.Tag
                WriteIniValue(config, "BUILDING", itemTag.Item2, itemTag.Item3)
                Select Case itemTag.Item5
                    Case 79, 80, 81
                        WriteIniValue(config, "IPL", itemTag.Item2, GetAptStyle(itemTag.Item4, itemTag.Item5))
                End Select
            Next
        Catch ex As Exception
            gotError = True
            MsgBox($"{errorTuple}{ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        Finally
            If Not gotError Then MsgBox("Settings saved.", MsgBoxStyle.Information, "SPA II")
        End Try
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

                    MsgBox("Transfer is not fully complete yet, for fully functional, please drive out of the garage and drive back in, otherwise some features might not working properly.", MsgBoxStyle.Exclamation, "TRANSFER")
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

    Private Sub lvBuilding_DoubleClick(sender As Object, e As EventArgs) Handles lvBuilding.DoubleClick
        If lvBuilding.SelectedItems.Count <> 0 Then
            Dim selectedItem As ListViewItem = lvBuilding.SelectedItems(0)
            Dim selectedProp As Tuple(Of String, String, String, String, Integer) = selectedItem.Tag
            gbPropEdit.Enabled = True
            txtPropName.Text = selectedProp.Item1
            txtPropIntName.Text = selectedProp.Item2
            cmbPropOwner.SelectedItem = selectedProp.Item3
            Select Case selectedProp.Item5
                Case 79, 80, 81
                    cmbPropStyle.Enabled = True
                    cmbPropStyle.SelectedItem = selectedProp.Item4
                Case Else
                    cmbPropStyle.Enabled = False
            End Select
            btnPropApply.Tag = selectedItem
        End If
    End Sub

    Private Sub btnPropApply_Click(sender As Object, e As EventArgs) Handles btnPropApply.Click
        If Not btnPropApply.Tag Is Nothing Then
            Dim selectedItem As ListViewItem = btnPropApply.Tag
            Dim selectedProp As Tuple(Of String, String, String, String, Integer) = selectedItem.Tag
            With selectedItem
                .SubItems(2).Text = cmbPropOwner.SelectedItem
                If cmbPropStyle.Enabled Then .SubItems(3).Text = cmbPropStyle.SelectedItem
                .Tag = New Tuple(Of String, String, String, String, Integer)(selectedProp.Item1, selectedProp.Item2, cmbPropOwner.SelectedItem, If(cmbPropStyle.Enabled, cmbPropStyle.SelectedItem, "N/A"), selectedProp.Item5)
            End With
            btnPropCancel.PerformClick()
        End If
    End Sub

    Private Sub btnPropCancel_Click(sender As Object, e As EventArgs) Handles btnPropCancel.Click
        btnPropApply.Tag = Nothing
        txtPropIntName.Clear()
        txtPropName.Clear()
        cmbPropOwner.SelectedIndex = -1
        cmbPropStyle.SelectedIndex = -1
        gbPropEdit.Enabled = False
    End Sub
End Class
