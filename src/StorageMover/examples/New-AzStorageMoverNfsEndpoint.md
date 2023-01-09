### Example 1: Create a NFS endpoint
```powershell
 New-AzStorageMoverNfsEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Host "10.0.0.1" -Export "/" -NfsVersion NFSv3 -Description "Description"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "NfsMount",
                                 "provisioningState": "Succeeded",
                                 "host": "10.0.0.1",
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

This command creates a NFS endpoint for a Storage mover.
