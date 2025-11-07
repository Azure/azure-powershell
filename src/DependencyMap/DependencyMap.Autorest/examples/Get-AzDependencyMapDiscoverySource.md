### Example 1: List all discovery sources under a dependency map.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap/discoverySources/dmSource
Location                     : eastus
Name                         : dmSource
Property                     : {
                                 "provisioningState": "Succeeded",
                                 "sourceType": "OffAzure",
                                 "sourceId": "testSourceId"
                               }
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 6:20:14 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 6:20:14 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps/discoverysources
```

This command lists all discovery sources under a dependency map.

### Example 2: Get a discovery source with name.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/dmTestGroup/providers/Microsoft.DependencyMap/maps/testMap/discoverySources/dmSource
Location                     : eastus
Name                         : dmSource
Property                     : {
                                 "provisioningState": "Succeeded",
                                 "sourceType": "OffAzure",
                                 "sourceId": "testSourceId"
                               }
ResourceGroupName            : dmTestGroup
SystemDataCreatedAt          : 6/9/2025 6:20:14 AM
SystemDataCreatedBy          : test@abc.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/9/2025 6:20:14 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.dependencymap/maps/discoverysources
```

This command gets a discovery source with name.