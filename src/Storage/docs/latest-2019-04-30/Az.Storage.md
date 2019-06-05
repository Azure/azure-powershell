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
### [Clear-AzRmStorageContainerLegalHold](Clear-AzRmStorageContainerLegalHold.md)
Clears legal hold tags.
Clearing the same or non-existent tag results in an idempotent operation.
ClearLegalHold clears out only the specified tags in the request.

### [Get-AzRmStorageContainer](Get-AzRmStorageContainer.md)
Gets properties of a specified container.

### [Get-AzRmStorageContainerImmutabilityPolicy](Get-AzRmStorageContainerImmutabilityPolicy.md)
Gets the existing immutability policy along with the corresponding ETag in response headers and body.

### [Get-AzSku](Get-AzSku.md)
Lists the available SKUs supported by Microsoft.Storage for given subscription.

### [Get-AzStorageAccount](Get-AzStorageAccount.md)
Lists all the storage accounts available under the subscription.
Note that storage keys are not returned; use the ListKeys operation for this.

### [Get-AzStorageAccountKey](Get-AzStorageAccountKey.md)
Lists the access keys for the specified storage account.

### [Get-AzStorageAccountManagementPolicy](Get-AzStorageAccountManagementPolicy.md)
Gets the managementpolicy associated with the specified storage account.

### [Get-AzStorageAccountProperty](Get-AzStorageAccountProperty.md)
Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status.
The ListKeys operation should be used to retrieve storage keys.

### [Get-AzStorageAccountSas](Get-AzStorageAccountSas.md)
List SAS credentials of a storage account.

### [Get-AzStorageAccountServiceSas](Get-AzStorageAccountServiceSas.md)
List service SAS credentials of a specific resource.

### [Get-AzStorageBlobServiceProperty](Get-AzStorageBlobServiceProperty.md)
Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageUsage](Get-AzStorageUsage.md)
Gets the current usage count and the limit for the resources of the location under the subscription.

### [Invoke-AzExtendBlobContainerImmutabilityPolicy](Invoke-AzExtendBlobContainerImmutabilityPolicy.md)
Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy.
The only action allowed on a Locked policy will be this action.
ETag in If-Match is required for this operation.

### [Invoke-AzLeaseBlobContainer](Invoke-AzLeaseBlobContainer.md)
The Lease Container operation establishes and manages a lock on a container for delete operations.
The lock duration can be 15 to 60 seconds, or can be infinite.

### [Invoke-AzStorageAccountFailover](Invoke-AzStorageAccountFailover.md)
Failover request can be triggered for a storage account in case of availability issues.
The failover occurs from the storage account's primary cluster to secondary cluster for RA-GRS accounts.
The secondary cluster will become primary after failover.

### [Lock-AzRmStorageContainerImmutabilityPolicy](Lock-AzRmStorageContainerImmutabilityPolicy.md)
Sets the ImmutabilityPolicy to Locked state.
The only action allowed on a Locked policy is ExtendImmutabilityPolicy action.
ETag in If-Match is required for this operation.

### [New-AzRmStorageContainer](New-AzRmStorageContainer.md)
Creates a new container under the specified account as described by request body.
The container resource includes metadata and properties for that container.
It does not include a list of the blobs contained by the container.

### [New-AzRmStorageContainerImmutabilityPolicy](New-AzRmStorageContainerImmutabilityPolicy.md)
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

### [New-AzStorageAccount](New-AzStorageAccount.md)
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

### [New-AzStorageAccountKey](New-AzStorageAccountKey.md)
Regenerates one of the access keys for the specified storage account.

### [New-AzStorageAccountManagementPolicy](New-AzStorageAccountManagementPolicy.md)
Sets the managementpolicy to the specified storage account.

### [Remove-AzRmStorageContainer](Remove-AzRmStorageContainer.md)
Deletes specified container under its account.

### [Remove-AzRmStorageContainerImmutabilityPolicy](Remove-AzRmStorageContainerImmutabilityPolicy.md)
Aborts an unlocked immutability policy.
The response of delete has immutabilityPeriodSinceCreationInDays set to 0.
ETag in If-Match is required for this operation.
Deleting a locked immutability policy is not allowed, only way is to delete the container after deleting all blobs inside the container.

### [Remove-AzStorageAccount](Remove-AzStorageAccount.md)
Deletes a storage account in Microsoft Azure.

### [Remove-AzStorageAccountManagementPolicy](Remove-AzStorageAccountManagementPolicy.md)
Deletes the managementpolicy associated with the specified storage account.

### [Revoke-AzStorageAccountUserDelegationKey](Revoke-AzStorageAccountUserDelegationKey.md)
Revoke user delegation keys.

### [Set-AzRmStorageContainerImmutabilityPolicy](Set-AzRmStorageContainerImmutabilityPolicy.md)
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

### [Set-AzRmStorageContainerLegalHold](Set-AzRmStorageContainerLegalHold.md)
Sets legal hold tags.
Setting the same tag results in an idempotent operation.
SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.

### [Set-AzStorageAccount](Set-AzStorageAccount.md)
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

### [Set-AzStorageAccountManagementPolicy](Set-AzStorageAccountManagementPolicy.md)
Sets the managementpolicy to the specified storage account.

### [Set-AzStorageBlobServiceProperty](Set-AzStorageBlobServiceProperty.md)
Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Test-AzStorageAccountNameAvailability](Test-AzStorageAccountNameAvailability.md)
Checks that the storage account name is valid and is not already in use.

### [Update-AzRmStorageContainer](Update-AzRmStorageContainer.md)
Updates container properties as specified in request body.
Properties not mentioned in the request will be unchanged.
Update fails if the specified container doesn't already exist.

