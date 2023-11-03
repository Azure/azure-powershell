### Example 1: Update a NFS endpoint
```powershell
Update-AzStorageMoverNfsEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Description "Update Description"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "NfsMount",
                                 "description": "Update Description"
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

This command updates the description of a NFS endpoint.



