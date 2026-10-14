### Example 1: Remove a DependencyOf relationship by name
```powershell
Remove-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myDependency"
```

Deletes the DependencyOf relationship named 'myDependency' scoped to the resource group 'myRG'. The delete operation is asynchronous.

