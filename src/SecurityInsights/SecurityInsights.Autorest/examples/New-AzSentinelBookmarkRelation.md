### Example 1: Create a Bookmark Relation
```powershell
 $incident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myIncidentId"
 $bookmarkRelation = New-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -BookmarkId "myBookmarkId" -RelationName ((New-Guid).Guid) -RelatedResourceId ($incident.Id)
```

This command creates a Bookmark Relation connecting the Incident to the Bookmark.

