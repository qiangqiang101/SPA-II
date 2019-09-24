Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text

Public Module ReadMemory

    Public Delegate Function GetModelInfoDelegate(modelHash As Integer, indexPtr As IntPtr) As IntPtr

    Dim address As IntPtr = FindPattern("0F B7 05 ?? ?? ?? ?? 45 33 C9 4C 8B DA 66 85 C0 0F 84 ?? ?? ?? ?? 44 0F B7 C0 33 D2 8B C1 41 F7 F0 48 8B 05 ?? ?? ?? ?? 4C 8B 14 D0 EB 09 41 3B 0A 74 54")

    Public ReadOnly Property GetModelInfo() As GetModelInfoDelegate
        Get
            Return Marshal.GetDelegateForFunctionPointer(Of GetModelInfoDelegate)(address)
        End Get
    End Property

    <Extension()>
    Public Function GetVehicleMakeName(modelHash As Integer) As String
        Dim result As String = "ERROR"
        Try
            Dim index As Integer = &HFFFF
            Dim handle As GCHandle = GCHandle.Alloc(index, GCHandleType.Pinned)
            Dim modelInfo As IntPtr = GetModelInfo(modelHash, handle.AddrOfPinnedObject())
            Dim str As String = Marshal.PtrToStringAnsi(modelInfo + &H2A4)
            handle.Free()
            result = str
        Catch
            Return result
        End Try
        Return result
    End Function

    Private Function Compare(data As IntPtr, bytesPattern As Byte()) As Boolean
        For i As Integer = 0 To bytesPattern.Length - 1
            If bytesPattern(i) <> &H0 AndAlso Marshal.ReadByte(data + i) <> bytesPattern(i) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function FindPattern(pattern As String) As IntPtr

        Dim [module] As ProcessModule = Process.GetCurrentProcess().MainModule

        Dim address As Long = [module].BaseAddress.ToInt64()
        Dim endAddress As Long = address + [module].ModuleMemorySize

        pattern = pattern.Replace(" ", "").Replace("??", "00")
        Dim bytesArray As Byte() = New Byte(pattern.Length / 2 - 1) {}
        For i As Integer = 0 To pattern.Length - 1 Step 2
            bytesArray(i / 2) = [Byte].Parse(pattern.Substring(i, 2), System.Globalization.NumberStyles.HexNumber)
        Next

        While address < endAddress
            If Compare(New IntPtr(address), bytesArray) Then
                Return New IntPtr(address)
            End If
            address += 1
        End While

        Return IntPtr.Zero
    End Function
End Module