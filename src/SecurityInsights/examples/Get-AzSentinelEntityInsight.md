### Example 1: Get Insights for an Entity for a given time range
```powershell 
 $startTime = (Get-Date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $endTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 Get-AzSentinelEntityInsight -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -EndTime $endTime -StartTime $startTime
```
```output
QueryId                    : 4191a4d7-e72b-4564-b2fb-25580630384b
QueryTimeIntervalEndTime   : 12/21/2021 10:00:00 AM
QueryTimeIntervalStartTime : 12/14/2021 10:00:00 AM
TableQueryResultColumn     : {Activity, expectedCount, actualCount, anomalyScore…}
TableQueryResultRow        : {4663 - An attempt was made to access an object. 0 3901 713.91 1 0}
```

This command gets insights for an Entity for a given time range.

### Example 2: Get Insights for an Entity by entity Id for a given time range
```powershell
 $startTime = (Get-Date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $endTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $Entity = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "8d036a2d-f37d-e936-6cca-4e172687cb79"
 $Entity | Get-AzSentinelEntityInsight -EndTime $endTime -StartTime $startTime
```
```output
QueryId                    : 4191a4d7-e72b-4564-b2fb-25580630384b
QueryTimeIntervalEndTime   : 12/21/2021 10:00:00 AM
QueryTimeIntervalStartTime : 12/14/2021 10:00:00 AM
TableQueryResultColumn     : {Activity, expectedCount, actualCount, anomalyScore…}
TableQueryResultRow        : {4663 - An attempt was made to access an object. 0 3901 713.91 1 0}
```

This command gets insights for an Entity by object for a given time range. 