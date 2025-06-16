### Example 1: Updates the tags of a discovery source.
```powershell
Update-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource -Tag @{"key"="value"}
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
SystemDataLastModifiedAt     : 6/9/2025 6:46:33 AM
SystemDataLastModifiedBy     : test@abc.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "key": "value"
                               }
Type                         : microsoft.dependencymap/maps/discoverysources
```

This command updates the tags of a discovery source.
