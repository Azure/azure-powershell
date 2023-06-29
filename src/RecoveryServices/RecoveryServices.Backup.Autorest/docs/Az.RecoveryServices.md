---
Module Name: Az.RecoveryServices
Module Guid: 37eaf44e-78f7-4a5a-82d1-f6350681704b
Download Help Link: https://docs.microsoft.com/powershell/module/az.recoveryservices
Help Version: 1.0.0.0
Locale: en-US
---

# Az.RecoveryServices Module
## Description
Microsoft Azure PowerShell: RecoveryServices cmdlets

## Az.RecoveryServices Cmdlets
### [Disable-AzRecoveryServicesProtection](Disable-AzRecoveryServicesProtection.md)
Triggers the disable protection operation for the given item

### [Edit-AzRecoveryServicesBackupRetentionPolicyClientObject](Edit-AzRecoveryServicesBackupRetentionPolicyClientObject.md)
Edits the retention settings for the policy client object

### [Edit-AzRecoveryServicesBackupSchedulePolicyClientObject](Edit-AzRecoveryServicesBackupSchedulePolicyClientObject.md)
Edits the schedule policy in the specified backup policy object.

### [Enable-AzRecoveryServicesProtection](Enable-AzRecoveryServicesProtection.md)
Triggers the enable protection operation for the given item

### [Export-AzRecoveryServicesJob](Export-AzRecoveryServicesJob.md)
Triggers export of jobs specified by filters and returns an OperationID to track.

### [Get-AzRecoveryServicesBackupEngine](Get-AzRecoveryServicesBackupEngine.md)
Returns backup management server registered to Recovery Services Vault.

### [Get-AzRecoveryServicesBackupJob](Get-AzRecoveryServicesBackupJob.md)
Provides a pageable list of jobs.

### [Get-AzRecoveryServicesBackupOperationResult](Get-AzRecoveryServicesBackupOperationResult.md)
Provides the status of the delete operations such as deleting backed up item.
Once the operation has started, the\r\nstatus code in the response would be Accepted.
It will continue to be in this state till it reaches completion.
On\r\nsuccessful completion, the status code will be OK.
This method expects OperationID as an argument.
OperationID is\r\npart of the Location header of the operation response.

### [Get-AzRecoveryServicesBackupOperationStatuses](Get-AzRecoveryServicesBackupOperationStatuses.md)
Fetches the status of an operation such as triggering a backup, restore.
The status can be in progress, completed\r\nor failed.
You can refer to the OperationStatus enum for all the possible states of an operation.
Some operations\r\ncreate jobs.
This method returns the list of jobs when the operation is complete.

### [Get-AzRecoveryServicesBackupPolicy](Get-AzRecoveryServicesBackupPolicy.md)
Provides the details of the backup policies associated to Recovery Services Vault.
This is an asynchronous\r\noperation.
Status of the operation can be fetched using GetPolicyOperationResult API.

### [Get-AzRecoveryServicesBackupProtectableItem](Get-AzRecoveryServicesBackupProtectableItem.md)
Provides a pageable list of protectable objects within your subscription according to the query filter and the\r\npagination parameters.

### [Get-AzRecoveryServicesBackupProtectedItem](Get-AzRecoveryServicesBackupProtectedItem.md)
Provides a pageable list of all items that are backed up within a vault.

### [Get-AzRecoveryServicesBackupProtectionContainer](Get-AzRecoveryServicesBackupProtectionContainer.md)
Lists the containers registered to Recovery Services Vault.

### [Get-AzRecoveryServicesBackupProtectionIntent](Get-AzRecoveryServicesBackupProtectionIntent.md)
Provides a pageable list of all intents that are present within a vault.

### [Get-AzRecoveryServicesBackupResourceEncryptionConfig](Get-AzRecoveryServicesBackupResourceEncryptionConfig.md)
Fetches Vault Encryption config.

### [Get-AzRecoveryServicesBackupResourceStorageConfigsNonCrr](Get-AzRecoveryServicesBackupResourceStorageConfigsNonCrr.md)
Fetches resource storage config.

### [Get-AzRecoveryServicesBackupResourceVaultConfig](Get-AzRecoveryServicesBackupResourceVaultConfig.md)
Fetches resource vault config.

### [Get-AzRecoveryServicesBackupStatus](Get-AzRecoveryServicesBackupStatus.md)
Get the container backup status

### [Get-AzRecoveryServicesBackupUsageSummary](Get-AzRecoveryServicesBackupUsageSummary.md)
Fetches the backup management usage summaries of the vault.

### [Get-AzRecoveryServicesBackupWorkloadItem](Get-AzRecoveryServicesBackupWorkloadItem.md)
Provides a pageable list of workload item of a specific container according to the query filter and the pagination\r\nparameters.

### [Get-AzRecoveryServicesBmsPrepareDataMoveOperationResult](Get-AzRecoveryServicesBmsPrepareDataMoveOperationResult.md)
Fetches Operation Result for Prepare Data Move

### [Get-AzRecoveryServicesDeletedProtectionContainer](Get-AzRecoveryServicesDeletedProtectionContainer.md)
Lists the soft deleted containers registered to Recovery Services Vault.

### [Get-AzRecoveryServicesExportJobsOperationResult](Get-AzRecoveryServicesExportJobsOperationResult.md)
Gets the operation result of operation triggered by Export Jobs API.
If the operation is successful, then it also\r\ncontains URL of a Blob and a SAS key to access the same.
The blob contains exported jobs in JSON serialized format.

### [Get-AzRecoveryServicesJobDetail](Get-AzRecoveryServicesJobDetail.md)
Gets extended information associated with the job.

### [Get-AzRecoveryServicesJobOperationResult](Get-AzRecoveryServicesJobOperationResult.md)
Fetches the result of any operation.

### [Get-AzRecoveryServicesOperationStatus](Get-AzRecoveryServicesOperationStatus.md)
Fetches operation status for data move operation on vault

### [Get-AzRecoveryServicesPolicyTemplate](Get-AzRecoveryServicesPolicyTemplate.md)
Gets default policy template for a selected datasource type.

### [Get-AzRecoveryServicesPrivateEndpointConnection](Get-AzRecoveryServicesPrivateEndpointConnection.md)
Get Private Endpoint Connection.
This call is made by Backup Admin.

### [Get-AzRecoveryServicesPrivateEndpointOperationStatus](Get-AzRecoveryServicesPrivateEndpointOperationStatus.md)
Gets the operation status for a private endpoint connection.

### [Get-AzRecoveryServicesProtectableContainer](Get-AzRecoveryServicesProtectableContainer.md)
Lists the containers that can be registered to Recovery Services Vault.

### [Get-AzRecoveryServicesProtectedItem](Get-AzRecoveryServicesProtectedItem.md)
Provides the details of the backed up item.
This is an asynchronous operation.
To know the status of the operation,\r\ncall the GetItemOperationResult API.

### [Get-AzRecoveryServicesProtectedItemOperationResult](Get-AzRecoveryServicesProtectedItemOperationResult.md)
Fetches the result of any operation on the backup item.

### [Get-AzRecoveryServicesProtectedItemOperationStatuses](Get-AzRecoveryServicesProtectedItemOperationStatuses.md)
Fetches the status of an operation such as triggering a backup, restore.
The status can be in progress, completed\r\nor failed.
You can refer to the OperationStatus enum for all the possible states of the operation.
Some operations\r\ncreate jobs.
This method returns the list of jobs associated with the operation.

### [Get-AzRecoveryServicesProtectionContainer](Get-AzRecoveryServicesProtectionContainer.md)
Gets details of the specific container registered to your Recovery Services Vault.

### [Get-AzRecoveryServicesProtectionContainerOperationResult](Get-AzRecoveryServicesProtectionContainerOperationResult.md)
Fetches the result of any operation on the container.

### [Get-AzRecoveryServicesProtectionContainerRefreshOperationResult](Get-AzRecoveryServicesProtectionContainerRefreshOperationResult.md)
Provides the result of the refresh operation triggered by the BeginRefresh operation.

### [Get-AzRecoveryServicesProtectionIntent](Get-AzRecoveryServicesProtectionIntent.md)
Provides the details of the protection intent up item.
This is an asynchronous operation.
To know the status of the operation,\r\ncall the GetItemOperationResult API.

### [Get-AzRecoveryServicesProtectionPolicyOperationResult](Get-AzRecoveryServicesProtectionPolicyOperationResult.md)
Provides the result of an operation.

### [Get-AzRecoveryServicesProtectionPolicyOperationStatuses](Get-AzRecoveryServicesProtectionPolicyOperationStatuses.md)
Provides the status of the asynchronous operations like backup, restore.
The status can be in progress, completed\r\nor failed.
You can refer to the Operation Status enum for all the possible states of an operation.
Some operations\r\ncreate jobs.
This method returns the list of jobs associated with operation.

### [Get-AzRecoveryServicesRecoveryPoint](Get-AzRecoveryServicesRecoveryPoint.md)
Provides the information of the backed up data identified using RecoveryPointID.
This is an asynchronous operation.\r\nTo know the status of the operation, call the GetProtectedItemOperationResult API.

### [Get-AzRecoveryServicesRecoveryPointsRecommendedForMove](Get-AzRecoveryServicesRecoveryPointsRecommendedForMove.md)
Lists the recovery points recommended for move to another tier

### [Get-AzRecoveryServicesResourceGuardProxy](Get-AzRecoveryServicesResourceGuardProxy.md)
List the ResourceGuardProxies under vault

### [Get-AzRecoveryServicesSecurityPiN](Get-AzRecoveryServicesSecurityPiN.md)
Get the security PIN.

### [Get-AzRecoveryServicesValidateOperationResult](Get-AzRecoveryServicesValidateOperationResult.md)
Fetches the result of a triggered validate operation.

### [Get-AzRecoveryServicesValidateOperationStatuses](Get-AzRecoveryServicesValidateOperationStatuses.md)
Fetches the status of a triggered validate operation.
The status can be in progress, completed\r\nor failed.
You can refer to the OperationStatus enum for all the possible states of the operation.\r\nIf operation has completed, this method returns the list of errors obtained while validating the operation.

### [Invoke-AzRecoveryServicesInquireProtectionContainer](Invoke-AzRecoveryServicesInquireProtectionContainer.md)
This is an async operation and the results should be tracked using location header or Azure-async-url.

### [Invoke-AzRecoveryServicesPrepare](Invoke-AzRecoveryServicesPrepare.md)
Prepares source vault for Data Move operation

### [Move-AzRecoveryServicesRecoveryPoint](Move-AzRecoveryServicesRecoveryPoint.md)
Move recovery point from one datastore to another store.

### [New-AzRecoveryServicesBackupPolicy](New-AzRecoveryServicesBackupPolicy.md)
Creates a new backup policy in a given recovery services vault

### [New-AzRecoveryServicesItemLevelRecoveryConnection](New-AzRecoveryServicesItemLevelRecoveryConnection.md)
Provisions a script which invokes an iSCSI connection to the backup data.
Executing this script opens a file\r\nexplorer displaying all the recoverable files and folders.
This is an asynchronous operation.
To know the status of\r\nprovisioning, call GetProtectedItemOperationResult API.

### [New-AzRecoveryServicesProtectedItem](New-AzRecoveryServicesProtectedItem.md)
Enables backup of an item or to modifies the backup policy information of an already backed up item.
This is an\r\nasynchronous operation.
To know the status of the operation, call the GetItemOperationResult API.

### [New-AzRecoveryServicesProtectionIntent](New-AzRecoveryServicesProtectionIntent.md)
Create Intent for Enabling backup of an item.
This is a synchronous operation.

### [Register-AzRecoveryServicesProtectionContainer](Register-AzRecoveryServicesProtectionContainer.md)
Registers the container with Recovery Services vault.\r\nThis is an asynchronous operation.
To track the operation status, use location header to call get latest status of\r\nthe operation.

### [Remove-AzRecoveryServicesBackupPolicy](Remove-AzRecoveryServicesBackupPolicy.md)
Deletes specified backup policy from your Recovery Services Vault.
This is an asynchronous operation.
Status of the\r\noperation can be fetched using GetProtectionPolicyOperationResult API.

### [Remove-AzRecoveryServicesPrivateEndpointConnection](Remove-AzRecoveryServicesPrivateEndpointConnection.md)
Delete Private Endpoint requests.
This call is made by Backup Admin.

### [Remove-AzRecoveryServicesProtectedItem](Remove-AzRecoveryServicesProtectedItem.md)
Used to disable backup of an item within a container.
This is an asynchronous operation.
To know the status of the\r\nrequest, call the GetItemOperationResult API.

### [Remove-AzRecoveryServicesProtectionIntent](Remove-AzRecoveryServicesProtectionIntent.md)
Used to remove intent from an item

### [Remove-AzRecoveryServicesResourceGuardProxy](Remove-AzRecoveryServicesResourceGuardProxy.md)
Delete ResourceGuardProxy under vault

### [Revoke-AzRecoveryServicesItemLevelRecoveryConnection](Revoke-AzRecoveryServicesItemLevelRecoveryConnection.md)
Revokes an iSCSI connection which can be used to download a script.
Executing this script opens a file explorer\r\ndisplaying all recoverable files and folders.
This is an asynchronous operation.

### [Set-AzRecoveryServicesBackupResourceEncryptionConfig](Set-AzRecoveryServicesBackupResourceEncryptionConfig.md)
Updates Vault encryption config.

### [Set-AzRecoveryServicesBackupResourceStorageConfigsNonCrr](Set-AzRecoveryServicesBackupResourceStorageConfigsNonCrr.md)
Updates vault storage model type.

### [Set-AzRecoveryServicesBackupResourceVaultConfig](Set-AzRecoveryServicesBackupResourceVaultConfig.md)
Updates vault security config.

### [Set-AzRecoveryServicesPrivateEndpointConnection](Set-AzRecoveryServicesPrivateEndpointConnection.md)
Approve or Reject Private Endpoint requests.
This call is made by Backup Admin.

### [Set-AzRecoveryServicesProtectedItem](Set-AzRecoveryServicesProtectedItem.md)
Enables backup of an item or to modifies the backup policy information of an already backed up item.
This is an\r\nasynchronous operation.
To know the status of the operation, call the GetItemOperationResult API.

### [Set-AzRecoveryServicesProtectionIntent](Set-AzRecoveryServicesProtectionIntent.md)
Create Intent for Enabling backup of an item.
This is a synchronous operation.

### [Set-AzRecoveryServicesResourceGuardProxy](Set-AzRecoveryServicesResourceGuardProxy.md)
Add or Update ResourceGuardProxy under vault\r\nSecures vault critical operations

### [Start-AzRecoveryServices](Start-AzRecoveryServices.md)
Triggers Data Move Operation on target vault

### [Start-AzRecoveryServicesBackup](Start-AzRecoveryServicesBackup.md)
Triggers backup for specified backed up item.
This is an asynchronous operation.
To know the status of the\r\noperation, call GetProtectedItemOperationResult API.

### [Start-AzRecoveryServicesJobCancellation](Start-AzRecoveryServicesJobCancellation.md)
Cancels a job.
This is an asynchronous operation.
To know the status of the cancellation, call\r\nGetCancelOperationResult API.

### [Start-AzRecoveryServicesRestore](Start-AzRecoveryServicesRestore.md)
Restores the specified backed up data.
This is an asynchronous operation.
To know the status of this API call, use\r\nGetProtectedItemOperationResult API.

### [Start-AzRecoveryServicesValidateOperation](Start-AzRecoveryServicesValidateOperation.md)
Validate operation for specified backed up item in the form of an asynchronous operation.
Returns tracking headers which can be tracked using GetValidateOperationResult API.

### [Test-AzRecoveryServicesFeatureSupport](Test-AzRecoveryServicesFeatureSupport.md)
It will validate if given feature with resource properties is supported in service

### [Test-AzRecoveryServicesProtectionIntent](Test-AzRecoveryServicesProtectionIntent.md)
It will validate followings\r\n1.
Vault capacity\r\n2.
VM is already protected\r\n3.
Any VM related configuration passed in properties.

### [Unlock-AzRecoveryServicesResourceGuardProxyDelete](Unlock-AzRecoveryServicesResourceGuardProxyDelete.md)
Secures delete ResourceGuardProxy operations.

### [Unregister-AzRecoveryServicesProtectionContainer](Unregister-AzRecoveryServicesProtectionContainer.md)
Unregisters the given container from your Recovery Services Vault.
This is an asynchronous operation.
To determine\r\nwhether the backend service has finished processing the request, call Get Container Operation Result API.

### [Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr](Update-AzRecoveryServicesBackupResourceStorageConfigsNonCrr.md)
Updates vault storage model type.

### [Update-AzRecoveryServicesBackupResourceVaultConfig](Update-AzRecoveryServicesBackupResourceVaultConfig.md)
Updates vault security config.

### [Update-AzRecoveryServicesProtectionContainer](Update-AzRecoveryServicesProtectionContainer.md)
Discovers all the containers in the subscription that can be backed up to Recovery Services Vault.
This is an\r\nasynchronous operation.
To know the status of the operation, call GetRefreshOperationResult API.

