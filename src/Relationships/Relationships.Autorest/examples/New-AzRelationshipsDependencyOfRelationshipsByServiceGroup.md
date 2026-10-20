### Example 1: Create a Service Group dependency relationship
```powershell
New-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup" -Name "myDependency" -TargetId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG"
```

Creates a dependency relationship from the specified Service Group to the target resource group.

