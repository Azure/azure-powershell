### Example 1: Synchronise goal resource
```powershell
Sync-AzResilienceGoalResource `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing'
```

Re-scans the scope and brings goal resource back in sync with the current resource set.
