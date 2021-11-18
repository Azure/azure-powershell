### Example 1: List all Bookmarks
```powershell
PS C:\> Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Bookmarks under a Microsoft Sentinel workspace.

### Example 2: Get a Bookmark
```powershell
PS C:\> Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myBookmarkId"

{{ Add output here }}
```

This command gets a Bookmark.

### Example 3: Get a Bookmark by object Id
```powershell
PS C:\> $Bookmarks = Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $Bookmarks[0] | Get-AzSentinelBookmark

{{ Add output here }}
```

This command gets a Bookmark by object