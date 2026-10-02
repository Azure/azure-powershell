### Example 1: Get a drill resource by name
```powershell
Get-AzResilienceDrillResource `
  -DrillName 'drill-zonal-payments' `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing'
```

Retrieves the specified drill resource.
