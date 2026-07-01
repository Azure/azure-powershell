### Example 1: Get a specific topology map
```powershell
Get-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-default     Succeeded
```

This command gets the specified topology map by name and resource group.

### Example 2: List all topology maps in a resource group
```powershell
Get-AzPrivateTrafficManagerTopologyMap -ResourceGroupName "rg-ptm-demo"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-default     Succeeded
ptm-topology-prod  global   site-default     Succeeded
```

This command lists all topology maps in the specified resource group.

