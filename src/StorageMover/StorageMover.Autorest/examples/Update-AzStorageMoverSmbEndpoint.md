### Example 1: Update a SMB endpoint
```powershell
Update-AzStorageMoverSmbEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -CredentialsUsernameUri "https://examples-azureKeyVault.vault.azure.net/secrets/username2" -CredentialsPasswordUri "https://examples-azureKeyVault.vault.azure.net/secrets/password2" -Description "update endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000e/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "SmbMount",
                                 "description": "update endpoint",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultSmb",
                                   "usernameUri": "https://examples-azureKeyVault.vault.azure.net/secrets/username2",
                                   "passwordUri": "https://examples-azureKeyVault.vault.azure.net/secrets/password2"
                                 },
                                 "host": "10.0.0.1",
                                 "shareName": "testshare"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 8:26:34 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description, credential username, and credential password of a SMB endpoint by manual inputs.

### Example 2: Update a SMB endpoint by pipeline
```powershell
Get-AzStorageMoverEndpoint -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -Name "myendpoint" | Update-AzStorageMoverSmbEndpoint -CredentialsPasswordUri "" -CredentialsUsernameUri "" -Description "update endpoint again"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegorup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "SmbMount",
                                 "description": "update endpoint again",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultSmb",
                                   "usernameUri": "",
                                   "passwordUri": ""
                                 },
                                 "host": "10.0.0.1",
                                 "shareName": "testshare"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 8:29:10 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description and clears the credential username and password of a SMB endpoint by pipeline.

