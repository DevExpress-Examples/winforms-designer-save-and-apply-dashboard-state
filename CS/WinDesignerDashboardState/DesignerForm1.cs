using DevExpress.DashboardCommon;
using System;
using System.Xml.Linq;

namespace WinDesignerDashboardState
{
    public partial class DesignerForm1: DevExpress.XtraBars.Ribbon.RibbonForm {

        DashboardState dState = new DashboardState();
        const string path = @"..\..\Dashboards\dashboardWithSavedState.xml";
        public DesignerForm1() {
            InitializeComponent();
            dashboardDesigner.DashboardLoaded += dashboardDesigner_DashboardLoaded;
            dashboardDesigner.DashboardClosing += dashboardDesigner_DashboardClosing;
            dashboardDesigner.SetInitialDashboardState += dashboardDesigner_SetInitialDashboardState;
            dashboardDesigner.CreateRibbon();
            dashboardDesigner.LoadDashboard(path);
        }
        private void dashboardDesigner_DashboardLoaded(object sender,
            DevExpress.DashboardWin.DashboardLoadedEventArgs e) {
            XElement data = e.Dashboard.UserData;
            if(data != null) {
                if(data.Element("DashboardState") != null) {
                    XDocument dStateDocument = XDocument.Parse(data.Element("DashboardState").Value);
                    dState.LoadFromXml(XDocument.Parse(data.Element("DashboardState").Value));
                }
            }            
        }
        private void dashboardDesigner_SetInitialDashboardState(object sender,
            DevExpress.DashboardWin.SetInitialDashboardStateEventArgs e) {
            e.InitialState = dState;
        }

        private void dashboardDesigner_DashboardClosing(object sender,DevExpress.DashboardWin.DashboardClosingEventArgs e) {
            dState = dashboardDesigner.GetDashboardState();
            XElement userData = new XElement("Root",
                new XElement("DateModified",DateTime.Now),
                new XElement("DashboardState",dState.SaveToXml().ToString(SaveOptions.DisableFormatting)));
            dashboardDesigner.Dashboard.UserData = userData;
            dashboardDesigner.Dashboard.SaveToXml(path);
        }
    }
}
