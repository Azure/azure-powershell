---
Module Name: Azs.Compute.Admin
Module Guid: e662cef1-a477-40a2-ab9f-06e8de7cc423
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# Azs.Compute.Admin Module
## Description
Preview release of the AzureStack Compute administrator module which provides functionality to manage compute quotas, platform images, and virtual machine extensions, as well as managed disks migration jobs to rebalance storage.

## Azs.Compute.Admin Cmdlets
### [Add-AzsPlatformImage](Add-AzsPlatformImage.md)
Add a virtual machine platform image from a given image configuration.

### [Add-AzsVMExtension](Add-AzsVMExtension.md)
Create a new virtual machine extension image.

### [Get-AzsComputeQuota](Get-AzsComputeQuota.md)
Returns quotas specifying the quota limits for compute objects.

### [Get-AzsDisk](Get-AzsDisk.md)
Returns the list of managed disks which can be migrated in the specified share.

### [Get-AzsDiskMigrationJob](Get-AzsDiskMigrationJob.md)
Returns the list of managed disk migration jobs.

### [Get-AzsPlatformImage](Get-AzsPlatformImage.md)
Returns virtual machine images loaded into the platform image repository.

### [Get-AzsVMExtension](Get-AzsVMExtension.md)
Returns virtual machine image extensions currently available.

### [New-AzsComputeQuota](New-AzsComputeQuota.md)
Create a new compute quota used to limit compute resources.

### [New-AzsDiskMigrationJob](New-AzsDiskMigrationJob.md)
Starts a managed disk migration job to migrate managed disks to the specified destination share.

### [New-DataDiskObject](New-DataDiskObject.md)
Creates a data disk which is used to create a new virtual machine platform image.

### [Remove-AzsComputeQuota](Remove-AzsComputeQuota.md)
Deletes specified compute quota.

### [Remove-AzsPlatformImage](Remove-AzsPlatformImage.md)
Delete a virtual machine image from the platform image repository.

### [Remove-AzsVMExtension](Remove-AzsVMExtension.md)
Deletes a virtual machine extension image.

### [Set-AzsComputeQuota](Set-AzsComputeQuota.md)
Update an existing compute quota using the provided parameters.

### [Stop-AzsDiskMigrationJob](Stop-AzsDiskMigrationJob.md)
Cancel a managed disk migration job.

