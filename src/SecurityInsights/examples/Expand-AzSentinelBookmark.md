### Example 1: Expand a Bookmark to a given time range
```powershell
PS C:\> $startTime = (get-date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> Expand-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myBookmarkId" -EndTime $endTime -StartTime $startTime

{{ Add output here }}
```

This command expands the Bookmark for a given time range.
