
Module ClearLaunchShowDesktop

	Private Sub ShellandWait(ByVal ProcessPath As String)
		Using objProcess As New System.Diagnostics.Process
			With objProcess
				.StartInfo.FileName = ProcessPath
				.StartInfo.WindowStyle = ProcessWindowStyle.Normal
				.Start()
				.WaitForExit()
			End With
		End Using
	End Sub

	Private Sub ShowTaskbar(ByVal Show As Boolean)
		Dim window As IntPtr = FindWindow("Shell_traywnd", "")
		SetWindowPos(window, IntPtr.Zero, 0, 0, 0, 0, CType(IIf(Show, SetWindowPosFlags.ShowWindow, SetWindowPosFlags.HideWindow), SetWindowPosFlags))
	End Sub

	Private Sub ClearDeskTop()
		Dim hWnd As IntPtr = FindWindow("ProgMan", Nothing)
		hWnd = GetWindow(hWnd, GetWindowCmd.GW_CHILD)
		ShowWindow(hWnd, SW.Hide)
		ShowTaskbar(False)
	End Sub

	Private Sub ShowDeskTop()
		Dim hWnd As IntPtr = FindWindow("ProgMan", Nothing)
		hWnd = GetWindow(hWnd, GetWindowCmd.GW_CHILD)
		ShowWindow(hWnd, SW.ShowNoActivate)
		ShowTaskbar(True)
	End Sub

	Sub Main()
		Dim ok As Boolean
		Using m As New System.Threading.Mutex(True, "ClearLaunchShow", ok)
			If Not ok Then
				MsgBox("Another instance of ClearLaunchShow is already running.")
				Return
			End If

			Dim sh As Shell32.Shell = New Shell32.Shell
			Try
				sh.MinimizeAll()
				ClearDeskTop()
				ShellandWait(My.Settings.ExeToLaunch)
			Catch ex As Exception
				MsgBox("Error in ClearLaunchShow Process: " & ex.Message)
			Finally
				ShowDeskTop()
				If sh IsNot Nothing Then
					sh.UndoMinimizeALL()
				End If
			End Try
			'GC.KeepAlive(m)
		End Using

	End Sub

End Module
