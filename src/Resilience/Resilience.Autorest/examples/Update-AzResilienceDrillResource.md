### Example 1: Update a drill resource
```powershell
Update-AzResilienceDrillResource `
  -DrillName 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -FaultDurationInMin 0
```

Updates the specified drill resource, preserving properties that are not supplied.
