### Example 1: Expand an Entity to a given time range
```powershell
PS C:\> $startTime = (get-date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> Expand-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityId" -EndTime $endTime -StartTime $startTime

{{ Add output here }}
```

This command expands the Entity for a given time range.
