---
Module Name: Az.DataProtection
Module Guid: e7388191-d3e0-4d54-b898-d55f0992a1dc
Download Help Link: https://learn.microsoft.com/powershell/module/az.dataprotection
Help Version: 1.0.0.0
Locale: en-US
---

# Az.DataProtection Module
## Description
Microsoft Azure PowerShell: DataProtection cmdlets

## Az.DataProtection Cmdlets
### [Backup-AzDataProtectionBackupInstanceAdhoc](Backup-AzDataProtectionBackupInstanceAdhoc.md)
Trigger adhoc backup

### [Edit-AzDataProtectionPolicyRetentionRuleClientObject](Edit-AzDataProtectionPolicyRetentionRuleClientObject.md)
Adds or removes Retention Rule to existing Policy

### [Edit-AzDataProtectionPolicyTagClientObject](Edit-AzDataProtectionPolicyTagClientObject.md)
Adds or removes schedule tag in an existing backup policy.

### [Edit-AzDataProtectionPolicyTriggerClientObject](Edit-AzDataProtectionPolicyTriggerClientObject.md)
Updates Backup schedule of an existing backup policy.

### [Find-AzDataProtectionRestorableTimeRange](Find-AzDataProtectionRestorableTimeRange.md)
Finds the valid recovery point in time ranges for the restore.

### [Get-AzDataProtectionBackupInstance](Get-AzDataProtectionBackupInstance.md)
Gets a backup instance with name in a backup vault

### [Get-AzDataProtectionBackupPolicy](Get-AzDataProtectionBackupPolicy.md)
Gets a backup policy belonging to a backup vault

### [Get-AzDataProtectionBackupVault](Get-AzDataProtectionBackupVault.md)
Returns resource collection belonging to a subscription.

### [Get-AzDataProtectionJob](Get-AzDataProtectionJob.md)
Gets a job with id in a backup vault

### [Get-AzDataProtectionOperation](Get-AzDataProtectionOperation.md)
Returns the list of available operations.

### [Get-AzDataProtectionOperationStatus](Get-AzDataProtectionOperationStatus.md)
Gets the operation status for a resource.

### [Get-AzDataProtectionPolicyTemplate](Get-AzDataProtectionPolicyTemplate.md)
Gets default policy template for a selected datasource type.

### [Get-AzDataProtectionRecoveryPoint](Get-AzDataProtectionRecoveryPoint.md)
Gets a Recovery Point using recoveryPointId for a Datasource.

### [Get-AzDataProtectionResourceGuard](Get-AzDataProtectionResourceGuard.md)
Returns a ResourceGuard belonging to a resource group.

### [Initialize-AzDataProtectionBackupInstance](Initialize-AzDataProtectionBackupInstance.md)
Initializes Backup instance Request object for configuring backup

### [Initialize-AzDataProtectionRestoreRequest](Initialize-AzDataProtectionRestoreRequest.md)
Initializes Restore Request object for triggering restore on a protected backup instance.

### [New-AzDataProtectionBackupConfigurationClientObject](New-AzDataProtectionBackupConfigurationClientObject.md)
Creates new backup configuration object

### [New-AzDataProtectionBackupInstance](New-AzDataProtectionBackupInstance.md)
Configures Backup for supported azure resources

### [New-AzDataProtectionBackupPolicy](New-AzDataProtectionBackupPolicy.md)
Creates a new backup policy in a given backup vault

### [New-AzDataProtectionBackupVault](New-AzDataProtectionBackupVault.md)
Creates or updates a BackupVault resource belonging to a resource group.

### [New-AzDataProtectionBackupVaultStorageSettingObject](New-AzDataProtectionBackupVaultStorageSettingObject.md)
Get Backup Vault storage setting object

### [New-AzDataProtectionPolicyTagCriteriaClientObject](New-AzDataProtectionPolicyTagCriteriaClientObject.md)
Creates a new criteria object

### [New-AzDataProtectionPolicyTriggerScheduleClientObject](New-AzDataProtectionPolicyTriggerScheduleClientObject.md)
Creates new Schedule object

### [New-AzDataProtectionResourceGuard](New-AzDataProtectionResourceGuard.md)
Creates a resource guard under a resource group

### [New-AzDataProtectionRestoreConfigurationClientObject](New-AzDataProtectionRestoreConfigurationClientObject.md)
Creates new restore configuration object

### [New-AzDataProtectionRetentionLifeCycleClientObject](New-AzDataProtectionRetentionLifeCycleClientObject.md)
Creates new Lifecycle object

### [Remove-AzDataProtectionBackupInstance](Remove-AzDataProtectionBackupInstance.md)
Delete a backupInstances

### [Remove-AzDataProtectionBackupPolicy](Remove-AzDataProtectionBackupPolicy.md)
Deletes a backup policy belonging to a backup vault

### [Remove-AzDataProtectionBackupVault](Remove-AzDataProtectionBackupVault.md)
Deletes a BackupVault resource from the resource group.

### [Remove-AzDataProtectionResourceGuard](Remove-AzDataProtectionResourceGuard.md)
Deletes a ResourceGuard resource from the resource group.

### [Resume-AzDataProtectionBackupInstanceProtection](Resume-AzDataProtectionBackupInstanceProtection.md)
This operation will resume protection for a stopped backup instance

### [Search-AzDataProtectionBackupInstanceInAzGraph](Search-AzDataProtectionBackupInstanceInAzGraph.md)
Searches for Backup instances in Azure Resource Graph and retrieves the expected entries

### [Search-AzDataProtectionJobInAzGraph](Search-AzDataProtectionJobInAzGraph.md)
Searches for Backup Jobs in Azure Resource Graph and retrieves the expected entries

### [Set-AzDataProtectionMSIPermission](Set-AzDataProtectionMSIPermission.md)
Grants required permissions to the backup vault and other resources for configure backup and restore scenarios

### [Start-AzDataProtectionBackupInstanceRestore](Start-AzDataProtectionBackupInstanceRestore.md)
Triggers restore for a BackupInstance

### [Stop-AzDataProtectionBackupInstanceProtection](Stop-AzDataProtectionBackupInstanceProtection.md)
This operation will stop protection of a backup instance and data will be held forever

### [Suspend-AzDataProtectionBackupInstanceBackup](Suspend-AzDataProtectionBackupInstanceBackup.md)
This operation will stop backup for a backup instance and retains the backup data as per the policy (except latest Recovery point, which will be retained forever)

### [Sync-AzDataProtectionBackupInstance](Sync-AzDataProtectionBackupInstance.md)
Sync backup instance again in case of failure\r\nThis action will retry last failed operation and will bring backup instance to valid state

### [Test-AzDataProtectionBackupInstanceReadiness](Test-AzDataProtectionBackupInstanceReadiness.md)
Validate whether adhoc backup will be successful or not

### [Test-AzDataProtectionBackupInstanceRestore](Test-AzDataProtectionBackupInstanceRestore.md)
Validates if Restore can be triggered for a DataSource

### [Update-AzDataProtectionBackupInstanceAssociatedPolicy](Update-AzDataProtectionBackupInstanceAssociatedPolicy.md)
Updates associated policy for a given backup instance

### [Update-AzDataProtectionBackupVault](Update-AzDataProtectionBackupVault.md)
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

### [Update-AzDataProtectionResourceGuard](Update-AzDataProtectionResourceGuard.md)
Updates a resource guard belonging to a resource group

