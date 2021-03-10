---
Module Name: Az.DataProtection
Module Guid: f93d4912-a7fb-4df5-a251-edc09c325452
Download Help Link: https://docs.microsoft.com/powershell/module/az.dataprotection
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

### [Get-AzDataProtectionRecoveryPoint](Get-AzDataProtectionRecoveryPoint.md)
Gets a Recovery Point using recoveryPointId for a Datasource.

### [Remove-AzDataProtectionBackupInstance](Remove-AzDataProtectionBackupInstance.md)


### [Remove-AzDataProtectionBackupPolicy](Remove-AzDataProtectionBackupPolicy.md)
Deletes a backup policy belonging to a backup vault

### [Remove-AzDataProtectionBackupVault](Remove-AzDataProtectionBackupVault.md)
Deletes a BackupVault resource from the resource group.

### [Set-AzDataProtectionBackupInstance](Set-AzDataProtectionBackupInstance.md)


### [Set-AzDataProtectionBackupVault](Set-AzDataProtectionBackupVault.md)
Creates or updates a BackupVault resource belonging to a resource group.

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

