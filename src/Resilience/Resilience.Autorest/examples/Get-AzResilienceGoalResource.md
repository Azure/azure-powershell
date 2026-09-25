### Example 1: Get a goal resource by name
```powershell
Get-AzResilienceGoalResource `
  -GoalAssignmentName 'ga-payments-tier1' `
  -Name 'gr-payments-web' `
  -ServiceGroupName 'azcmdlet-testing'
```

Retrieves the specified goal resource.
