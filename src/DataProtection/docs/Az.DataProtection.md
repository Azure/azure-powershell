---
Module Name: Az.DataProtection
Module Guid: 0796af7c-0a7c-417f-8d0d-19f9179dac7a
Download Help Link: https://docs.microsoft.com/powershell/module/az.dataprotection
Help Version: 1.0.0.0
Locale: en-US
---

# Az.DataProtection Module
## Description
Microsoft Azure PowerShell: DataProtection cmdlets

## Az.DataProtection Cmdlets
### [AddFilterToQuery](AddFilterToQuery.md)


### [Backup-AzDataProtectionBackupInstanceAdhoc](Backup-AzDataProtectionBackupInstanceAdhoc.md)
Trigger adhoc backup

### [Edit-AzDataProtectionPolicyRetentionRuleClientObject](Edit-AzDataProtectionPolicyRetentionRuleClientObject.md)
Adds or removes Retention Rule to existing Policy

### [Edit-AzDataProtectionPolicyTagClientObject](Edit-AzDataProtectionPolicyTagClientObject.md)
Adds or removes schedule tag in an existing backup policy.

### [Edit-AzDataProtectionPolicyTriggerClientObject](Edit-AzDataProtectionPolicyTriggerClientObject.md)
Updates Backup schedule of an existing backup policy.

### [Get-AzDataProtectionBackupInstance](Get-AzDataProtectionBackupInstance.md)
Gets a backup instance with name in a backup vault

### [Get-AzDataProtectionBackupPolicy](Get-AzDataProtectionBackupPolicy.md)
Gets a backup policy belonging to a backup vault

### [Get-AzDataProtectionBackupVault](Get-AzDataProtectionBackupVault.md)
Returns a resource belonging to a resource group.

### [Get-AzDataProtectionExportJobsOperationResult](Get-AzDataProtectionExportJobsOperationResult.md)
Gets the operation result of operation triggered by Export Jobs API.
If the operation is successful, then it also contains URL of a Blob and a SAS key to access the same.
The blob contains exported jobs in JSON serialized format.

### [Get-AzDataProtectionJob](Get-AzDataProtectionJob.md)
Gets a job with id in a backup vault

### [Get-AzDataProtectionOperationResult](Get-AzDataProtectionOperationResult.md)
Gets the operation result for a resource

### [Get-AzDataProtectionOperationResultPatch](Get-AzDataProtectionOperationResultPatch.md)


### [Get-AzDataProtectionOperationStatus](Get-AzDataProtectionOperationStatus.md)
Gets the operation status for a resource.

### [Get-AzDataProtectionPolicyTemplate](Get-AzDataProtectionPolicyTemplate.md)
Gets default policy template for a selected datasource type.

### [Get-AzDataProtectionRecoveryPoint](Get-AzDataProtectionRecoveryPoint.md)
Gets a Recovery Point using recoveryPointId for a Datasource.

### [GetBackupFrequenceFromTimeInterval](GetBackupFrequenceFromTimeInterval.md)


### [GetBackupFrequencyString](GetBackupFrequencyString.md)


### [GetClientDatasourceType](GetClientDatasourceType.md)


### [GetDatasourceInfo](GetDatasourceInfo.md)


### [GetDatasourceSetInfo](GetDatasourceSetInfo.md)


### [GetDatasourceTypes](GetDatasourceTypes.md)
Prepares Datasource object for backup

### [GetRestoreType](GetRestoreType.md)


### [GetTaggingPriority](GetTaggingPriority.md)


### [Initialize-AzDataProtectionBackupInstance](Initialize-AzDataProtectionBackupInstance.md)
Initializes Backup instance Request object for configuring backup

### [Initialize-AzDataProtectionRestoreRequest](Initialize-AzDataProtectionRestoreRequest.md)
Initializes Restore Request object for triggering restore on a protected backup instance.

### [LoadManifest](LoadManifest.md)
Prepares Datasource object for backup

### [New-AzDataProtectionBackupInstance](New-AzDataProtectionBackupInstance.md)
Configures Backup for supported azure resources

### [New-AzDataProtectionBackupPolicy](New-AzDataProtectionBackupPolicy.md)


### [New-AzDataProtectionBackupVault](New-AzDataProtectionBackupVault.md)
Creates or updates a BackupVault resource belonging to a resource group.

### [New-AzDataProtectionBackupVaultStorageSettingObject](New-AzDataProtectionBackupVaultStorageSettingObject.md)
Get Backup Vault storage setting object

### [New-AzDataProtectionPolicyTagCriteriaClientObject](New-AzDataProtectionPolicyTagCriteriaClientObject.md)
Creates a new criteria object

### [New-AzDataProtectionPolicyTriggerScheduleClientObject](New-AzDataProtectionPolicyTriggerScheduleClientObject.md)
Creates new Schedule object

### [New-AzDataProtectionRetentionLifeCycleClientObject](New-AzDataProtectionRetentionLifeCycleClientObject.md)
Creates new Lifecycle object

### [Remove-AzDataProtectionBackupInstance](Remove-AzDataProtectionBackupInstance.md)


### [Remove-AzDataProtectionBackupPolicy](Remove-AzDataProtectionBackupPolicy.md)
Deletes a backup policy belonging to a backup vault

### [Remove-AzDataProtectionBackupVault](Remove-AzDataProtectionBackupVault.md)
Deletes a BackupVault resource from the resource group.

### [Search-AzDataProtectionBackupInstanceInAzGraph](Search-AzDataProtectionBackupInstanceInAzGraph.md)
Searches for Backup instances in Azure Resource Graph and retrieves the expected entries

### [Search-AzDataProtectionJobInAzGraph](Search-AzDataProtectionJobInAzGraph.md)
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries

### [Start-AzDataProtectionBackupInstanceRehydrate](Start-AzDataProtectionBackupInstanceRehydrate.md)
rehydrate recovery point for restore for a BackupInstance

### [Start-AzDataProtectionBackupInstanceRestore](Start-AzDataProtectionBackupInstanceRestore.md)
Triggers restore for a BackupInstance

### [Start-AzDataProtectionExportJob](Start-AzDataProtectionExportJob.md)
Triggers export of jobs and returns an OperationID to track.

### [Test-AzDataProtectionBackupInstance](Test-AzDataProtectionBackupInstance.md)
Validate whether adhoc backup will be successful or not

### [Test-AzDataProtectionBackupInstanceRestore](Test-AzDataProtectionBackupInstanceRestore.md)
Validates if Restore can be triggered for a DataSource

### [Test-AzDataProtectionBackupVaultNameAvailability](Test-AzDataProtectionBackupVaultNameAvailability.md)
API to check for resource name availability

### [Test-AzDataProtectionFeatureSupport](Test-AzDataProtectionFeatureSupport.md)
Validates if a feature is supported

### [Update-AzDataProtectionBackupVault](Update-AzDataProtectionBackupVault.md)
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

### [ValidateBackupSchedule](ValidateBackupSchedule.md)


### [ValidateRestoreOptions](ValidateRestoreOptions.md)


