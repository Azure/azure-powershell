### Example 1: Create an in-memory object for StorageAccount.
```powershell
New-AzMediaStorageAccountObject -Type 'Primary' -Id "/subscriptions/{subId}/azps_test_group/providers/Microsoft.Storage/storageAccounts/azpssa" -IdentityUseSystemAssignedIdentity $False -IdentityUserAssignedIdentity "/subscriptions/{subId}/azps_test_group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-uami"
```

```output
IdentityUseSystemAssignedIdentity IdentityUserAssignedIdentity
--------------------------------- ----------------------------
False                             /subscriptions/{subId}/azps_test_group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-uami
```

Create an in-memory object for StorageAccount.