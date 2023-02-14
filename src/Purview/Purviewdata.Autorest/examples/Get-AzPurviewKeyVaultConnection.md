### Example 1: Get key vault connection by name
```powershell
<<<<<<< HEAD
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'
```

```output
=======
PS C:\> Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection1'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
BaseUrl           : https://datascantestcases.vault.azure.net/
Description       : This is a Key Vault connection
Id                : keyVaults/KeyVaultConnection1
Name              : KeyVaultConnection1
```

Get key vault connection named 'KeyVaultConnection1'

### Example 2: Get all key vault connections
```powershell
<<<<<<< HEAD
Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'
```

```output
=======
PS C:\> Get-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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

