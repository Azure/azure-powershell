### Example 1: Create a new Grafana managed dashboard
```powershell
New-AzGrafanaManagedDashboard -DashboardName dashboard-01 -ResourceGroupName azpstest-gp -Location eastus -Tag @{"Environment"="Production"}
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
dashboard-01 eastus   azpstest-gp
```

Creates a new Azure Managed Grafana dashboard in the specified resource group and location. This API is idempotent, so it can create a new dashboard or update an existing one.

### Example 2: Create a Grafana dashboard using a JSON configuration file
```powershell
New-AzGrafanaManagedDashboard -DashboardName dashboard-02 -ResourceGroupName azpstest-gp -JsonFilePath "C:\dashboards\config.json"
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
dashboard-02 eastus   azpstest-gp
```

Creates a new Azure Managed Grafana dashboard using a JSON configuration file that contains the dashboard definition and settings.

