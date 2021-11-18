### Example 1: Get Timeline for an Entity for a given time range
```powershell
PS C:\> $startTime = (get-date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> Get-AzSentinelEntityTime -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -EndTime $endTime -StartTime $startTime

{{ Add output here }}
```

This command gets the Timeline for an Entity for a given time range.
