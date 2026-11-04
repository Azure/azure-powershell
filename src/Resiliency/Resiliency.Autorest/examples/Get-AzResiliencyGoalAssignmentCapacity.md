### Example 1: Get capacity recommendations for resources
```powershell
Get-AzResiliencyGoalAssignmentCapacity -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm"
```

Gets capacity recommendations to meet the goal assignment for the given resources.
