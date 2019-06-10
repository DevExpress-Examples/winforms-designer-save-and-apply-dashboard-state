This example shows how how to manage the dashboard state to save and restore selected master filter values, current drill-down levels and other selections such as the selected Choropleth Map's layer.

The saved dashboard state contains the following settings:

- The ChoroplethMap's **LayerIndex** is set to **1**.
- The ChoroplethMap's **Master-Filter value** is set to **Wyoming**.
- The Grid's **Drill-Down value** is set to **Bikes**.

When the application is closed, the [GetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.GetDashboardState) method obtains a dashboard state object. It is serialized to XML and added to the **XElement** object stored in the [Dashboard.UserData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.UserData) property. Subsequently, the dashboard with the dashboard state data is saved to a file.

When the application starts, the **DashboardDesigner** loads the dashboard and the [DashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardState) object is deserialized in the [DashboardDesigner.DashboardLoaded](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.DashboardLoaded) event.

The dashboard state is restored using the [DashboardDesigner.SetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.SetDashboardState(DevExpress.DashboardCommon.DashboardState)) method in the [DashboardDesigner.SetInitialDashboardState ](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.SetInitialDashboardState) event.