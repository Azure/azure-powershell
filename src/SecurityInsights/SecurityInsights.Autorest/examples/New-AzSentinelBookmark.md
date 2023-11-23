### Example 1: Create a Bookmark
```powershell
 $queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 New-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```
```output
DisplayName    : Incident Evidence
CreatedByName  : John Contoso
CreatedByEmail : john@contoso.com
Name           : 6a8d6ea6-04d5-49d7-8169-ffca8b0ced59
Note           : my notes
```

This command creates a Bookmark.

