### Example 1: Create an Incident Comment
```powershell
 New-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -Id ((New-Guid).Guid) -Message "IncidentCommentGoesHere"
```
```output
```

This command creates an Incident Comment.
