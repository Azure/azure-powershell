### Example 1: Delete a Compute Fleet by name
```powershell
Remove-AzComputeFleet -Name "fleet1" -ResourceGroupName "myResourceGroup"
```

Deletes the specified fleet resource. For a Launch mode fleet, previously launched VMs remain running and billable; delete those VMs and any associated resources separately when they are no longer needed. The command does not produce output by default. After deletion, retrieving the fleet returns a resource-not-found error.

### Example 2: Delete a Compute Fleet with PassThru
```powershell
Remove-AzComputeFleet -Name "fleet1" -ResourceGroupName "myResourceGroup" -PassThru
```

```output
True
```

Deletes the specified Compute Fleet and returns a boolean indicating success when the `-PassThru` switch is used.

### Example 3: Delete a fleet using its identity
```powershell
$fleet = Get-AzComputeFleet -Name "fleet1" -ResourceGroupName "myResourceGroup"
Remove-AzComputeFleet -InputObject @{ Id = $fleet.Id } -PassThru
```

Uses an identity hash table containing the resource ID of an existing fleet to identify the fleet to delete. This has the same Launch mode VM-retention behavior as deleting the fleet by name.