### Example 1: Generate a drill run report
```powershell
New-AzResilienceDrillRunReport `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Generates, or regenerates, the report for the specified drill run. The action is idempotent and safe to call at any time.
