### Example 1: Create a discovery source.
```powershell
$property = New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject -SourceId testSourceId
New-AzDependencyMapDiscoverySource -SourceName dmSource -MapName testMap -ResourceGroupName dmTestGroup -Location eastus -Property $property
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

This command creates a discovery source.
