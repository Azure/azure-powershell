### Example 1: List goal assignments of a service group
```powershell
Get-AzResiliencyGoalAssignment -ServiceGroupName contoso-sg
```

Lists all goal assignments of service group `contoso-sg`.

### Example 2: Get a goal assignment
```powershell
Get-AzResiliencyGoalAssignment -ServiceGroupName contoso-sg -Name contoso-zonal-goal
```

Gets goal assignment `contoso-zonal-goal`.
