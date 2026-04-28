### Example 1: Update the target of a DependencyOf relationship
```powershell
Update-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myDependency" -TargetId "/providers/Microsoft.Management/serviceGroups/newTarget"
```

Updates the DependencyOf relationship to point to a different Service Group target.

