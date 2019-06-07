Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Linq
Imports DevExpress.DashboardCommon

Namespace WinDesignerDashboardState
	Partial Public Class DesignerForm1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Private state As New DashboardState()
		Private Const statePath As String = "..\..\DashboardState\dashboardState.xml"
		Public Sub New()
			InitializeComponent()
			dashboardDesigner.CreateRibbon()
			dashboardDesigner.LoadDashboard("..\..\Dashboards\dashboard1.xml")
			If File.Exists(statePath) Then
				Using stream As Stream = New FileStream(statePath, FileMode.Open)
					state.LoadFromXml(XDocument.Load(stream))
				End Using
			End If
			dashboardDesigner.SetDashboardState(state)
			AddHandler dashboardDesigner.DashboardSaved, AddressOf DashboardDesigner_DashboardSaved

		End Sub
		Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
			MyBase.OnClosing(e)
			state = dashboardDesigner.GetDashboardState()
			state.SaveToXml().Save(statePath)
		End Sub
		Private Sub DashboardDesigner_DashboardSaved(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.DashboardSavedEventArgs)
			state = dashboardDesigner.GetDashboardState()
		End Sub
	End Class
End Namespace
