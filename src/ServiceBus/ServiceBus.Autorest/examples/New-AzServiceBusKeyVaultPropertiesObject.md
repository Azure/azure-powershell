### Example 1: Construct an in-memory KeyVaultProperties object
```powershell
New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://{keyVaultName}.vault.azure.net/
```

Creates an in-memory object of type `IKeyVaultProperties`. An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzServiceBusNamespaceV2 and Set-AzServiceBusNamespaceV2 to enable encryption.

