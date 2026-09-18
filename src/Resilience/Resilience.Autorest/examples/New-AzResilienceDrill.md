### Example 1: Create a drill
```powershell
New-AzResilienceDrill `
  -Name 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -DrillType 'Zonal'
```

Creates a new drill in the specified service group.
