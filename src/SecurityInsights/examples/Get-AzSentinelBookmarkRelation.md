### Example 1: List all Bookmark Relations for a given Bookmark 
```powershell
PS C:\> Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"

{{ Add output here }}
```

This command lists all Bookmark Relations for a given Bookmark.

### Example 2: Get a Bookmark Relation
```powershell
PS C:\> Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId" -Id "myBookmarkRelationId"

{{ Add output here }}
```

This command gets a Bookmark Relation.

### Example 3: Get a Bookmark Relation by object Id
```powershell
PS C:\> $Bookmarkrelations = Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
PS C:\> $Bookmarkrelations[0] | Get-AzSentinelBookmarkRelation

{{ Add output here }}
```

This command gets a Bookmark by object