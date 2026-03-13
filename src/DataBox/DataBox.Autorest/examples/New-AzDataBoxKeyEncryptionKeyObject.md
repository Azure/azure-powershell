### Example 1: Create a in-memory object for KeyEncryptionKey 
```powershell
New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"
```

```output
IdentityProperty   : {
                       "userAssigned": {
                         "resourceId": "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"
                       },
                       "type": "UserAssigned"
                     }
KekType            : CustomerManaged
KekUrl             : keyIdentifier
KekVaultResourceId : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName
```

Create a in-memory object for KeyEncryptionKey 