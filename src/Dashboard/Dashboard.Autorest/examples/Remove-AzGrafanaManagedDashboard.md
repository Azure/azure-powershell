### Example 1: Delete a Grafana managed dashboard
```powershell
Remove-AzGrafanaManagedDashboard -DashboardName dashboard-01 -ResourceGroupName azpstest-gp
```

Deletes the specified Azure Managed Grafana dashboard from the resource group.

### Example 2: Delete a Grafana dashboard using pipeline input
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp -Name dashboard-02 | Remove-AzGrafanaManagedDashboard
```

Deletes the Azure Managed Grafana dashboard by piping the dashboard object from Get-AzGrafanaDashboard.

