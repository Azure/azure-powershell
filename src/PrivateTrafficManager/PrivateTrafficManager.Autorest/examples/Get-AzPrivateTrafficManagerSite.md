### Example 1: Get a specific site from a topology map
```powershell
Get-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
```

This command gets the specified site from the topology map.

### Example 2: List all sites in a topology map
```powershell
Get-AzPrivateTrafficManagerSite -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

```output
Name         ProvisioningState
----         -----------------
site-eastus  Succeeded
site-westus  Succeeded
```

This command lists all sites configured in the specified topology map.

