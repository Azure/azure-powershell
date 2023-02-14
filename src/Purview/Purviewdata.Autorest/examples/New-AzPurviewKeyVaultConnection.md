### Example 1: Create a key vault connection
```powershell
<<<<<<< HEAD
$kvConn = New-AzPurviewAzureKeyVaultObject -BaseUrl 'https://datascankv.vault.azure.net/' -Description 'This is a key vault'
New-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName KeyVaultConnection2 -Body $kvConn
```

```output
=======
PS C:\>  $kvConn = New-AzPurviewAzureKeyVaultObject -BaseUrl 'https://datascankv.vault.azure.net/' -Description 'This is a key vault'
New-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName KeyVaultConnection2 -Body $kvConn

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection2
Name              : KeyVaultConnection2
```

Create a key vault connection named 'KeyVaultConnection2' in Purview.

