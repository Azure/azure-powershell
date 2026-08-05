### Example 1: Create an S3 with HMAC endpoint
```powershell
New-AzStorageMoverS3WithHmacEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -SourceUri "https://s3.example.com/bucket" -SourceType "MINIO" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey" -Description "S3 endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "S3WithHMAC",
                                 "description": "S3 endpoint",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultS3WithHMAC",
                                   "accessKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey",
                                   "secretKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey"
                                 },
                                 "sourceUri": "https://s3.example.com/bucket",
                                 "sourceType": "MINIO"
                               }
SystemDataCreatedAt          : 7/18/2024 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/18/2024 4:30:50 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an S3-compatible endpoint with HMAC credentials for a Storage Mover named "mystoragemover".
