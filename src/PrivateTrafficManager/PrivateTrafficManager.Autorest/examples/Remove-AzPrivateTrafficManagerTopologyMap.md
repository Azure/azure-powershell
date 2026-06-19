### Example 1: Remove a topology map
```powershell
Remove-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-demo" -ResourceGroupName "rg-ptm-demo"
```

This command removes the specified topology map and all its associated sites.

### Example 2: Remove a topology map with confirmation
```powershell
Remove-AzPrivateTrafficManagerTopologyMap -Name "ptm-topology-prod" -ResourceGroupName "rg-ptm-demo" -Confirm
```

This command removes the specified topology map after prompting for confirmation.

