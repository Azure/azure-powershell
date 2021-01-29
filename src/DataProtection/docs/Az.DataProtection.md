---
Module Name: Az.DataProtection
Module Guid: 0796af7c-0a7c-417f-8d0d-19f9179dac7a
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection
Help Version: 1.0.0.0
Locale: en-US
---

# Az.DataProtection Module
## Description
Microsoft Azure PowerShell: DataProtection cmdlets

## Az.DataProtection Cmdlets
### [Backup-AzDataProtectionBackupInstanceAdhoc](Backup-AzDataProtectionBackupInstanceAdhoc.md)
Trigger adhoc backup

### [Get-AzDataProtectionBackupInstance](Get-AzDataProtectionBackupInstance.md)
Gets a backup instances belonging to a backup vault

### [Get-AzDataProtectionBackupPolicy](Get-AzDataProtectionBackupPolicy.md)
Gets a backup policy belonging to a backup vault

### [Get-AzDataProtectionBackupVault](Get-AzDataProtectionBackupVault.md)
Returns a resource belonging to a resource group.

### [Get-AzDataProtectionBackupVaultResource](Get-AzDataProtectionBackupVaultResource.md)
Returns resource collection belonging to a subscription.

### [Get-AzDataProtectionBackupVaultStorageSetting](Get-AzDataProtectionBackupVaultStorageSetting.md)
Get Backup Vault storage setting object

### [Get-AzDataProtectionExportJobsOperationResult](Get-AzDataProtectionExportJobsOperationResult.md)
Gets the operation result of operation triggered by Export Jobs API.
If the operation is successful, then it also contains URL of a Blob and a SAS key to access the same.
The blob contains exported jobs in JSON serialized format.

### [Get-AzDataProtectionJob](Get-AzDataProtectionJob.md)
Gets a job with id in a backup vault

### [Get-AzDataProtectionOperationResult](Get-AzDataProtectionOperationResult.md)
Gets the operation result for a resource

### [Get-AzDataProtectionOperationStatus](Get-AzDataProtectionOperationStatus.md)
Gets the operation status for a resource.

### [Get-AzDataProtectionPolicyTemplate](Get-AzDataProtectionPolicyTemplate.md)
Prepares Datasource object for backup

### [Get-AzDataProtectionRecoveryPoint](Get-AzDataProtectionRecoveryPoint.md)
Gets a Recovery Point using recoveryPointId for a Datasource.

### [Get-AzDataProtectionRecoveryPointList](Get-AzDataProtectionRecoveryPointList.md)
Returns a list of Recovery Points for a DataSource in a vault.

### [Get-AzDataProtectionResourceOperationGatekeeper](Get-AzDataProtectionResourceOperationGatekeeper.md)
Returns a ResourceOperationGateKeeper belonging to a resource group.

### [Get-AzDataProtectionResourceOperationGatekeeperResource](Get-AzDataProtectionResourceOperationGatekeeperResource.md)
Returns ResourceOperationGateKeepers collection belonging to a subscription.

### [Get-AzDataProtectionResourceOperationResultPatch](Get-AzDataProtectionResourceOperationResultPatch.md)


### [GetBackupFrequencyString](GetBackupFrequencyString.md)


### [GetDatasourceSetInfo](GetDatasourceSetInfo.md)


### [GetRestoreType](GetRestoreType.md)


### [GetTaggingPriority](GetTaggingPriority.md)


### [Initialize-AzDataProtectionBackupInstance](Initialize-AzDataProtectionBackupInstance.md)
Prepares Backup instance object for backup

### [Initialize-AzDataProtectionTargetRestoreInfo](Initialize-AzDataProtectionTargetRestoreInfo.md)
Get Backup Vault storage setting object

### [LoadManifest](LoadManifest.md)
Prepares Datasource object for backup

### [New-AzDataProtectionPolicyTagCriteria](New-AzDataProtectionPolicyTagCriteria.md)
Prepares Datasource object for backup

### [New-AzDataProtectionPolicyTriggerSchedule](New-AzDataProtectionPolicyTriggerSchedule.md)
Creates new Schedule object

### [New-AzDataProtectionRetentionLifeCycle](New-AzDataProtectionRetentionLifeCycle.md)
Creates new Lifecycle object

### [Remove-AzDataProtectionBackupInstance](Remove-AzDataProtectionBackupInstance.md)


### [Remove-AzDataProtectionBackupPolicy](Remove-AzDataProtectionBackupPolicy.md)
Deletes a backup policy belonging to a backup vault

### [Remove-AzDataProtectionBackupVault](Remove-AzDataProtectionBackupVault.md)
Deletes a BackupVault resource from the resource group.

### [Remove-AzDataProtectionResourceOperationGatekeeper](Remove-AzDataProtectionResourceOperationGatekeeper.md)
Deletes a ResourceOperationGateKeeper resource from the resource group.

### [Set-AzDataProtectionBackupInstance](Set-AzDataProtectionBackupInstance.md)


### [Set-AzDataProtectionBackupPolicy](Set-AzDataProtectionBackupPolicy.md)
Creates or Updates a backup policy belonging to a backup vault

### [Set-AzDataProtectionBackupVault](Set-AzDataProtectionBackupVault.md)
Creates or updates a BackupVault resource belonging to a resource group.

### [Set-AzDataProtectionResourceOperationGatekeeper](Set-AzDataProtectionResourceOperationGatekeeper.md)
Creates or updates a ResourceOperationGatekeeper resource belonging to a resource group.

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

### [TranslateBackupParam](TranslateBackupParam.md)


### [TranslateBackupPolicy](TranslateBackupPolicy.md)


### [TranslateBackupPolicyRule](TranslateBackupPolicyRule.md)


### [TranslateBackupPolicyTagCriteria](TranslateBackupPolicyTagCriteria.md)


### [TranslateBackupPolicyTrigger](TranslateBackupPolicyTrigger.md)


### [TranslatePolicyRetentionLifeCycle](TranslatePolicyRetentionLifeCycle.md)


### [Update-AzDataProtectionBackupVault](Update-AzDataProtectionBackupVault.md)
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

### [Update-AzDataProtectionPolicyRetentionRule](Update-AzDataProtectionPolicyRetentionRule.md)
Adds or removes Retention Rule to existing Policy

### [Update-AzDataProtectionPolicyTag](Update-AzDataProtectionPolicyTag.md)
Prepares Datasource object for backup

### [Update-AzDataProtectionPolicyTrigger](Update-AzDataProtectionPolicyTrigger.md)
Creates new Schedule object

### [Update-AzDataProtectionResourceOperationGatekeeper](Update-AzDataProtectionResourceOperationGatekeeper.md)
Updates a ResourceOperationGatekeeper resource belonging to a resource group.
For example, updating tags for a resource.

