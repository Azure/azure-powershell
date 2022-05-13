---
Module Name: Az.Storage
Module Guid: 7c816109-d010-4ee0-b743-f9c45fd79fbc
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.storage
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Storage Module
## Description
Microsoft Azure PowerShell: Storage cmdlets

## Az.Storage Cmdlets
### [Clear-AzStorageBlobContainerLegalHold](Clear-AzStorageBlobContainerLegalHold.md)
Clears legal hold tags.
Clearing the same or non-existent tag results in an idempotent operation.
ClearLegalHold clears out only the specified tags in the request.

### [Get-AzStorageAccount](Get-AzStorageAccount.md)
Lists all the storage accounts available under the subscription.
Note that storage keys are not returned; use the ListKeys operation for this.

### [Get-AzStorageAccountKey](Get-AzStorageAccountKey.md)
Lists the access keys or Kerberos keys (if active directory enabled) for the specified storage account.

### [Get-AzStorageAccountProperty](Get-AzStorageAccountProperty.md)
Returns the properties for the specified storage account including but not limited to name, SKU name, location, and account status.
The ListKeys operation should be used to retrieve storage keys.

### [Get-AzStorageAccountSas](Get-AzStorageAccountSas.md)
List SAS credentials of a storage account.

### [Get-AzStorageAccountServiceSas](Get-AzStorageAccountServiceSas.md)
List service SAS credentials of a specific resource.

### [Get-AzStorageBlobContainer](Get-AzStorageBlobContainer.md)
Gets properties of a specified container.

### [Get-AzStorageBlobContainerImmutabilityPolicy](Get-AzStorageBlobContainerImmutabilityPolicy.md)
Gets the existing immutability policy along with the corresponding ETag in response headers and body.

### [Get-AzStorageBlobInventoryPolicy](Get-AzStorageBlobInventoryPolicy.md)
Gets the blob inventory policy associated with the specified storage account.

### [Get-AzStorageBlobService](Get-AzStorageBlobService.md)
List blob services of storage account.
It returns a collection of one object named default.

### [Get-AzStorageBlobServiceProperty](Get-AzStorageBlobServiceProperty.md)
Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageDeletedAccount](Get-AzStorageDeletedAccount.md)
Get properties of specified deleted account resource.

### [Get-AzStorageEncryptionScope](Get-AzStorageEncryptionScope.md)
Returns the properties for the specified encryption scope.

### [Get-AzStorageFileService](Get-AzStorageFileService.md)
List all file services in storage accounts

### [Get-AzStorageFileServiceProperty](Get-AzStorageFileServiceProperty.md)
Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageFileShare](Get-AzStorageFileShare.md)
Gets properties of a specified share.

### [Get-AzStorageLocalUser](Get-AzStorageLocalUser.md)
Get the local user of the storage account by username.

### [Get-AzStorageLocalUserKey](Get-AzStorageLocalUserKey.md)
List SSH authorized keys and shared key of the local user.

### [Get-AzStorageManagementPolicy](Get-AzStorageManagementPolicy.md)
Gets the managementpolicy associated with the specified storage account.

### [Get-AzStorageObjectReplicationPolicy](Get-AzStorageObjectReplicationPolicy.md)
Get the object replication policy of the storage account by policy ID.

### [Get-AzStoragePrivateEndpointConnection](Get-AzStoragePrivateEndpointConnection.md)
Gets the specified private endpoint connection associated with the storage account.

### [Get-AzStoragePrivateLinkResource](Get-AzStoragePrivateLinkResource.md)
Gets the private link resources that need to be created for a storage account.

### [Get-AzStorageQueue](Get-AzStorageQueue.md)
Gets the queue with the specified queue name, under the specified account if it exists.

### [Get-AzStorageQueueService](Get-AzStorageQueueService.md)
List all queue services for the storage account

### [Get-AzStorageQueueServiceProperty](Get-AzStorageQueueServiceProperty.md)
Gets the properties of a storage account’s Queue service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageSku](Get-AzStorageSku.md)
Lists the available SKUs supported by Microsoft.Storage for given subscription.

### [Get-AzStorageTable](Get-AzStorageTable.md)
Gets the table with the specified table name, under the specified account if it exists.

### [Get-AzStorageTableService](Get-AzStorageTableService.md)
List all table services for the storage account.

### [Get-AzStorageTableServiceProperty](Get-AzStorageTableServiceProperty.md)
Gets the properties of a storage account’s Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageUsage](Get-AzStorageUsage.md)
Gets the current usage count and the limit for the resources of the location under the subscription.

### [Invoke-AzStorageAbortStorageAccountHierarchicalNamespaceMigration](Invoke-AzStorageAbortStorageAccountHierarchicalNamespaceMigration.md)
Abort live Migration of storage account to enable Hns

### [Invoke-AzStorageExtendBlobContainerImmutabilityPolicy](Invoke-AzStorageExtendBlobContainerImmutabilityPolicy.md)
Extends the immutabilityPeriodSinceCreationInDays of a locked immutabilityPolicy.
The only action allowed on a Locked policy will be this action.
ETag in If-Match is required for this operation.

### [Invoke-AzStorageHierarchicalStorageAccountNamespaceMigration](Invoke-AzStorageHierarchicalStorageAccountNamespaceMigration.md)
Live Migration of storage account to enable Hns

### [Invoke-AzStorageLeaseBlobContainer](Invoke-AzStorageLeaseBlobContainer.md)
The Lease Container operation establishes and manages a lock on a container for delete operations.
The lock duration can be 15 to 60 seconds, or can be infinite.

### [Invoke-AzStorageLeaseFileShare](Invoke-AzStorageLeaseFileShare.md)
The Lease Share operation establishes and manages a lock on a share for delete operations.
The lock duration can be 15 to 60 seconds, or can be infinite.

### [Invoke-AzStorageObjectBlobContainerLevelWorm](Invoke-AzStorageObjectBlobContainerLevelWorm.md)
This operation migrates a blob container from container level WORM to object level immutability enabled container.
Prerequisites require a container level immutability policy either in locked or unlocked state, Account level versioning must be enabled and there should be no Legal hold on the container.

### [Lock-AzStorageBlobContainerImmutabilityPolicy](Lock-AzStorageBlobContainerImmutabilityPolicy.md)
Sets the ImmutabilityPolicy to Locked state.
The only action allowed on a Locked policy is ExtendImmutabilityPolicy action.
ETag in If-Match is required for this operation.

### [New-AzStorageAccount](New-AzStorageAccount.md)
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

### [New-AzStorageAccountKey](New-AzStorageAccountKey.md)
Regenerates one of the access keys or Kerberos keys for the specified storage account.

### [New-AzStorageBlobContainer](New-AzStorageBlobContainer.md)
Creates a new container under the specified account as described by request body.
The container resource includes metadata and properties for that container.
It does not include a list of the blobs contained by the container.

### [New-AzStorageBlobContainerImmutabilityPolicy](New-AzStorageBlobContainerImmutabilityPolicy.md)
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

### [New-AzStorageBlobInventoryPolicy](New-AzStorageBlobInventoryPolicy.md)
Sets the blob inventory policy to the specified storage account.

### [New-AzStorageFileShare](New-AzStorageFileShare.md)
Creates a new share under the specified account as described by request body.
The share resource includes metadata and properties for that share.
It does not include a list of the files contained by the share.

### [New-AzStorageLocalUser](New-AzStorageLocalUser.md)
Create or update the properties of a local user associated with the storage account

### [New-AzStorageLocalUserPassword](New-AzStorageLocalUserPassword.md)
Regenerate the local user SSH password.

### [New-AzStorageManagementPolicy](New-AzStorageManagementPolicy.md)
Sets the managementpolicy to the specified storage account.

### [New-AzStorageObjectReplicationPolicy](New-AzStorageObjectReplicationPolicy.md)
Create or update the object replication policy of the storage account.

### [New-AzStorageQueue](New-AzStorageQueue.md)
Creates a new queue with the specified queue name, under the specified account.

### [New-AzStorageTable](New-AzStorageTable.md)
Creates a new table with the specified table name, under the specified account.

### [Remove-AzStorageAccount](Remove-AzStorageAccount.md)
Deletes a storage account in Microsoft Azure.

### [Remove-AzStorageBlobContainer](Remove-AzStorageBlobContainer.md)
Deletes specified container under its account.

### [Remove-AzStorageBlobContainerImmutabilityPolicy](Remove-AzStorageBlobContainerImmutabilityPolicy.md)
Aborts an unlocked immutability policy.
The response of delete has immutabilityPeriodSinceCreationInDays set to 0.
ETag in If-Match is required for this operation.
Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container.

### [Remove-AzStorageBlobInventoryPolicy](Remove-AzStorageBlobInventoryPolicy.md)
Deletes the blob inventory policy associated with the specified storage account.

### [Remove-AzStorageFileShare](Remove-AzStorageFileShare.md)
Deletes specified share under its account.

### [Remove-AzStorageLocalUser](Remove-AzStorageLocalUser.md)
Deletes the local user associated with the specified storage account.

### [Remove-AzStorageManagementPolicy](Remove-AzStorageManagementPolicy.md)
Deletes the managementpolicy associated with the specified storage account.

### [Remove-AzStorageObjectReplicationPolicy](Remove-AzStorageObjectReplicationPolicy.md)
Deletes the object replication policy associated with the specified storage account.

### [Remove-AzStoragePrivateEndpointConnection](Remove-AzStoragePrivateEndpointConnection.md)
Deletes the specified private endpoint connection associated with the storage account.

### [Remove-AzStorageQueue](Remove-AzStorageQueue.md)
Deletes the queue with the specified queue name, under the specified account if it exists.

### [Remove-AzStorageTable](Remove-AzStorageTable.md)
Deletes the table with the specified table name, under the specified account if it exists.

### [Restore-AzStorageAccountBlobRange](Restore-AzStorageAccountBlobRange.md)
Restore blobs in the specified blob ranges

### [Restore-AzStorageFileShare](Restore-AzStorageFileShare.md)
Restore a file share within a valid retention days if share soft delete is enabled

### [Revoke-AzStorageAccountUserDelegationKey](Revoke-AzStorageAccountUserDelegationKey.md)
Revoke user delegation keys.

### [Test-AzStorageAccountNameAvailability](Test-AzStorageAccountNameAvailability.md)
Checks that the storage account name is valid and is not already in use.

### [Update-AzStorageAccount](Update-AzStorageAccount.md)
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

### [Update-AzStorageBlobContainer](Update-AzStorageBlobContainer.md)
Updates container properties as specified in request body.
Properties not mentioned in the request will be unchanged.
Update fails if the specified container doesn't already exist.

### [Update-AzStorageEncryptionScope](Update-AzStorageEncryptionScope.md)
Update encryption scope properties as specified in the request body.
Update fails if the specified encryption scope does not already exist.

### [Update-AzStorageFileShare](Update-AzStorageFileShare.md)
Updates share properties as specified in request body.
Properties not mentioned in the request will not be changed.
Update fails if the specified share does not already exist.

### [Update-AzStorageQueue](Update-AzStorageQueue.md)
Creates a new queue with the specified queue name, under the specified account.

### [Update-AzStorageTable](Update-AzStorageTable.md)
Creates a new table with the specified table name, under the specified account.

