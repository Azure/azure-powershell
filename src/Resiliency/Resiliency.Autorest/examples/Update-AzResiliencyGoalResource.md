### Example 1: Exclude a goal resource from zonal resiliency recommendations
```powershell
$goalResource = Get-AzResiliencyGoalResource -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal -Name contoso-goal-resource
Update-AzResiliencyGoalResource -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal -Resource @(@{ Id = $goalResource.Id; ResourceArmId = $goalResource.ResourceArmId; ZonalResiliencyGoalParticipation = "Excluded" })
```

Updates a resource evaluated by the goal assignment. Each item needs the goal resource `Id`, as returned by `Get-AzResiliencyGoalResource`.
