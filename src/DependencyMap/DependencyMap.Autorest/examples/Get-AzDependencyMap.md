### Example 1: Get a dependency map with name.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap
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
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command gets a dependency map in a resource group.

### Example 2: List all dependency maps in a subscription.
```powershell
Get-AzDependencyMap
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
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command lists all dependency maps in a subscription.

### Example 3: List all dependency maps in a resource group.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup
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
SystemDataLastModifiedAt     : 6/9/2025 5:25:07 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps
```

This command lists all dependency maps in a resource group.