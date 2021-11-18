### Example 1: List all Incidents
```powershell
PS C:\> Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Incidents under a Microsoft Sentinel workspace.

### Example 2: Get an Incident
```powershell
PS C:\> Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myIncidentId"

{{ Add output here }}
```

This command gets an Incident.

### Example 3: Get an Incident by object Id
```powershell
PS C:\> $Incidents = Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $Incidents[0] | Get-AzSentinelIncident

{{ Add output here }}
```

This command gets an Incident by object