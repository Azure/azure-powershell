### Example 1: Update the catch-all site of a topology map
```powershell
Update-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -CatchAllSiteName "site-westus"
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-westus      Succeeded
```

This command updates the catch-all site name for the specified topology map.

### Example 2: Update topology map tags
```powershell
Update-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -Tag @{environment="production"; team="networking"}
```

```output
Name               Location CatchAllSiteName ProvisioningState
----               -------- ---------------- -----------------
ptm-topology-demo  global   site-westus      Succeeded
```

This command updates the tags on the specified topology map.

