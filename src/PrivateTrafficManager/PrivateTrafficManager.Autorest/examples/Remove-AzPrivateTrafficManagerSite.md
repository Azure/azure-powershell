### Example 1: Remove a site from a topology map
```powershell
Remove-AzPrivateTrafficManagerSite -Name "site-westus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

This command removes the specified site from the topology map.

### Example 2: Remove a site with confirmation
```powershell
Remove-AzPrivateTrafficManagerSite -Name "site-eastus" -TopologyMapName "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo" -Confirm
```

This command removes the specified site after prompting for confirmation.

