### Example 1: List all Alerts for a given Incident
```powershell
 Get-AzSentinelIncidentAlert -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
```
```output
AlertDisplayName : (Preview) TI map IP entity to SigninLogs
FriendlyName     : (Preview) TI map IP entity to SigninLogs
Description      : Identifies a match in SigninLogs from any IP IOC from TI
Kind             : SecurityAlert
Name             : d1e4d1dd-8d16-1aed-59bd-a256266d7244
ProductName      : Azure Sentinel
Status           : New
ProviderAlertId  : d6c7a42b-c0da-41ef-9629-b3d2d407b181
Tactic           : {Impact}
```

This command lists all Alerts for a given Incident.