---
Module Name: Az.ImportExport
Module Guid: bd61e1bb-7e88-4aea-9050-d637c7cfcecd
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.importexport
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ImportExport Module
## Description
Microsoft Azure PowerShell: ImportExport cmdlets

## Az.ImportExport Cmdlets
### [Get-AzImportExport](Get-AzImportExport.md)
Gets information about an existing job.

### [Get-AzImportExportBitLockerKey](Get-AzImportExportBitLockerKey.md)
Returns the BitLocker Keys for all drives in the specified job.

### [Get-AzImportExportLocation](Get-AzImportExportLocation.md)
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.

### [New-AzImportExport](New-AzImportExport.md)
Creates a new job or updates an existing job in the specified subscription.

### [New-AzImportExportDriveListObject](New-AzImportExportDriveListObject.md)
Create a DriverList Object for ImportExport.

### [Remove-AzImportExport](Remove-AzImportExport.md)
Deletes an existing job.
Only jobs in the Creating or Completed states can be deleted.

### [Update-AzImportExport](Update-AzImportExport.md)
Updates specific properties of a job.
You can call this operation to notify the Import/Export service that the hard drives comprising the import or export job have been shipped to the Microsoft data center.
It can also be used to cancel an existing job.

