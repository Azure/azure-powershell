### Example 1: Update a Smb file share endpoint 
```powershell
Update-AzStorageMoverSmbFileShareEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Description "updated endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "AzureStorageSmbFileShare",
                                 "description": "updated endpoint",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount",
                                 "fileShareName": "testfs"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 7:25:59 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates a Smb file share enpdoint's description by manual inputs.

### Example 2: Update a Smb file share endpoint by pipeline
```powershell
Get-AzStorageMoverEndpoint -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Name "myendpoint" | Update-AzStorageMoverSmbFileShareEndpoint -Description "updated endpoint again"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "AzureStorageSmbFileShare",
                                 "description": "updated endpoint again",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegorup/providers/Microsoft.Storage/storageAccounts/myaccount",
                                 "fileShareName": "testfs"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 8:21:51 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates a Smb file share endpoint's description by pipeline

