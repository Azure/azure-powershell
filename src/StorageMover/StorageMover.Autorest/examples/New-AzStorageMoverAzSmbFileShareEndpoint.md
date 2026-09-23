### Example 1: Create an Smb file share endpoint
```powershell
New-AzStorageMoverAzSmbFileShareEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -StorageAccountResourceId $accountresourceid -FileShareName testfs -Description "New smb file share endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "AzureStorageSmbFileShare",
                                 "description": "New smb file share endpoint",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/myaccount",
                                 "fileShareName": "testfs"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          :00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 7:21:21 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an Azure Storage SMB file share endpoint. 
