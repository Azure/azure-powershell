---
Module Name: Az.StorageCache
Module Guid: 9395bf43-a8b4-47a1-824a-e95db99933f3
Download Help Link: https://learn.microsoft.com/powershell/module/az.storagecache
Help Version: 1.0.0.0
Locale: en-US
---

# Az.StorageCache Module
## Description
Microsoft Azure PowerShell: StorageCache cmdlets

## Az.StorageCache Cmdlets
### [Clear-AzStorageCacheCach](Clear-AzStorageCacheCach.md)
Tells a cache to write all dirty data to the Storage Target(s).
During the flush, clients will see errors returned until the flush is complete.

### [Clear-AzStorageCacheStorageTarget](Clear-AzStorageCacheStorageTarget.md)
Tells the cache to write all dirty data to the Storage Target's backend storage.
Client requests to this storage target's namespace will return errors until the flush operation completes.

### [Debug-AzStorageCacheCachInfo](Debug-AzStorageCacheCachInfo.md)
Tells a cache to write generate debug info for support to process.

### [Get-AzStorageCacheAmlFileSystem](Get-AzStorageCacheAmlFileSystem.md)
Returns an AML file system.

### [Get-AzStorageCacheAmlFileSystemSubnetRequiredSize](Get-AzStorageCacheAmlFileSystemSubnetRequiredSize.md)
Get the number of available IP addresses needed for the AML file system information provided.

### [Get-AzStorageCacheAscUsage](Get-AzStorageCacheAscUsage.md)
Gets the quantity used and quota limit for resources

### [Get-AzStorageCacheAutoExportJob](Get-AzStorageCacheAutoExportJob.md)
Returns an auto export job.

### [Get-AzStorageCacheAutoImportJob](Get-AzStorageCacheAutoImportJob.md)
Returns an auto import job.

### [Get-AzStorageCacheCach](Get-AzStorageCacheCach.md)
Returns a cache.

### [Get-AzStorageCacheImportJob](Get-AzStorageCacheImportJob.md)
Returns an import job.

### [Get-AzStorageCacheSku](Get-AzStorageCacheSku.md)
Get the list of StorageCache.Cache SKUs available to this subscription.

### [Get-AzStorageCacheStorageTarget](Get-AzStorageCacheStorageTarget.md)
Returns a Storage Target from a cache.

### [Get-AzStorageCacheUsageModel](Get-AzStorageCacheUsageModel.md)
Get the list of cache usage models available to this subscription.

### [Invoke-AzStorageCacheAmlFileSystemArchive](Invoke-AzStorageCacheAmlFileSystemArchive.md)
Archive data from the AML file system.

### [Invoke-AzStorageCacheInvalidateStorageTarget](Invoke-AzStorageCacheInvalidateStorageTarget.md)
Invalidate all cached data for a storage target.
Cached files are discarded and fetched from the back end on the next request.

### [Invoke-AzStorageCacheSpaceCachAllocation](Invoke-AzStorageCacheSpaceCachAllocation.md)
Space cache space allocation.

### [New-AzStorageCacheAmlFileSystem](New-AzStorageCacheAmlFileSystem.md)
Create an AML file system.

### [New-AzStorageCacheAutoExportJob](New-AzStorageCacheAutoExportJob.md)
Create an auto export job.

### [New-AzStorageCacheAutoImportJob](New-AzStorageCacheAutoImportJob.md)
Create an auto import job.

### [New-AzStorageCacheCach](New-AzStorageCacheCach.md)
Create a cache.

### [New-AzStorageCacheImportJob](New-AzStorageCacheImportJob.md)
Create an import job.

### [New-AzStorageCacheStorageTarget](New-AzStorageCacheStorageTarget.md)
Create a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

### [Remove-AzStorageCacheAmlFileSystem](Remove-AzStorageCacheAmlFileSystem.md)
Schedules an AML file system for deletion.

### [Remove-AzStorageCacheAutoExportJob](Remove-AzStorageCacheAutoExportJob.md)
Schedules an auto export job for deletion.

### [Remove-AzStorageCacheAutoImportJob](Remove-AzStorageCacheAutoImportJob.md)
Schedules an auto import job for deletion.

### [Remove-AzStorageCacheCach](Remove-AzStorageCacheCach.md)
Schedules a cache for deletion.

### [Remove-AzStorageCacheImportJob](Remove-AzStorageCacheImportJob.md)
Schedules an import job for deletion.

### [Remove-AzStorageCacheStorageTarget](Remove-AzStorageCacheStorageTarget.md)
Removes a Storage Target from a cache.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual removal of the Storage Target may be delayed until the cache is healthy again.
Note that if the cache has data to flush to the Storage Target, the data will be flushed before the Storage Target will be deleted.

### [Restore-AzStorageCacheStorageTargetDefault](Restore-AzStorageCacheStorageTargetDefault.md)
Tells a storage target to restore its settings to their default values.

### [Resume-AzStorageCacheCachPrimingJob](Resume-AzStorageCacheCachPrimingJob.md)
Resumes a paused priming job.

### [Resume-AzStorageCacheStorageTarget](Resume-AzStorageCacheStorageTarget.md)
Resumes client access to a previously suspended storage target.

### [Start-AzStorageCacheCach](Start-AzStorageCacheCach.md)
Tells a Stopped state cache to transition to Active state.

### [Start-AzStorageCacheCachPrimingJob](Start-AzStorageCacheCachPrimingJob.md)
Start a priming job.
This operation is only allowed when the cache is healthy.

### [Stop-AzStorageCacheAmlFilesystemArchive](Stop-AzStorageCacheAmlFilesystemArchive.md)
Cancel archiving data from the AML file system.

### [Stop-AzStorageCacheCach](Stop-AzStorageCacheCach.md)
Tells an Active cache to transition to Stopped state.

### [Stop-AzStorageCacheCachPrimingJob](Stop-AzStorageCacheCachPrimingJob.md)
Schedule a priming job for deletion.

### [Suspend-AzStorageCacheCachPrimingJob](Suspend-AzStorageCacheCachPrimingJob.md)
Schedule a priming job to be paused.

### [Suspend-AzStorageCacheStorageTarget](Suspend-AzStorageCacheStorageTarget.md)
Suspends client access to a storage target.

### [Test-AzStorageCacheAmlFileSystemSubnet](Test-AzStorageCacheAmlFileSystemSubnet.md)
Check that subnets will be valid for AML file system check calls.

### [Update-AzStorageCacheAmlFileSystem](Update-AzStorageCacheAmlFileSystem.md)
Update an AML file system instance.

### [Update-AzStorageCacheAutoExportJob](Update-AzStorageCacheAutoExportJob.md)
Update an auto export job instance.

### [Update-AzStorageCacheAutoImportJob](Update-AzStorageCacheAutoImportJob.md)
Update an auto import job instance.

### [Update-AzStorageCacheCach](Update-AzStorageCacheCach.md)
Update a cache.

### [Update-AzStorageCacheCachFirmware](Update-AzStorageCacheCachFirmware.md)
Upgrade a cache's firmware if a new version is available.
Otherwise, this operation has no effect.

### [Update-AzStorageCacheImportJob](Update-AzStorageCacheImportJob.md)
Update an import job instance.

### [Update-AzStorageCacheStorageTarget](Update-AzStorageCacheStorageTarget.md)
Update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

### [Update-AzStorageCacheStorageTargetDns](Update-AzStorageCacheStorageTargetDns.md)
Tells a storage target to refresh its DNS information.

