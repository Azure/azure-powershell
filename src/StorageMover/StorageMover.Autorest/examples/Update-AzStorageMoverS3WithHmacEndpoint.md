### Example 1: Update an S3 with HMAC endpoint
```powershell
Update-AzStorageMoverS3WithHmacEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey2" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey2" -Description "updated S3 endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "S3WithHMAC",
                                 "description": "updated S3 endpoint",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultS3WithHMAC",
                                   "accessKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey2",
                                   "secretKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey2"
                                 },
                                 "sourceUri": "https://s3.example.com/bucket",
                                 "sourceType": "MINIO"
                               }
SystemDataCreatedAt          : 7/18/2024 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/18/2024 8:26:34 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description and credential keys of an S3-compatible endpoint with HMAC credentials.
