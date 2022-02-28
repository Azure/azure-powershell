### Example 1: List all Bookmark Relations for a given Bookmark 
```powershell
PS C:\> Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"

Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command lists all Bookmark Relations for a given Bookmark.

### Example 2: Get a Bookmark Relation
```powershell
PS C:\> Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"

Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark Relation.

### Example 3: Get a Bookmark Relation by object Id
```powershell
PS C:\> $Bookmarkrelations = Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
PS C:\> $Bookmarkrelations[0] | Get-AzSentinelBookmarkRelation

Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark by object