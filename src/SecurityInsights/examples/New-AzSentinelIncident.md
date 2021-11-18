### Example 1: Create an Incident
```powershell
PS C:\> New-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Title "NewIncident" -Description "My Description" -Severity Low -Status New

{{ Add output here }}
```

This command creates an Incident.
