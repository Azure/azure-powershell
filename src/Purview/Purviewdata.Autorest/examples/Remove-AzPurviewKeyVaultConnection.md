### Example 1: Remove a key vault connection
```powershell
Remove-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection5'
```

```output
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection5
Name              : KeyVaultConnection5
```

Remove key vault connection named 'KeyVaultConnection5'

