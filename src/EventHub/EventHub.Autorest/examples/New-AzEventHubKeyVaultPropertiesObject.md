### Example 1: Construct an in-memory KeyVaultProperties object
```powershell
New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://testkeyvault.vault.azure.net
```

Creates an in-memory object of type `IKeyVaultProperties`. An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzEventHubNamespaceV2 and Set-AzEventHubNamespaceV2 to enable encryption.
