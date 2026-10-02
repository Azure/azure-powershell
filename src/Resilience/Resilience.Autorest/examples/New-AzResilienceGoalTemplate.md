### Example 1: Create a goal template
```powershell
New-AzResilienceGoalTemplate `
  -Name 'gt-tier1-resiliency' `
  -ServiceGroupName 'azcmdlet-testing' `
  -RequireDisasterRecovery 'Required' `
  -RequireHighAvailability 'Required'
```

Creates a new goal template in the specified service group.
