---
Module Name: Az.Storage
Module Guid: f53f52d4-46f1-4c1a-ea8d-2b74552f6379
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.storage
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Storage Module
## Description
Microsoft Azure PowerShell: Storage cmdlets

## Az.Storage Cmdlets
### [Get-AzStorageAccount](Get-AzStorageAccount.md)
Lists all the storage accounts available under the subscription.
Note that storage keys are not returned; use the ListKeys operation for this.

### [Get-AzStorageAccountKey](Get-AzStorageAccountKey.md)
Lists the access keys for the specified storage account.

### [Get-AzStorageAccountProperty](Get-AzStorageAccountProperty.md)
Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status.
The ListKeys operation should be used to retrieve storage keys.

### [Get-AzStorageAccountSas](Get-AzStorageAccountSas.md)
List SAS credentials of a storage account.

### [Get-AzStorageAccountServiceSas](Get-AzStorageAccountServiceSas.md)
List service SAS credentials of a specific resource.

### [Get-AzStorageUsage](Get-AzStorageUsage.md)
Gets the current usage count and the limit for the resources under the subscription.

### [New-AzStorageAccount](New-AzStorageAccount.md)
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

### [New-AzStorageAccountKey](New-AzStorageAccountKey.md)
Regenerates one of the access keys for the specified storage account.

### [Remove-AzStorageAccount](Remove-AzStorageAccount.md)
Deletes a storage account in Microsoft Azure.

### [Set-AzStorageAccount](Set-AzStorageAccount.md)
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

### [Test-AzStorageAccountNameAvailability](Test-AzStorageAccountNameAvailability.md)
Checks that the storage account name is valid and is not already in use.

