### Example 1: Update an instance of a key vault connection
```powershell
Update-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName KeyVaultConnection2 -BaseUrl 'https://datascankv.vault.azure.net/' -Description 'This is a key vault'
```

```output
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection2
Name              : KeyVaultConnection2
```

Update an instance of a key vault connection