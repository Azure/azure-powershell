### Example 1: Update Sentinel Bookmark
```powershell
 $queryStartTime = (get-date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $queryEndTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 Update-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```

This command updates a bookmark



