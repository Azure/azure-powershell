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

### [Enable-AzRecoveryServicesBackupProtection](Enable-AzRecoveryServicesBackupProtection.md)
Triggers the enable protection operation for the given item

### [Get-AzRecoveryServicesBackupContainer](Get-AzRecoveryServicesBackupContainer.md)
Gets list of backup containers registered with a recovery services vault

### [Get-AzRecoveryServicesBackupItem](Get-AzRecoveryServicesBackupItem.md)
Gets list of backup items protected with a recovery services vault

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

### [Get-AzRecoveryServicesBackupProtectableItem](Get-AzRecoveryServicesBackupProtectableItem.md)
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

### [Get-AzRecoveryServicesBackupProtectionPolicy](Get-AzRecoveryServicesBackupProtectionPolicy.md)
Gets backup protection policies for a recovery services vault.

### [Get-AzRecoveryServicesBackupStatus](Get-AzRecoveryServicesBackupStatus.md)
Get the container backup status

### [Get-AzRecoveryServicesOperationStatus](Get-AzRecoveryServicesOperationStatus.md)
Fetches operation status for data move operation on vault

### [Get-AzRecoveryServicesPolicyTemplate](Get-AzRecoveryServicesPolicyTemplate.md)
Gets default policy template for a selected datasource type.

### [Get-AzRecoveryServicesProtectionContainerOperationResult](Get-AzRecoveryServicesProtectionContainerOperationResult.md)
Fetches the result of any operation on the container.

### [Get-AzRecoveryServicesProtectionContainerRefreshOperationResult](Get-AzRecoveryServicesProtectionContainerRefreshOperationResult.md)
Provides the result of the refresh operation triggered by the BeginRefresh operation.

### [Get-AzRecoveryServicesProtectionPolicyOperationResult](Get-AzRecoveryServicesProtectionPolicyOperationResult.md)
Provides the result of an operation.

### [Get-AzRecoveryServicesProtectionPolicyOperationStatuses](Get-AzRecoveryServicesProtectionPolicyOperationStatuses.md)
Provides the status of the asynchronous operations like backup, restore.
The status can be in progress, completed\r\nor failed.
You can refer to the Operation Status enum for all the possible states of an operation.
Some operations\r\ncreate jobs.
This method returns the list of jobs associated with operation.

### [New-AzRecoveryServicesBackupProtectionPolicy](New-AzRecoveryServicesBackupProtectionPolicy.md)
Creates a new backup policy in a given recovery services vault

### [Register-AzRecoveryServicesBackupContainer](Register-AzRecoveryServicesBackupContainer.md)
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

### [Remove-AzRecoveryServicesBackupProtectionPolicy](Remove-AzRecoveryServicesBackupProtectionPolicy.md)
Deletes specified backup policy from your Recovery Services Vault.
This is an asynchronous operation.
Status of the\r\noperation can be fetched using GetProtectionPolicyOperationResult API.

### [Unregister-AzRecoveryServicesBackupContainer](Unregister-AzRecoveryServicesBackupContainer.md)
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

