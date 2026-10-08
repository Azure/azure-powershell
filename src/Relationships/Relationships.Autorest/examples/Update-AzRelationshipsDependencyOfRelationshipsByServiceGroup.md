### Example 1: Update a Service Group dependency relationship
```powershell
Update-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup" -Name "myDependency" -TargetId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/newTargetRG"
```

Updates the target of the named Service Group dependency relationship.

