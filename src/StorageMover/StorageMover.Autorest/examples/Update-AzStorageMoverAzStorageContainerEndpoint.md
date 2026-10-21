### Example 1: Update an AzStorageContainer endpoint
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Description "Update Description"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint1
Name                         : containerEndpointo3q8xlbr
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "description": "Update Description",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myStorageMover/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer"
                               }
IdentityPrincipalId          : 4a8804ea-a688-4577-89f1-e74cbe3d7c3a
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
SystemDataCreatedAt          : 7/18/2022 7:28:29 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/18/2022 7:28:29 AM
SystemDataLastModifiedBy     : xxxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description of an AzStorageContainerEndpoint.

### Example 2: Replace the storage accounts allowed for cross-tenant data transfer
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -AllowedStorageAccount "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount1", "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount2"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
IdentityPrincipalId          : 00000000-0000-0000-0000-000000000000
IdentityTenantId             : 00000000-0000-0000-0000-000000000000
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "endpointKind": "Target",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer",
                                 "enableCrossTenantTransfer": true,
                                 "allowedStorageAccounts": [ "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount1", "/subscriptions/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy/resourceGroups/partnerResourceGroup/providers/Microsoft.Storage/storageAccounts/partnerStorageAccount2" ]
                               }
ResourceGroupName            : myResourceGroup
SystemDataCreatedAt          : 10/19/2026 10:43:52 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:53 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command replaces the list of partner-tenant storage accounts that are allowed to be the other side of a cross-tenant data transfer with the endpoint.

### Example 3: Disable cross-tenant data transfer for an AzStorageContainer endpoint
```powershell
Update-AzStorageMoverAzStorageContainerEndpoint -Name myEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myEndpoint
IdentityPrincipalId          : 00000000-0000-0000-0000-000000000000
IdentityTenantId             : 00000000-0000-0000-0000-000000000000
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Name                         : myEndpoint
Property                     : {
                                 "endpointType": "AzureStorageBlobContainer",
                                 "endpointKind": "Target",
                                 "provisioningState": "Succeeded",
                                 "storageAccountResourceId": "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount",
                                 "blobContainerName": "myContainer",
                                 "enableCrossTenantTransfer": false,
                                 "allowedStorageAccounts": [ ]
                               }
ResourceGroupName            : myResourceGroup
SystemDataCreatedAt          : 10/19/2026 10:43:52 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:55 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command disables cross-tenant data transfer for the endpoint and clears its list of allowed partner-tenant storage accounts.

