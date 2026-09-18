### Example 1: Create a DependencyOf relationship from a resource group to a Service Group
```powershell
New-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myDependency" -TargetId "/providers/Microsoft.Management/serviceGroups/myServiceGroup"
```

Creates a DependencyOf relationship declaring that the resource group 'myRG' depends on the Service Group 'myServiceGroup'.

### Example 2: Create a DependencyOf relationship from a subscription to a resource group
```powershell
New-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001" -Name "subDep" -TargetId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/targetRG"
```

Creates a DependencyOf relationship where the subscription depends on the resource group 'targetRG'. Source and target must be different resources.

