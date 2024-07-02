### Example 1: delete a fleet update strategy with a fleet object
```powershell
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
Remove-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3
```

The first command gets a fleet. The second command removes a fleet update strategy with a fleet object.

### Example 2: delete a fleet update strategy
```powershell
Remove-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy2
```

This command removes a fleet update strategy with name.

