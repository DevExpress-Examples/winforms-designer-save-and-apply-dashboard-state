﻿Namespace WinDesignerDashboardState
	Partial Public Class DesignerForm1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.dashboardBarAndDockingController1 = New DevExpress.DashboardWin.Native.DashboardBarAndDockingController(Me.components)
			Me.dashboardDesigner = New DevExpress.DashboardWin.DashboardDesigner()
			CType(Me.dashboardBarAndDockingController1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dashboardDesigner, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dashboardBarAndDockingController1
			' 
			Me.dashboardBarAndDockingController1.PropertiesBar.AllowLinkLighting = False
			Me.dashboardBarAndDockingController1.PropertiesDocking.ViewStyle = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Classic
			' 
			' dashboardDesigner
			' 
			Me.dashboardDesigner.AllowMaximizeAnimation = True
			Me.dashboardDesigner.AllowMaximizeDashboardItems = True
			Me.dashboardDesigner.AllowPrintDashboard = True
			Me.dashboardDesigner.AllowPrintDashboardItems = True
			Me.dashboardDesigner.Appearance.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(240)))), (CInt((CByte(240)))), (CInt((CByte(240)))))
			Me.dashboardDesigner.Appearance.Options.UseBackColor = True
			Me.dashboardDesigner.BarAndDockingController = Me.dashboardBarAndDockingController1
			Me.dashboardDesigner.DataSourceWizard.ShowConnectionsFromAppConfig = True
			Me.dashboardDesigner.DataSourceWizard.SqlWizardSettings.DatabaseCredentialsSavingBehavior = DevExpress.DataAccess.Wizard.SensitiveInfoSavingBehavior.Prompt
			Me.dashboardDesigner.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dashboardDesigner.Location = New System.Drawing.Point(0, 0)
			Me.dashboardDesigner.Name = "dashboardDesigner"
			Me.dashboardDesigner.Size = New System.Drawing.Size(1198, 599)
			Me.dashboardDesigner.TabIndex = 0
			Me.dashboardDesigner.UseNeutralFilterMode = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.dashboardDesigner.DashboardLoaded += new DevExpress.DashboardWin.DashboardLoadedEventHandler(this.dashboardDesigner_DashboardLoaded);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.dashboardDesigner.DashboardClosing += new DevExpress.DashboardWin.DashboardClosingEventHandler(this.dashboardDesigner_DashboardClosing);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.dashboardDesigner.SetInitialDashboardState += new DevExpress.DashboardWin.SetInitialDashboardStateEventHandler(this.dashboardDesigner_SetInitialDashboardState);
			' 
			' DesignerForm1
			' 
			Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1198, 599)
			Me.Controls.Add(Me.dashboardDesigner)
			Me.Name = "DesignerForm1"
			Me.Text = "Dashboard Designer"
			CType(Me.dashboardBarAndDockingController1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dashboardDesigner, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents dashboardDesigner As DevExpress.DashboardWin.DashboardDesigner
		Private dashboardBarAndDockingController1 As DevExpress.DashboardWin.Native.DashboardBarAndDockingController
	End Class
End Namespace