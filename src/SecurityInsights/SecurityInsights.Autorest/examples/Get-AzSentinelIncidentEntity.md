### Example 1: List all Entities for a given Incident
```powershell
 Get-AzSentinelIncidentEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "0ddb580f-efd0-4076-bb77-77e9aef8a187"
```
```output
FriendlyName : win2019
Kind         : Host
Name         : cb577adf-0266-8873-84d7-accf4b45417b
```

This command lists all Entities for a given Incident.