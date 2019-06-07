using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using DevExpress.DashboardCommon;

namespace WinDesignerDashboardState
{
    public partial class DesignerForm1: DevExpress.XtraBars.Ribbon.RibbonForm {

        DashboardState state = new DashboardState();
        const string statePath = @"..\..\DashboardState\dashboardState.xml";
        public DesignerForm1() {
            InitializeComponent();
            dashboardDesigner.CreateRibbon();
            dashboardDesigner.LoadDashboard(@"..\..\Dashboards\dashboard1.xml");
            if(File.Exists(statePath)) {
                using(Stream stream = new FileStream(statePath, FileMode.Open)) {
                    state.LoadFromXml(XDocument.Load(stream));
                }
            }
            dashboardDesigner.SetDashboardState(state);
            dashboardDesigner.DashboardSaved += DashboardDesigner_DashboardSaved;

        }
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            state = dashboardDesigner.GetDashboardState();
            state.SaveToXml().Save(statePath);
        }
        private void DashboardDesigner_DashboardSaved(object sender,DevExpress.DashboardWin.DashboardSavedEventArgs e) {
            state = dashboardDesigner.GetDashboardState();
        }
    }
}
