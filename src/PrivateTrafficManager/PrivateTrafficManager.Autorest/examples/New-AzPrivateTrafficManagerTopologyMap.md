### Example 1: Create a topology map
```powershell
New-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -Location "global" -CatchAllSiteName "site-default" -Tag @{environment="test"}
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-default     Succeeded
```

This command creates a new topology map with a catch-all site for unmatched traffic.

### Example 2: Create a topology map using a JSON file
```powershell
New-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-prod" -ResourceGroupName "rg-ptm-demo" -JsonFilePath "./topologymap.json"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-prod  global   site-default     Succeeded
```

This command creates a topology map from a JSON file that includes site configurations.

