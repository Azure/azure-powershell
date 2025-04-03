### Example 1: Remove a compute fleet resource by ResourceGroupName and FleetName
```powershell
Remove-AzComputeFleet -ResourceGroupName "test-fleet" -FleetName "testFleet2"
```

This command deletes a compute fleet resource by ResourceGroupName and FleetName.

### Example 2: Remove a compute fleet resource by Identity
```powershell
$fleet = Get-AzComputeFleet -SubscriptionId "ca8520e1-3c83-4b64-bb99-60a64673daa3" -ResourceGroupName "test-fleet" -FleetName "testFleet3"
Remove-AzComputeFleet -InputObject $fleet
```

This command updates a compute fleet resource by identity.

