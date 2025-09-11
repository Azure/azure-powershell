### Example 1: Update an NFS endpoint
```powershell
Update-AzStorageMoverAzNfsFileShareEndpoint -Name "my-nfs-endpoint" -ResourceGroupName "my-resource-group" -StorageMoverName "my-storage-mover" -Description "My updated NFS endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.StorageMover/storageMovers/my-storage-mover/endpoints/my-nfs-endpoint
Name                         : my-nfs-endpoint
Property                     : {
                                 "endpointType": "AzureNFSFileShare",
                                 "description": "My updated NFS endpoint",
                                 "provisioningState": "Succeeded",
                                 "host": "10.0.0.1",
                                 "export": "my-export"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/14/2023 8:00:00 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description of an Azure NFS file share endpoint.

