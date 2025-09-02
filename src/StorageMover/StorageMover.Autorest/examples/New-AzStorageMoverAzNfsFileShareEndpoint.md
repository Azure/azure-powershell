### Example 1: Create an NFS endpoint
```powershell
New-AzStorageMoverAzNfsFileShareEndpoint -Name "my-nfs-endpoint" -ResourceGroupName "my-resource-group" -StorageMoverName "my-storage-mover" -FileShareName "10.0.0.1"  -Description "My NFS endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.StorageMover/storageMovers/my-storage-mover/endpoints/my-nfs-endpoint
Name                         : my-nfs-endpoint
Property                     :  {
                                    "endpointType": "AzureStorageNfsFileShare",
                                    "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.Storage/storageAccounts/examplesa",
                                    "fileShareName": "examples-fileshare",
                                    "description": "Example Storage File Share Endpoint Description"
                                }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 7:21:21 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an Azure NFS file share endpoint.

