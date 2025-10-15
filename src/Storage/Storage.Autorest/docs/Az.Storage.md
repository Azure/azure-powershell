---
Module Name: Az.Storage
Module Guid: 4deee175-f94f-4dfd-80d5-fd7c43018494
Download Help Link: https://learn.microsoft.com/powershell/module/az.storage
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Storage Module
## Description
Microsoft Azure PowerShell: Storage cmdlets

## Az.Storage Cmdlets
### [Get-AzStorageAccountMigration](Get-AzStorageAccountMigration.md)
Gets the status of the ongoing migration for the specified storage account.

### [Get-AzStorageFileServiceUsage](Get-AzStorageFileServiceUsage.md)
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

### [Get-AzStorageSku](Get-AzStorageSku.md)
Lists the available SKUs supported by Microsoft.Storage for given subscription.

### [Get-AzStorageTaskAssignment](Get-AzStorageTaskAssignment.md)
Get the storage task assignment properties

### [Get-AzStorageTaskAssignmentInstancesReport](Get-AzStorageTaskAssignmentInstancesReport.md)
Fetch the report summary of a single storage task assignment's instances

### [New-AzStorageTaskAssignment](New-AzStorageTaskAssignment.md)
Asynchronously create a new storage task assignment sub-resource with the specified parameters.
If a storage task assignment is already created and a subsequent create request is issued with different properties, the storage task assignment properties will be updated.
If a storage task assignment is already created and a subsequent create request is issued with the exact same set of properties, the request will succeed.

### [Remove-AzStorageTaskAssignment](Remove-AzStorageTaskAssignment.md)
Delete the storage task assignment sub-resource

### [Start-AzStorageAccountMigration](Start-AzStorageAccountMigration.md)
Account Migration request can be triggered for a storage account to change its redundancy level.
The migration updates the non-zonal redundant storage account to a zonal redundant account or vice-versa in order to have better reliability and availability.
Zone-redundant storage (ZRS) replicates your storage account synchronously across three Azure availability zones in the primary region.

### [Update-AzStorageTaskAssignment](Update-AzStorageTaskAssignment.md)
Update storage task assignment properties

