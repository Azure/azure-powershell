### Example 1: Synchronise drill readiness
```powershell
Sync-AzResilienceDrillReadiness `
  -DrillName 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Re-scans the scope and brings drill readiness back in sync with the current resource set.
