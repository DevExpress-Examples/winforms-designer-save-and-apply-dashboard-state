Imports DevExpress.DashboardCommon
Imports System
Imports System.Xml.Linq

Namespace WinDesignerDashboardState
	Partial Public Class DesignerForm1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm
		Private Const path As String = "..\..\Dashboards\dashboardWithSavedState.xml"
		Public Shared ReadOnly PropertyName As String = "DashboardState"
		Public Sub New()
			InitializeComponent()
			AddHandler dashboardDesigner.DashboardClosing, AddressOf dashboardDesigner_DashboardClosing
			AddHandler dashboardDesigner.SetInitialDashboardState, AddressOf dashboardDesigner_SetInitialDashboardState
			dashboardDesigner.CreateRibbon()
			dashboardDesigner.LoadDashboard(path)
		End Sub
		Private Function GetDataFromString(ByVal customPropertyValue As String) As DashboardState
			Dim dState As New DashboardState()
			If (Not String.IsNullOrEmpty(customPropertyValue)) Then
				Dim xmlStateEl = XDocument.Parse(customPropertyValue)
				dState.LoadFromXml(xmlStateEl)
			End If
			Return dState
		End Function

		Private Sub dashboardDesigner_SetInitialDashboardState(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.SetInitialDashboardStateEventArgs)
			Dim state = GetDataFromString(dashboardDesigner.Dashboard.CustomProperties.GetValue(PropertyName))
			e.InitialState = state
		End Sub

		Private Sub dashboardDesigner_DashboardClosing(ByVal sender As Object, ByVal e As DevExpress.DashboardWin.DashboardClosingEventArgs)
			Dim dState = dashboardDesigner.GetDashboardState()
			Dim stateValue = dState.SaveToXml().ToString(SaveOptions.DisableFormatting)
			dashboardDesigner.Dashboard.CustomProperties.SetValue("DashboardState", stateValue)
			dashboardDesigner.Dashboard.SaveToXml(path)
		End Sub
	End Class
End Namespace
