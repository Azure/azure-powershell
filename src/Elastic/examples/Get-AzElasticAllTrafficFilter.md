### Example 1: Get the list of all traffic filters for the account
```powershell
Get-AzElasticAllTrafficFilter -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter01 azure-eastus
Created from Azure Portal                  IpFilter02 azure-eastus
```

Get the list of all traffic filters for the account.

### Example 2: Get the list of all traffic filters for the account via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticAllTrafficFilter
```

```output
Description               IncludeByDefault Name       Region
-----------               ---------------- ----       ------
Created from Azure Portal                  IpFilter01 azure-eastus
Created from Azure Portal                  IpFilter02 azure-eastus
```

Get the list of all traffic filters for the account via pipeline.
