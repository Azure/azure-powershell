### Example 1: List all Grafana dashboards in a subscription.
```powershell
Get-AzGrafanaDashboard
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
dashboard-02             eastus   azpstest-gp
```

Lists all Azure Managed Grafana dashboards in the current subscription.

### Example 2: List all Grafana dashboards in a resource group
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
dashboard-02             eastus   azpstest-gp
```

Lists all Azure Managed Grafana dashboards in the specified resource group.

### Example 3: Get a specific Grafana dashboard
```powershell
Get-AzGrafanaDashboard -ResourceGroupName azpstest-gp -Name dashboard-01
```

```output
Name                     Location ResourceGroupName
----                     -------- -----------------
dashboard-01             eastus   azpstest-gp
```

Gets the properties of a specific Azure Managed Grafana dashboard.

