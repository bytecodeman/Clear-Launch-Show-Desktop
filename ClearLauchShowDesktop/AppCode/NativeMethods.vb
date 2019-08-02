Imports System.Runtime.InteropServices

Module NativeMethods

	<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
	Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
	End Function

	<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
	Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
	End Function

	<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
	Function GetWindow(ByVal hWnd As IntPtr, ByVal uCmd As UInteger) As IntPtr
	End Function

	<DllImport("user32.dll", SetLastError:=True)>
	Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As SetWindowPosFlags) As <MarshalAs(UnmanagedType.Bool)> Boolean
	End Function

	<Flags>
	Enum SetWindowPosFlags As UInteger
		SynchronousWindowPosition = &H4000
		DeferErase = &H2000
		DrawFrame = &H20
		FrameChanged = &H20
		HideWindow = &H80
		DoNotActivate = &H10
		DoNotCopyBits = &H100
		IgnoreMove = &H2
		DoNotChangeOwnerZOrder = &H200
		DoNotRedraw = &H8
		DoNotReposition = &H200
		DoNotSendChangingEvent = &H400
		IgnoreResize = &H1
		IgnoreZOrder = &H4
		ShowWindow = &H40
	End Enum

	Enum GetWindowCmd As UInteger
		GW_HWNDFIRST = 0
		GW_HWNDLAST = 1
		GW_HWNDNEXT = 2
		GW_HWNDPREV = 3
		GW_OWNER = 4
		GW_CHILD = 5
		GW_ENABLEDPOPUP = 6
	End Enum

	Enum SW As Int32
		Hide = 0
		Normal = 1
		ShowMinimized = 2
		ShowMaximized = 3
		ShowNoActivate = 4
		Show = 5
		Minimize = 6
		ShowMinNoActive = 7
		ShowNA = 8
		Restore = 9
		ShowDefault = 10
		ForceMinimize = 11
		Max = 11
	End Enum

End Module
