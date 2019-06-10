
using System;
using System.ComponentModel;
using System.Xml.Linq;
using DevExpress.DashboardCommon;

namespace WinDesignerDashboardState
{
    public partial class DesignerForm1: DevExpress.XtraBars.Ribbon.RibbonForm {

        DashboardState dState = new DashboardState();
        const string path = @"..\..\Dashboards\dashboard1.xml";
        public DesignerForm1() {
            InitializeComponent();
            dashboardDesigner.CreateRibbon();
            dashboardDesigner.LoadDashboard(path);
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            dState = dashboardDesigner.GetDashboardState();
            XElement userData = new XElement("Root",
                new XElement("DateModified",DateTime.Now),
                new XElement("DashboardState",dState.SaveToXml().ToString(SaveOptions.DisableFormatting)));
            dashboardDesigner.Dashboard.UserData = userData;
            dashboardDesigner.Dashboard.SaveToXml(path);            
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
    }
}
