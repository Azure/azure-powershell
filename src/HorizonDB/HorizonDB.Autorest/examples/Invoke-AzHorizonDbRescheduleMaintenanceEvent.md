### Example 1: Reschedule a maintenance event
```powershell
Invoke-AzHorizonDbRescheduleMaintenanceEvent -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PoolName 'example-pool-01' -MaintenanceEventId 'ABCD-123' -PostponeToDateTimeUtc ([datetime]'2026-08-20T10:00:00Z') | Format-List -Property MaintenanceEventId, Status, AppliedNow, PlannedStartTimeUtc, PlannedEndTimeUtc
```

```output
MaintenanceEventId  : ABCD-123
Status              : Rescheduled
AppliedNow          : False
PlannedStartTimeUtc : 08/20/2026 10:00:00
PlannedEndTimeUtc   : 08/20/2026 11:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
