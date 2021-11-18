### Example 1: Create a Incident Relation
```powershell
PS C:\> $bookmark = Get-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myBookmarkId"
PS C:\> New-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)

{{ Add output here }}
```

This command creates a Incident Relation connecting the Bookmark to the Incident.

