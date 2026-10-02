### Example 1: List all drill run resources in a service group
```powershell
Get-AzResilienceDrillRunResource `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing'
```

Lists every drill run resource in the specified service group.
