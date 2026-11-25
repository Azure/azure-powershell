### Example 1: Create a SMB endpoint
```powershell
New-AzStorageMoverSmbEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Host "10.0.0.1" -ShareName "testshare" -CredentialsUsernameUri "https://examples-azureKeyVault.vault.azure.net/secrets/username1" -CredentialsPasswordUri "https://examples-azureKeyVault.vault.azure.net/secrets/password1"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "SmbMount",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultSmb",
                                   "usernameUri": "https://examples-azureKeyVault.vault.azure.net/secrets/username1",
                                   "passwordUri": "https://examples-azureKeyVault.vault.azure.net/secrets/password1"
                                 },
                                 "host": "10.0.0.1",
                                 "shareName": "testshare"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 8:19:34 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates a SMB endpoint for a Storage mover named "mystoragemover".

### Example 2: Create an SMB source endpoint for an FSX-SMB source
```powershell
New-AzStorageMoverSmbEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Host "10.0.0.6" -ShareName "testshare" -SourceType FSX-SMB -EndpointKind Source
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Name                         : myendpoint
Property                     : {
                                 "endpointType": "SmbMount",
                                 "endpointKind": "Source",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultSmb"
                                 },
                                 "host": "10.0.0.6",
                                 "shareName": "testshare"
                               }
ResourceGroupName            : myresourcegroup
SystemDataCreatedAt          : 10/19/2026 10:43:59 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/19/2026 10:43:59 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an SMB source endpoint for an FSX-SMB source.

