### Example 1: Get the list of all associated traffic filters for the given deployment
```powershell
Get-AzElasticAssociatedTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter03 azure-eastus
Created from Azure Portal                  IpFilter02 azure-eastus
Created from Azure Portal                  IpFilter01 azure-eastus
```

Get the list of all associated traffic filters for the given deployment.

### Example 2: Get the list of all associated traffic filters for the given deployment via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Get-AzElasticAssociatedTrafficFilter
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter02 azure-eastus
Created from Azure Portal                  IpFilter01 azure-eastus
```

Get the list of all associated traffic filters for the given deployment via pipeline
