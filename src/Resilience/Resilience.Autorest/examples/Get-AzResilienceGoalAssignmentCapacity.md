### Example 1: Get capacity recommendations for a goal assignment
```powershell
Get-AzResilienceGoalAssignmentCapacity `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing' `
  -ResourceId @('/subscriptions/30233210-6bf4-4c4f-9e00-7cdcc1a176ec/resourceGroups/rg-resiliency-prod/providers/Microsoft.Compute/virtualMachines/vm-payments-01')
```

Evaluates the supplied resources and returns capacity assessments and resiliency recommendations. Pass an empty array to let the service discover non-resilient resources in the scope automatically.
