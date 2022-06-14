---
Module Name: Az.StorageImportExport
Module Guid: da08a47b-30d4-4dcd-b798-b03c081f6ae3
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.storageimportexport
Help Version: 1.0.0.0
Locale: en-US
---

# Az.StorageImportExport Module
## Description
Microsoft Azure PowerShell: StorageImportExport cmdlets

## Az.StorageImportExport Cmdlets
### [Get-AzStorageImportExportBitLockerKey](Get-AzStorageImportExportBitLockerKey.md)
Returns the BitLocker Keys for all drives in the specified job.

### [Get-AzStorageImportExportJob](Get-AzStorageImportExportJob.md)
Gets information about an existing job.

### [Get-AzStorageImportExportLocation](Get-AzStorageImportExportLocation.md)
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.

### [New-AzStorageImportExportJob](New-AzStorageImportExportJob.md)
Creates a new job or updates an existing job in the specified subscription.

### [Remove-AzStorageImportExportJob](Remove-AzStorageImportExportJob.md)
Deletes an existing job.
Only jobs in the Creating or Completed states can be deleted.

### [Update-AzStorageImportExportJob](Update-AzStorageImportExportJob.md)
Updates specific properties of a job.
You can call this operation to notify the Import/Export service that the hard drives comprising the import or export job have been shipped to the Microsoft data center.
It can also be used to cancel an existing job.

