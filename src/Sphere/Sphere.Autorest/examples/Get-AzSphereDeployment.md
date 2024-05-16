### Example 1: List by resource group
```powershell
Get-AzSphereDeployment -ResourceGroupName joyer-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024
```

```output
Name                                 SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
009ada36-7515-4ff0-a54c-33b75bfae976 2/28/2024 2:36:04 AM                                             2/28/2024 2:36:04 AM                                                           joyer-test
2e83ddd9-6297-48df-9c2c-2257e6b3cc71 2/28/2024 2:57:56 AM                                             2/28/2024 2:57:56 AM                                                           joyer-test
```

This command lists all deployments for specified device group.

### Example 2: Get specific deployment for device group
```powershell
Get-AzSphereDeployment -ResourceGroupName joyer-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024 -Name 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
```

```output
DateUtc                      : 2/28/2024 2:57:56 AM
DeployedImage                : {{
                                 "id": "/subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "name": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "type": "Microsoft.AzureSphere/catalogs/images",
                                 "properties": {
                                   "image": "GPIO_HighLevelApp",
                                   "imageId": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                   "regionalDataBoundary": "None",
                                   "uri": "https://as3imgptint003.blob.core.windows.net/7de8a199-bb33-4eda-9600-583103317243/imagesaks/a04f0a91-b369-4249-a47d-28c118e2cb3b?skoid=cc6e
                               3fcf-ab4d-4b0d-b3f9-9769604c1e52\u0026sktid=72f988bf-86f1-41af-91ab-2d7cd011db47\u0026skt=2024-02-28T07%3A31%3A00Z\u0026ske=2024-02-28T08%3A36%3A00Z\u0
                               026sks=b\u0026skv=2021-12-02\u0026sv=2021-12-02\u0026spr=https,http\u0026se=2024-02-28T15%3A36%3A00Z\u0026sr=b\u0026sp=r\u0026sig=MbkzxZH1VQUGft%2BfXbE
                               DhubAVucDykFSEGgvqZVn5yk%3D",
                                   "componentId": "dc7f135c-6074-4d49-aa3a-160e4eed884f",
                                   "imageType": "Applications",
                                   "provisioningState": "Succeeded"
                                 }
                               }}
DeploymentId                 : 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/de
                               viceGroups/testdevicegroup/deployments/2e83ddd9-6297-48df-9c2c-2257e6b3cc71
Name                         : 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 2/28/2024 2:57:56 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 2/28/2024 2:57:56 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/deployments
```

This command gets specific deployment in specified device group.

