### Example 1: Create a key vault connection
```powershell
$kvConn = New-AzPurviewAzureKeyVaultObject -BaseUrl 'https://datascankv.vault.azure.net/' -Description 'This is a key vault'
New-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName KeyVaultConnection2 -Body $kvConn
```

```output
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection2
Name              : KeyVaultConnection2
```

Create a key vault connection named 'KeyVaultConnection2' in Purview.

