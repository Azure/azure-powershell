### Example 1: List all Incident Comments for a given Incident 
```powershell
PS C:\> Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"

{{ Add output here }}
```

This command lists all Incident Comments for a given Incident.

### Example 2: Get an Incident Comment
```powershell
PS C:\> Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId" -Id "myIncidentCommentId"

{{ Add output here }}
```

This command gets an Incident Comment.

### Example 3: Get a Incident Comment by object Id
```powershell
PS C:\> $IncidentComments = Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
PS C:\> $IncidentComments[0] | Get-AzSentinelIncidentComment

{{ Add output here }}
```

This command gets an Incident by object