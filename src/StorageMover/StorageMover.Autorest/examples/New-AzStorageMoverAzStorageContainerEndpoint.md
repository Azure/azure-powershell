### Example 1: Create a AzStorageContainer endpoint
```powershell
New-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -BlobContainerName myContainer -StorageMoverName myStorageMover -StorageAccountResourceId myAccountResourceId
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myStorageMover/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer"
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:29 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:29 AM
SystemDataLastModifiedBy     : xxxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates a AzStorageContainer endpoint for a Storage mover.
