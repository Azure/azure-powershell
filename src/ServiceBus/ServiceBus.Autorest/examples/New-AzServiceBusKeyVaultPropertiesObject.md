### Example 1: Construct an in-memory KeyVaultProperties object
```powershell
New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://{keyVaultName}.vault.azure.net/
```
```Output
KeyName KeyVaultUri                            KeyVersion UserAssignedIdentity
------- -----------                            ---------- --------------------
key4    https://{keyVaultName}.vault.azure.net/
```
Creates an in-memory object of type `IKeyVaultProperties`. An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzServiceBusNamespaceV2 and Set-AzServiceBusNamespaceV2 to enable encryption.

### Example 2: Construct an in-memory KeyVaultProperties object having UserassignedIdentity
```powershell
$ec1 = "/subscriptions/{subscriptionId]}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://{keyVaultName}.vault.azure.net/ -UserAssignedIdentity $ec1
```
```Output
KeyName KeyVaultUri                            KeyVersion UserAssignedIdentity
------- -----------                            ---------- --------------------
key4    https://{keyVaultName}.vault.azure.net/           /subscriptions/{subscriptionId]}/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
```
Creates an in-memory object of type `IKeyVaultProperties`. An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzServiceBusNamespaceV2 and Set-AzServiceBusNamespaceV2 to enable encryption.

