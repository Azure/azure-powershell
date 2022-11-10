### Example 1: Get Timeline for an Entity for a given time range
```powershell
 $startTime = (Get-Date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $endTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 Get-AzSentinelEntityTimeline -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -EndTime $endTime -StartTime $startTime
```
```output
DisplayName   : Suspicious process executed
Description   : Machine logs indicate that a suspicious process often associated with attacker attempts to access credentials was running on the host.
Kind          : SecurityAlert
ProductName   : Azure Security Center
Severity      : High
StartTimeUtc  : 12/20/2021 3:04:17 PM
EndTimeUtc    : 12/20/2021 3:04:17 PM
TimeGenerated : 12/20/2021 3:05:52 PM
```

This command gets the Timeline for an Entity for a given time range.
