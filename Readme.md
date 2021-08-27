<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/190746597/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828682)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Set the Initial Dashboard State in the WinForms Designer

This example shows how to manage the dashboard state to save and restore selected master filter values, current drill-down levels and other selections such as the selected Choropleth Map's layer.

![](/image.png)

The saved dashboard state contains the following settings:

- The ChoroplethMap's **LayerIndex** is set to **1**.
- The ChoroplethMap's **Master-Filter value** is set to **Wyoming**.
- The Grid's **Drill-Down value** is set to **Bikes**.

When the dashboard is closed, the [DashboardDesigner.GetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.GetDashboardState) method obtains a dashboard state object. It is serialized to XML and added to the **XElement** object stored in the [CustomProperties](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.CustomProperties) collection. Subsequently, the dashboard with the dashboard state data is saved to the dashboard xml file.

When the application starts, the **DashboardDesigner** loads the dashboard and the [DashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardState) object is deserialized and restored using the **GetDataFromString** method in the [DashboardDesigner.SetInitialDashboardState ](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.SetInitialDashboardState) event.

## See Also

- [Manage Dashboard State](https://docs.devexpress.com/Dashboard/400730)
- [How to Save and Restore the Dashboard State](https://github.com/DevExpress-Examples/winforms-dashboard-save-restore-dashboard-state)
- [How to Set the Initial Dashboard State in the WinForms Viewer](https://github.com/DevExpress-Examples/winforms-viewer-save-and-apply-dashboard-state)
- [How to Set the Initial Dashboard State in the WPF Dashboard](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-set-initial-dashboard-state)
