### Example 1: Update the resources of a goal assignment
```powershell
Update-AzResiliencyGoalResource -ServiceGroupName contoso-sg -GoalAssignmentName contoso-zonal-goal -Resource @(@{ ResourceArmId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm" })
```

Updates the resources evaluated by the goal assignment.
