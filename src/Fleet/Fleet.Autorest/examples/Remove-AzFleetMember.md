### Example 1: Delete a fleet member
```powershell
Remove-AzFleetMember -FleetName testfleet01 -Name testmember -ResourceGroupName K8sFleet-Test 
```

This command deletes a Fleet member with a long running operation.

### Example 2: Delete a fleet member
```powershell
$m = Get-AzFleetMember -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name testmember
Remove-AzFleetMember -InputObject $m
```

This command deletes a Fleet member asynchronously with resource object.

