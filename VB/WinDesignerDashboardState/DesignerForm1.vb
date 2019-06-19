Imports DevExpress.DashboardCommon
Imports System
Imports System.Xml.Linq

Namespace WinDesignerDashboardState
	Partial Public Class DesignerForm1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Private dState As New DashboardState()
		Private Const path As String = "..\..\Dashboards\dashboardWithSavedState.xml"
		Public Sub New()
			InitializeComponent()
			AddHandler dashboardDesigner.DashboardLoaded, AddressOf dashboardDesigner_DashboardLoaded
			AddHandler dashboardDesigner.DashboardClosing, AddressOf dashboardDesigner_DashboardClosing
			AddHandler dashboardDesigner.SetInitialDashboardState, AddressOf dashboardDesigner_SetInitialDashboardState
			dashboardDesigner.CreateRibbon()
			dashboardDesigner.LoadDashboard(path)
		End Sub
		Private Sub dashboardDesigner_DashboardLoaded(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.DashboardLoadedEventArgs)
			Dim data As XElement = e.Dashboard.UserData
			If data IsNot Nothing Then
				If data.Element("DashboardState") IsNot Nothing Then
					Dim dStateDocument As XDocument = XDocument.Parse(data.Element("DashboardState").Value)
					dState.LoadFromXml(XDocument.Parse(data.Element("DashboardState").Value))
				End If
			End If
		End Sub
		Private Sub dashboardDesigner_SetInitialDashboardState(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.SetInitialDashboardStateEventArgs)
			e.InitialState = dState
		End Sub

		Private Sub dashboardDesigner_DashboardClosing(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.DashboardClosingEventArgs)
			dState = dashboardDesigner.GetDashboardState()
			Dim userData As New XElement("Root", 
				New XElement("DateModified",Date.Now), 
				New XElement("DashboardState",dState.SaveToXml().ToString(SaveOptions.DisableFormatting)))
			dashboardDesigner.Dashboard.UserData = userData
			dashboardDesigner.Dashboard.SaveToXml(path)
		End Sub
	End Class
End Namespace
