### Example 1: Update a goal assignment
```powershell
Update-AzResiliencyGoalAssignment -ServiceGroupName contoso-sg -Name contoso-zonal-goal -RequireZonalResiliency:$false
```

Turns off the zonal resiliency requirement of an existing goal assignment.
