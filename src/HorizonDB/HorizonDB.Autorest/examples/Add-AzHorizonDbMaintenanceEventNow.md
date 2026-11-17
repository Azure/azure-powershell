### Example 1: Apply a maintenance event immediately
```powershell
Add-AzHorizonDbMaintenanceEventNow -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -MaintenanceEventId 'ABCD-123' | Format-List -Property MaintenanceEventId, Status, AppliedNow, PlannedStartTimeUtc, PlannedEndTimeUtc
```

```output
MaintenanceEventId  : ABCD-123
Status              : InProgress
AppliedNow          : True
PlannedStartTimeUtc : 08/05/2026 10:00:00
PlannedEndTimeUtc   : 08/05/2026 11:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
