### Example 1: Create an Incident Comment
```powershell
PS C:\> New-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -Id ((New-Guid).Guid) -Message "IncidentCommentGoesHere"

{{ Add output here }}
```

This command creates an Incident Comment.
