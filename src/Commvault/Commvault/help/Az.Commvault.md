---
Module Name: Az.Commvault
Module Guid: accceef6-8113-453a-a31c-4f2ce57893d6
Download Help Link: https://learn.microsoft.com/powershell/module/az.commvault
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Commvault Module
## Description
Microsoft Azure PowerShell: Commvault cmdlets

## Az.Commvault Cmdlets
### [Backup-AzCommvaultProtectionGroup](Backup-AzCommvaultProtectionGroup.md)
Ad-hoc backup of protected items resource in given protection group.

### [Connect-AzCommvaultCloudAccountSaaS](Connect-AzCommvaultCloudAccountSaaS.md)
Links a new SaaS to the cloud account.

### [Disable-AzCommvaultStorageComplianceLock](Disable-AzCommvaultStorageComplianceLock.md)
Disable compliance lock on the storage.
Initiates an out-of-band multi-person authorization (MPA) email approval workflow on the partner side.
The storage compliance lock status transitions to 'DisablementPending' immediately; once the MPA approval completes, the status becomes 'Disabled' (observable via the refresh action).

### [Enable-AzCommvaultStorageComplianceLock](Enable-AzCommvaultStorageComplianceLock.md)
Enable compliance lock on the storage.
Synchronous operation.

### [Get-AzCommvaultCloudAccount](Get-AzCommvaultCloudAccount.md)
Get a CloudAccount

### [Get-AzCommvaultCloudAccountLatestLinkedSaaS](Get-AzCommvaultCloudAccountLatestLinkedSaaS.md)
Returns the latest SaaS linked to the cloud account.

### [Get-AzCommvaultPlan](Get-AzCommvaultPlan.md)
Get a CommvaultPlan

### [Get-AzCommvaultProtectedItem](Get-AzCommvaultProtectedItem.md)
Get a ProtectedItem

### [Get-AzCommvaultProtectedItemCount](Get-AzCommvaultProtectedItemCount.md)
Gets the count of protected items for provided CCA resource IDs across subscriptions.

### [Get-AzCommvaultProtectedItemRestorePoint](Get-AzCommvaultProtectedItemRestorePoint.md)
Gets the restore points that are available for a protected item.

### [Get-AzCommvaultProtectionGroup](Get-AzCommvaultProtectionGroup.md)
Get a ProtectionGroup

### [Get-AzCommvaultRoleMapping](Get-AzCommvaultRoleMapping.md)
Get a RoleMapping

### [Get-AzCommvaultStorage](Get-AzCommvaultStorage.md)
Get a Storage

### [Initialize-AzCommvaultSaaS](Initialize-AzCommvaultSaaS.md)
Resolve the token to get the SaaS resource ID and activate the SaaS resource

### [New-AzCommvaultCloudAccount](New-AzCommvaultCloudAccount.md)
Create a CloudAccount

### [New-AzCommvaultPlan](New-AzCommvaultPlan.md)
Create a CommvaultPlan

### [New-AzCommvaultProtectionGroup](New-AzCommvaultProtectionGroup.md)
Create a ProtectionGroup

### [New-AzCommvaultRoleMapping](New-AzCommvaultRoleMapping.md)
Create a RoleMapping

### [New-AzCommvaultStorage](New-AzCommvaultStorage.md)
Create a Storage

### [Remove-AzCommvaultCloudAccount](Remove-AzCommvaultCloudAccount.md)
Delete a CloudAccount

### [Remove-AzCommvaultPlan](Remove-AzCommvaultPlan.md)
Delete a CommvaultPlan

### [Remove-AzCommvaultProtectionGroup](Remove-AzCommvaultProtectionGroup.md)
Delete a ProtectionGroup

### [Remove-AzCommvaultRoleMapping](Remove-AzCommvaultRoleMapping.md)
Delete a RoleMapping

### [Remove-AzCommvaultStorage](Remove-AzCommvaultStorage.md)
Delete a Storage

### [Restore-AzCommvaultProtectedItem](Restore-AzCommvaultProtectedItem.md)
Restore resource for a protected item.

### [Restore-AzCommvaultProtectionGroup](Restore-AzCommvaultProtectionGroup.md)
Restore resource for a protected items in given protection group.

### [Resume-AzCommvaultProtectionGroupBackup](Resume-AzCommvaultProtectionGroupBackup.md)
Resume Backup for a Protection Group.

### [Stop-AzCommvaultProtectionGroupBackup](Stop-AzCommvaultProtectionGroupBackup.md)
Stop Backup for a Protection Group

### [Sync-AzCommvaultStorage](Sync-AzCommvaultStorage.md)
Refresh storage state from partner.
Fetches latest compliance lock status from Commvault and refresh the ARM resource.

### [Update-AzCommvaultCloudAccount](Update-AzCommvaultCloudAccount.md)
Update a CloudAccount

### [Update-AzCommvaultPlan](Update-AzCommvaultPlan.md)
Update a CommvaultPlan

### [Update-AzCommvaultProtectionGroup](Update-AzCommvaultProtectionGroup.md)
Update a ProtectionGroup

### [Update-AzCommvaultRoleMapping](Update-AzCommvaultRoleMapping.md)
Update a RoleMapping

### [Update-AzCommvaultStorage](Update-AzCommvaultStorage.md)
Update a Storage

