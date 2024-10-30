### Example 1: Create a BlobStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject `
    -AzureStorageAccountName accountName `
    -AzureStorageAccountKey $(ConvertTo-SecureString 'accountKey' -AsPlainText)
```

Create a `BlobStorageClassTypeProperties` object with account name and account key.

