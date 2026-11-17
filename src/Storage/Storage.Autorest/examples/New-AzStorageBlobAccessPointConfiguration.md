### Example 1: Create a configuration with a complete source body
```powershell
$configuration = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfiguration]::FromJsonString(@'
{
  "location": "eastus",
  "properties": {
    "source": {
      "sourceType": "S3Compatible",
      "connection": { "connectionType": "Endpoint", "endpoint": "https://s3.example.com", "tlsVerification": "Perform" },
      "auth": { "authType": "AccessKey", "accessKeyId": "my-access-key-id" }
    }
  }
}
'@)
$configuration.Source.Auth.SecretAccessKey = Read-Host "Secret access key" -AsSecureString
New-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint" -Resource $configuration
```

Creates an S3-compatible configuration with a secure credential. The Resource parameter supports the complete polymorphic source, connection, and authentication settings. JsonFilePath and JsonString accept REST-shaped bodies; protect any credential-bearing files and do not write them to logs or source control.
