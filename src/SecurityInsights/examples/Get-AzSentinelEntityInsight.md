### Example 1: Get Insights for an Entity for a given time range
```powershell
PS C:\> $startTime = (get-date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> Get-AzSentinelEntityInsight -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -EndTime $endTime -StartTime $startTime

{{ Add output here }}
```

This command gets insights for an Entity for a given time range.

### Example 2: Get Insights for an Entity by object Id for a given time range
```powershell
PS C:\> $startTime = (get-date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $endTime = (get-date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
PS C:\> $Entity = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
PS C:\> $Entity | Get-AzSentinelEntityInsight -EndTime $endTime -StartTime $startTime

{{ Add output here }}
```

This command gets insights for an Entity by object for a given time range.