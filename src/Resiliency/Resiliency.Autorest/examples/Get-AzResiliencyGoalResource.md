### Example 1: List the resources of a goal assignment
```powershell
Get-AzResiliencyGoalResource -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal
```

Lists the resources evaluated by goal assignment `contoso-zonal-goal`.

### Example 2: Get a goal resource
```powershell
Get-AzResiliencyGoalResource -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal -Name contoso-goal-resource
```

Gets a single goal resource.
