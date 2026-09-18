### Example 1: Complete a drill run
```powershell
Complete-AzResilienceDrillRun `
  -DrillName 'drill-zonal-payments' `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -DrillRunStage 'Failover'
```

Marks the specified drill run stage as complete, disabling further retries.
