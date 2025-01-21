### Example 1: List by resource group
```powershell
Get-AzSphereDeployment -ResourceGroupName group-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024
```

```output
Name                                 SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
11111111-2222-3333-4444-123456789101 2/28/2024 2:36:04 AM                                             2/28/2024 2:36:04 AM                                                           group-test
11111111-2222-3333-4444-123456789102 2/28/2024 2:57:56 AM                                             2/28/2024 2:57:56 AM                                                           group-test
```

This command lists all deployments for specified device group.

### Example 2: Get specific deployment for device group
```powershell
Get-AzSphereDeployment -ResourceGroupName group-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024 -Name 11111111-2222-3333-4444-123456789102
```

```output
DateUtc                      : 2/28/2024 2:57:56 AM
DeployedImage                : {{
                                 "id": "/subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "name": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "type": "Microsoft.AzureSphere/catalogs/images",
                                 "properties": {
                                   "image": "GPIO_HighLevelApp",
                                   "imageId": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                   "regionalDataBoundary": "None",
                                   "uri": "****************",
                                   "componentId": "dc7f135c-6074-4d49-aa3a-160e4eed884f",
                                   "imageType": "Applications",
                                   "provisioningState": "Succeeded"
                                 }
                               }}
DeploymentId                 : 11111111-2222-3333-4444-123456789102
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/de
                               viceGroups/testdevicegroup/deployments/11111111-2222-3333-4444-123456789102
Name                         : 11111111-2222-3333-4444-123456789102
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
SystemDataCreatedAt          : 2/28/2024 2:57:56 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 2/28/2024 2:57:56 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/deployments
```

This command gets specific deployment in specified device group.

