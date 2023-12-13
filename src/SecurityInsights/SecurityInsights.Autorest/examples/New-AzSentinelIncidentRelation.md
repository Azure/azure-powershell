### Example 1: Create a Incident Relation
```powershell 
 $bookmark = Get-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myBookmarkId"
 New-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)
```
```output
Name                : 4b112bd9-a6b5-44f6-b89d-8bcbf021fbdf
RelatedResourceName : a636a51c-471a-468d-89ed-d7f4b2a7a569
RelatedResourceKind :
RelatedResourceType : Microsoft.SecurityInsights/Bookmarks
```

This command creates a Incident Relation connecting the Bookmark to the Incident.

