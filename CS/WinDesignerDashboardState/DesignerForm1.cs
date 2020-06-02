using DevExpress.DashboardCommon;
using System;
using System.Xml.Linq;

namespace WinDesignerDashboardState
{
    public partial class DesignerForm1: DevExpress.XtraBars.Ribbon.RibbonForm {
        public static readonly string PropertyName = "DashboardState";
        const string path = @"..\..\Dashboards\dashboardWithSavedState.xml";
        public DesignerForm1() {
            InitializeComponent();
            dashboardDesigner.DashboardClosing += dashboardDesigner_DashboardClosing;
            dashboardDesigner.SetInitialDashboardState += dashboardDesigner_SetInitialDashboardState;
            dashboardDesigner.CreateRibbon();
            dashboardDesigner.LoadDashboard(path);
        }
       
        DashboardState GetDataFromString(string customPropertyValue) {
            DashboardState dState = new DashboardState();
            if(!string.IsNullOrEmpty(customPropertyValue)) {
                var xmlStateEl = XDocument.Parse(customPropertyValue);
                dState.LoadFromXml(xmlStateEl);
            }
            return dState;
        }
        private void dashboardDesigner_SetInitialDashboardState(object sender,
            DevExpress.DashboardWin.SetInitialDashboardStateEventArgs e) {
            var state = GetDataFromString(dashboardDesigner.Dashboard.CustomProperties.GetValue(PropertyName));
            e.InitialState = state;
        }

        private void dashboardDesigner_DashboardClosing(object sender,DevExpress.DashboardWin.DashboardClosingEventArgs e) {
            var dState = dashboardDesigner.GetDashboardState();
            var stateValue = dState.SaveToXml().ToString(SaveOptions.DisableFormatting);
            dashboardDesigner.Dashboard.CustomProperties.SetValue("DashboardState", stateValue);
            dashboardDesigner.Dashboard.SaveToXml(path);
        }
    }
}
