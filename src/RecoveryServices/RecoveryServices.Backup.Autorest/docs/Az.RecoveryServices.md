---
Module Name: Az.RecoveryServices
Module Guid: 37eaf44e-78f7-4a5a-82d1-f6350681704b
Download Help Link: https://learn.microsoft.com/powershell/module/az.recoveryservices
Help Version: 1.0.0.0
Locale: en-US
---

# Az.RecoveryServices Module
## Description
Microsoft Azure PowerShell: RecoveryServices cmdlets

## Az.RecoveryServices Cmdlets
### [Edit-AzRecoveryServicesBackupRetentionPolicyClientObject](Edit-AzRecoveryServicesBackupRetentionPolicyClientObject.md)
Edits the retention settings for the policy client object

### [Edit-AzRecoveryServicesBackupSchedulePolicyClientObject](Edit-AzRecoveryServicesBackupSchedulePolicyClientObject.md)
Edits the schedule policy in the specified backup policy object.

### [Get-AzRecoveryServicesBackupContainer](Get-AzRecoveryServicesBackupContainer.md)
Gets list of backup containers registered with a recovery services vault

### [Get-AzRecoveryServicesBackupItem](Get-AzRecoveryServicesBackupItem.md)
Gets list of backup items protected with a recovery services vault

### [Get-AzRecoveryServicesBackupProtectableItem](Get-AzRecoveryServicesBackupProtectableItem.md)
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

### [Get-AzRecoveryServicesBackupProtectionPolicy](Get-AzRecoveryServicesBackupProtectionPolicy.md)
Gets backup protection policies for a recovery services vault.

### [Get-AzRecoveryServicesPolicyTemplate](Get-AzRecoveryServicesPolicyTemplate.md)
Gets default policy template for a selected datasource type.

### [New-AzRecoveryServicesBackupProtectionPolicy](New-AzRecoveryServicesBackupProtectionPolicy.md)
Creates a new backup policy in a given recovery services vault

### [Register-AzRecoveryServicesBackupContainer](Register-AzRecoveryServicesBackupContainer.md)
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

### [Remove-AzRecoveryServicesBackupProtectionPolicy](Remove-AzRecoveryServicesBackupProtectionPolicy.md)
Deletes specified backup policy from your Recovery Services Vault.
This is an asynchronous operation.
Status of the\r\noperation can be fetched using GetProtectionPolicyOperationResult API.

