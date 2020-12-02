Imports System.Reflection

Public Class FolderSelectDialog

    Dim ofd As OpenFileDialog = Nothing

    Public Sub New()
        ofd = New OpenFileDialog
        ofd.Filter = "Folders|\n"
        ofd.AddExtension = False
        ofd.CheckFileExists = False
        ofd.DereferenceLinks = True
        ofd.Multiselect = False
    End Sub

    Public Property InitialDirectory() As String
        Get
            Return ofd.InitialDirectory
        End Get
        Set(value As String)
            ofd.InitialDirectory = If(value Is Nothing OrElse value.Length = 0, Environment.CurrentDirectory, value)
        End Set
    End Property

    Public Property Title As String
        Get
            Return ofd.Title
        End Get
        Set(ByVal value As String)
            ofd.Title = If(value Is Nothing, "Select a folder", value)
        End Set
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return ofd.FileName
        End Get
    End Property

    Public Function ShowDialog() As Boolean
        Return ShowDialog(IntPtr.Zero)
    End Function

    Public Function ShowDialog(ByVal hWndOwner As IntPtr) As Boolean
        Dim flag As Boolean = False

        If Environment.OSVersion.Version.Major >= 6 Then
            Dim r = New Reflector("System.Windows.Forms")
            Dim num As UInteger = 0
            Dim typeIFileDialog As Type = r.[GetType]("FileDialogNative.IFileDialog")
            Dim dialog As Object = r.[Call](ofd, "CreateVistaDialog")
            r.[Call](ofd, "OnBeforeVistaDialog", dialog)
            Dim options As UInteger = CUInt(r.CallAs(GetType(System.Windows.Forms.FileDialog), ofd, "GetOptions"))
            options = options Or CUInt(r.GetEnum("FileDialogNative.FOS", "FOS_PICKFOLDERS"))
            r.CallAs(typeIFileDialog, dialog, "SetOptions", options)
            Dim pfde As Object = r.[New]("FileDialog.VistaDialogEvents", ofd)
            Dim parameters As Object() = New Object() {pfde, num}
            r.CallAs2(typeIFileDialog, dialog, "Advise", parameters)
            num = CUInt(parameters(1))

            Try
                Dim num2 As Integer = CInt(r.CallAs(typeIFileDialog, dialog, "Show", hWndOwner))
                flag = 0 = num2
            Finally
                r.CallAs(typeIFileDialog, dialog, "Unadvise", num)
                GC.KeepAlive(pfde)
            End Try
        Else
            Dim fbd = New FolderBrowserDialog()
            fbd.Description = Me.Title
            fbd.SelectedPath = Me.InitialDirectory
            fbd.ShowNewFolderButton = False
            If fbd.ShowDialog(New WindowWrapper(hWndOwner)) <> DialogResult.OK Then Return False
            ofd.FileName = fbd.SelectedPath
            flag = True
        End If

        Return flag
    End Function

End Class

Public Class Reflector
    Dim m_ns As String
    Dim m_asmb As Assembly

    Public Sub New(ns As String)
        Me.New(ns, ns)
    End Sub

    Public Sub New(an As String, ns As String)
        m_ns = ns
        m_asmb = Nothing
        For Each _an As AssemblyName In Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            If (_an.FullName.StartsWith(an)) Then
                m_asmb = Assembly.Load(_an)
                Exit For
            End If
        Next
    End Sub

    Public Overloads Function [GetType](ByVal typeName As String) As Type
        Dim type As Type = Nothing
        Dim names As String() = typeName.Split("."c)
        If names.Length > 0 Then type = m_asmb.[GetType](m_ns & "." & names(0))

        For i As Integer = 1 To names.Length - 1
            type = type.GetNestedType(names(i), BindingFlags.NonPublic)
        Next

        Return type
    End Function

    Public Function [New](ByVal name As String, ParamArray parameters As Object()) As Object
        Dim type As Type = [GetType](name)
        Dim ctorInfos As ConstructorInfo() = type.GetConstructors()

        For Each ci As ConstructorInfo In ctorInfos

            Try
                Return ci.Invoke(parameters)
            Catch
            End Try
        Next

        Return Nothing
    End Function

    Public Function [Call](ByVal obj As Object, ByVal func As String, ParamArray parameters As Object()) As Object
        Return Call2(obj, func, parameters)
    End Function

    Public Function Call2(ByVal obj As Object, ByVal func As String, ByVal parameters As Object()) As Object
        Return CallAs2(obj.[GetType](), obj, func, parameters)
    End Function

    Public Function CallAs(ByVal type As Type, ByVal obj As Object, ByVal func As String, ParamArray parameters As Object()) As Object
        Return CallAs2(type, obj, func, parameters)
    End Function

    Public Function CallAs2(ByVal type As Type, ByVal obj As Object, ByVal func As String, ByVal parameters As Object()) As Object
        Dim methInfo As MethodInfo = type.GetMethod(func, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
        Return methInfo.Invoke(obj, parameters)
    End Function

    Public Function [Get](ByVal obj As Object, ByVal prop As String) As Object
        Return GetAs(obj.[GetType](), obj, prop)
    End Function

    Public Function GetAs(ByVal type As Type, ByVal obj As Object, ByVal prop As String) As Object
        Dim propInfo As PropertyInfo = type.GetProperty(prop, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
        Return propInfo.GetValue(obj, Nothing)
    End Function

    Public Function GetEnum(ByVal typeName As String, ByVal name As String) As Object
        Dim type As Type = [GetType](typeName)
        Dim fieldInfo As FieldInfo = type.GetField(name)
        Return fieldInfo.GetValue(Nothing)
    End Function
End Class

Public Class WindowWrapper
    Implements System.Windows.Forms.IWin32Window

    Private ReadOnly _hwnd As IntPtr

    Public Sub New(handle As IntPtr)
        _hwnd = handle
    End Sub


    Public ReadOnly Property Handle As System.IntPtr Implements System.Windows.Forms.IWin32Window.Handle
        Get
            Return _hwnd
        End Get
    End Property
End Class