### Example 1: Get all endpoints in a Storage mover
```powershell
Get-AzStorageMoverEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint1
Name                         : myEndpoint1
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myStorageMover/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myBlobContainer"
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:29 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:29 AM
SystemDataLastModifiedBy     : xxxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints

Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint2
Name                         : myEndpoint2
Property                     : {
                                 "endpointType": "NfsMount",
                                 "provisioningState": "Succeeded",
                                 "host": "x.x.x.x",
                                 "export": "/"
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:30 AM
SystemDataCreatedBy          : xxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:30 AM
SystemDataLastModifiedBy     : xxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command gets all the endpoints under a Storage mover.

### Example 2: Get a specific endpoint
```powershell
Get-AzStorageMoverEndpoint -ResourceGroupName myResourceGroupName -StorageMoverName myStorageMoverName -Name myEndpoint
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "NfsMount",
                                 "provisioningState": "Succeeded",
                                 "host": "x.x.x.x",
                                 "export": "/"
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:30 AM
SystemDataCreatedBy          : xxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:30 AM
SystemDataLastModifiedBy     : xxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command gets a specific endpoint under a Storage mover.

