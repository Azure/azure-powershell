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

### [Close-AzStorageFileHandle](Close-AzStorageFileHandle.md)


### [Disable-AzStorageDeleteRetentionPolicy](Disable-AzStorageDeleteRetentionPolicy.md)


### [Disable-AzStorageStaticWebsite](Disable-AzStorageStaticWebsite.md)


### [Enable-AzStorageDeleteRetentionPolicy](Enable-AzStorageDeleteRetentionPolicy.md)


### [Enable-AzStorageStaticWebsite](Enable-AzStorageStaticWebsite.md)


### [Get-AzFileService](Get-AzFileService.md)
List all file services in storage accounts

### [Get-AzFileServiceProperty](Get-AzFileServiceProperty.md)
Gets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzFileShare](Get-AzFileShare.md)
Gets properties of a specified share.

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

### [Get-AzStorageAccountSas](Get-AzStorageAccountSas.md)
List SAS credentials of a storage account.

### [Get-AzStorageAccountServiceSas](Get-AzStorageAccountServiceSas.md)
List service SAS credentials of a specific resource.

### [Get-AzStorageBlob](Get-AzStorageBlob.md)


### [Get-AzStorageBlobContent](Get-AzStorageBlobContent.md)


### [Get-AzStorageBlobCopyState](Get-AzStorageBlobCopyState.md)


### [Get-AzStorageBlobService](Get-AzStorageBlobService.md)
List blob services of storage account.
It returns a collection of one object named default.

### [Get-AzStorageBlobServiceProperty](Get-AzStorageBlobServiceProperty.md)
Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Get-AzStorageContainer](Get-AzStorageContainer.md)


### [Get-AzStorageContainerStoredAccessPolicy](Get-AzStorageContainerStoredAccessPolicy.md)


### [Get-AzStorageCORSRule](Get-AzStorageCORSRule.md)


### [Get-AzStorageFile](Get-AzStorageFile.md)


### [Get-AzStorageFileContent](Get-AzStorageFileContent.md)


### [Get-AzStorageFileCopyState](Get-AzStorageFileCopyState.md)


### [Get-AzStorageFileHandle](Get-AzStorageFileHandle.md)


### [Get-AzStorageQueue](Get-AzStorageQueue.md)


### [Get-AzStorageQueueStoredAccessPolicy](Get-AzStorageQueueStoredAccessPolicy.md)


### [Get-AzStorageServiceLoggingProperty](Get-AzStorageServiceLoggingProperty.md)


### [Get-AzStorageServiceMetricsProperty](Get-AzStorageServiceMetricsProperty.md)


### [Get-AzStorageServiceProperty](Get-AzStorageServiceProperty.md)


### [Get-AzStorageShare](Get-AzStorageShare.md)


### [Get-AzStorageShareStoredAccessPolicy](Get-AzStorageShareStoredAccessPolicy.md)


### [Get-AzStorageTable](Get-AzStorageTable.md)


### [Get-AzStorageTableStoredAccessPolicy](Get-AzStorageTableStoredAccessPolicy.md)


### [Get-AzStorageUsage](Get-AzStorageUsage.md)
Gets the current usage count and the limit for the resources of the location under the subscription.

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

### [New-AzFileShare](New-AzFileShare.md)
Creates a new share under the specified account as described by request body.
The share resource includes metadata and properties for that share.
It does not include a list of the files contained by the share.

### [New-AzRmStorageContainer](New-AzRmStorageContainer.md)
Creates a new container under the specified account as described by request body.
The container resource includes metadata and properties for that container.
It does not include a list of the blobs contained by the container.

### [New-AzRmStorageContainerImmutabilityPolicy](New-AzRmStorageContainerImmutabilityPolicy.md)
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

### [New-AzStorageAccount](New-AzStorageAccount.md)
Creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

### [New-AzStorageAccountKey](New-AzStorageAccountKey.md)
Regenerates one of the access keys for the specified storage account.

### [New-AzStorageAccountManagementPolicy](New-AzStorageAccountManagementPolicy.md)
Sets the managementpolicy to the specified storage account.

### [New-AzStorageAccountSASToken](New-AzStorageAccountSASToken.md)


### [New-AzStorageBlobSASToken](New-AzStorageBlobSASToken.md)


### [New-AzStorageContainer](New-AzStorageContainer.md)


### [New-AzStorageContainerSASToken](New-AzStorageContainerSASToken.md)


### [New-AzStorageContainerStoredAccessPolicy](New-AzStorageContainerStoredAccessPolicy.md)


### [New-AzStorageContext](New-AzStorageContext.md)


### [New-AzStorageDirectory](New-AzStorageDirectory.md)


### [New-AzStorageFileSASToken](New-AzStorageFileSASToken.md)


### [New-AzStorageQueue](New-AzStorageQueue.md)


### [New-AzStorageQueueSASToken](New-AzStorageQueueSASToken.md)


### [New-AzStorageQueueStoredAccessPolicy](New-AzStorageQueueStoredAccessPolicy.md)


### [New-AzStorageShare](New-AzStorageShare.md)


### [New-AzStorageShareSASToken](New-AzStorageShareSASToken.md)


### [New-AzStorageShareStoredAccessPolicy](New-AzStorageShareStoredAccessPolicy.md)


### [New-AzStorageTable](New-AzStorageTable.md)


### [New-AzStorageTableSASToken](New-AzStorageTableSASToken.md)


### [New-AzStorageTableStoredAccessPolicy](New-AzStorageTableStoredAccessPolicy.md)


### [Remove-AzFileShare](Remove-AzFileShare.md)
Deletes specified share under its account.

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

### [Remove-AzStorageBlob](Remove-AzStorageBlob.md)


### [Remove-AzStorageContainer](Remove-AzStorageContainer.md)


### [Remove-AzStorageContainerStoredAccessPolicy](Remove-AzStorageContainerStoredAccessPolicy.md)


### [Remove-AzStorageCORSRule](Remove-AzStorageCORSRule.md)


### [Remove-AzStorageDirectory](Remove-AzStorageDirectory.md)


### [Remove-AzStorageFile](Remove-AzStorageFile.md)


### [Remove-AzStorageQueue](Remove-AzStorageQueue.md)


### [Remove-AzStorageQueueStoredAccessPolicy](Remove-AzStorageQueueStoredAccessPolicy.md)


### [Remove-AzStorageShare](Remove-AzStorageShare.md)


### [Remove-AzStorageShareStoredAccessPolicy](Remove-AzStorageShareStoredAccessPolicy.md)


### [Remove-AzStorageTable](Remove-AzStorageTable.md)


### [Remove-AzStorageTableStoredAccessPolicy](Remove-AzStorageTableStoredAccessPolicy.md)


### [Revoke-AzStorageAccountUserDelegationKey](Revoke-AzStorageAccountUserDelegationKey.md)
Revoke user delegation keys.

### [Set-AzFileServiceProperty](Set-AzFileServiceProperty.md)
Sets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules.

### [Set-AzRmStorageContainerImmutabilityPolicy](Set-AzRmStorageContainerImmutabilityPolicy.md)
Creates or updates an unlocked immutability policy.
ETag in If-Match is honored if given but not required for this operation.

### [Set-AzRmStorageContainerLegalHold](Set-AzRmStorageContainerLegalHold.md)
Sets legal hold tags.
Setting the same tag results in an idempotent operation.
SetLegalHold follows an append pattern and does not clear out the existing tags that are not specified in the request.

### [Set-AzStorageAccountManagementPolicy](Set-AzStorageAccountManagementPolicy.md)
Sets the managementpolicy to the specified storage account.

### [Set-AzStorageBlobContent](Set-AzStorageBlobContent.md)


### [Set-AzStorageBlobServiceProperty](Set-AzStorageBlobServiceProperty.md)
Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

### [Set-AzStorageContainerAcl](Set-AzStorageContainerAcl.md)


### [Set-AzStorageContainerStoredAccessPolicy](Set-AzStorageContainerStoredAccessPolicy.md)


### [Set-AzStorageCORSRule](Set-AzStorageCORSRule.md)


### [Set-AzStorageFileContent](Set-AzStorageFileContent.md)


### [Set-AzStorageQueueStoredAccessPolicy](Set-AzStorageQueueStoredAccessPolicy.md)


### [Set-AzStorageServiceLoggingProperty](Set-AzStorageServiceLoggingProperty.md)


### [Set-AzStorageServiceMetricsProperty](Set-AzStorageServiceMetricsProperty.md)


### [Set-AzStorageShareQuota](Set-AzStorageShareQuota.md)


### [Set-AzStorageShareStoredAccessPolicy](Set-AzStorageShareStoredAccessPolicy.md)


### [Set-AzStorageTableStoredAccessPolicy](Set-AzStorageTableStoredAccessPolicy.md)


### [Start-AzStorageBlobCopy](Start-AzStorageBlobCopy.md)


### [Start-AzStorageBlobIncrementalCopy](Start-AzStorageBlobIncrementalCopy.md)


### [Start-AzStorageFileCopy](Start-AzStorageFileCopy.md)


### [Stop-AzStorageBlobCopy](Stop-AzStorageBlobCopy.md)


### [Stop-AzStorageFileCopy](Stop-AzStorageFileCopy.md)


### [Test-AzStorageAccountNameAvailability](Test-AzStorageAccountNameAvailability.md)
Checks that the storage account name is valid and is not already in use.

### [Update-AzFileShare](Update-AzFileShare.md)
Updates share properties as specified in request body.
Properties not mentioned in the request will not be changed.
Update fails if the specified share does not already exist.

### [Update-AzRmStorageContainer](Update-AzRmStorageContainer.md)
Updates container properties as specified in request body.
Properties not mentioned in the request will be unchanged.
Update fails if the specified container doesn't already exist.

### [Update-AzStorageAccount](Update-AzStorageAccount.md)
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

### [Update-AzStorageServiceProperty](Update-AzStorageServiceProperty.md)


