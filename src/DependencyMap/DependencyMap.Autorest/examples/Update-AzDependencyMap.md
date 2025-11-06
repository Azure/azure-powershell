### Example 1: Updates the tags of a dependency map.
```powershell
Update-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap -Tag @{"key"="value"}
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap
Location                     : eastus
Name                         : testMap
ProvisioningState            : Succeeded
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 5:25:07 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 6:09:31 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "key": "value"
                               }
Type                         : microsoft.dependencymap/maps
```

This command updates the tags of a dependency map.
