### Example 1: List all Bookmark Relations for a given Bookmark 
```powershell
 Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
```
```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command lists all Bookmark Relations for a given Bookmark.

### Example 2: Get a Bookmark Relation
```powershell
 Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
```
```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark Relation.

### Example 3: Get a Bookmark Relation by object Id
```powershell
 $Bookmarkrelations = Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
 $Bookmarkrelations[0] | Get-AzSentinelBookmarkRelation
```
```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark by object