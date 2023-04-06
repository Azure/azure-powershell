### Example 1: List all Bookmarks
```powershell
 Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
DisplayName    	: SecurityAlert - 28b401e1e0c9
CreatedByEmail	: john@contoso.com
CreatedByName  	: John Contoso
Label          	: {}
Note           	: This needs further investigation
Name           	: 515fc035-2ed8-4fa1-ad7d-28b401e1e0c9

```

This command lists all Bookmarks under a Microsoft Sentinel workspace.

### Example 2: Get a Bookmark
```powershell
 Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "515fc035-2ed8-4fa1-ad7d-28b401e1e0c9"
```
```output
DisplayName    	: SecurityAlert - 28b401e1e0c9
CreatedByEmail	: john@contoso.com
CreatedByName  	: John Contoso
Label          	: {}
Note           	: This needs further investigation
Name           	: 515fc035-2ed8-4fa1-ad7d-28b401e1e0c9
```

This command gets a Bookmark.