### Example 1: Update tags for a Grafana managed dashboard
```powershell
Update-AzGrafanaManagedDashboard -DashboardName dashboard-01 -ResourceGroupName azpstest-gp -Tag @{"Environment"="Production"; "Team"="DevOps"}
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
dashboard-01 eastus   azpstest-gp
```

Updates the tags of an existing Azure Managed Grafana dashboard.

### Example 2: Update a Grafana dashboard using pipeline input
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp -Name dashboard-02 | Update-AzGrafanaManagedDashboard -Tag @{"Environment"="Staging"}
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
dashboard-02 eastus   azpstest-gp
```

Updates the Azure Managed Grafana dashboard by piping the dashboard object from Get-AzGrafanaDashboard.

