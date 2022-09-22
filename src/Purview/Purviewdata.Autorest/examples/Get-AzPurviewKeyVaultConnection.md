### Example 1: Get key vault connection by name
```powershell
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'
```

```output
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1
```

Get key vault connection named 'KeyVaultConnection1'

### Example 2: Get all key vault connections
```powershell
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'
```

```output
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1

BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection2
Name              : KeyVaultConnection2
```

Get all key vault connections

