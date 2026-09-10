### Example 1: Run drill run failover
```powershell
Invoke-AzResilienceDrillRunFailover `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -FailoverRequestPropertySourceLocation @('eastus')
```

Starts the drill run failover operation and returns the job that tracks it.
