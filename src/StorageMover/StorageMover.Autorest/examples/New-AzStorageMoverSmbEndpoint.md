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

