### Example 1: Resume a drill run
```powershell
Resume-AzResilienceDrillRun `
  -DrillName 'drill-zonal-payments' `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Resumes a drill run that is paused awaiting operator input.
