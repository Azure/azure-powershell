### Example 1: Create a zonal resiliency goal assignment
```powershell
New-AzResiliencyGoalAssignment -ServiceGroupName contoso-sg -Name contoso-zonal-goal -RequireZonalResiliency
```

Assigns a goal that requires zonal resiliency for the resources in service group `contoso-sg`.
