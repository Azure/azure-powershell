### Example 1: Removes an incident based on the incident Id
```powershell
Remove-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id <IncidentId>
```
```output
```

This command removes an incident based on the incident id.

### Example 2: Removes an incident based on the incident number
```powershell
$myIncident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id <IncidentId> | Where-Object {$_.Number -eq "780"}
```
```output
```

The command removes an incident based on an incident number.

