### Example 1: Creates or updates a Media Services account
```powershell
$storageaccount = New-AzMediaStorageAccountObject -Type 'Primary' -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.Storage/storageAccounts/azpssa"
$userassignedIdentities = @{"/subscriptions/{subId}/resourcegroups/azps_test_group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-uami"="{}"}

New-AzMediaService -AccountName azpsms -ResourceGroupName azps_test_group -Location eastus -EncryptionType 'SystemKey' -IdentityUserAssignedIdentity $userAssignedIdentities -IdentityType "UserAssigned" -StorageAccount $storageAccount
```

```output
Name   Location ResourceGroupName ProvisioningState
----   -------- ----------------- -----------------
azpsms East US  azps_test_group   Succeeded
```

Creates or updates a Media Services account