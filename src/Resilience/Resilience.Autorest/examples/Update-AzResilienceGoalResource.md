### Example 1: Exclude a resource from a goal assignment
```powershell
$resource = Get-AzResilienceGoalResource `
  -Name 'gr-payments-web' `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing'

$resource.HighAvailabilityGoalParticipation = 'Excluded'

Update-AzResilienceGoalResource `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing' `
  -Resource $resource
```

Retrieves a goal resource, excludes it from high availability evaluation, and submits the change. `-Resource` accepts an array, so several resources can be updated in a single call.
