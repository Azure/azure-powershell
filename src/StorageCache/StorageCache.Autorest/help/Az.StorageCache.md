---
Module Name: Az.StorageCache
Module Guid: 113964d9-7d75-4a3d-ac1c-0014ed44358b
Download Help Link: https://learn.microsoft.com/powershell/module/az.storagecache
Help Version: 1.0.0.0
Locale: en-US
---

# Az.StorageCache Module
## Description
Microsoft Azure PowerShell: StorageCache cmdlets

## Az.StorageCache Cmdlets
### [Clear-AzStorageCache](Clear-AzStorageCache.md)
Tells a cache to write all dirty data to the Storage Target(s).
During the flush, clients will see errors returned until the flush is complete.

### [Clear-AzStorageCacheTarget](Clear-AzStorageCacheTarget.md)
Tells the cache to write all dirty data to the Storage Target's backend storage.
Client requests to this storage target's namespace will return errors until the flush operation completes.

### [Debug-AzStorageCache](Debug-AzStorageCache.md)
Tells a cache to write generate debug info for support to process.

### [Get-AzStorageCache](Get-AzStorageCache.md)
Returns a cache.

### [Get-AzStorageCacheAmlFileSystem](Get-AzStorageCacheAmlFileSystem.md)
Returns an AML file system.

### [Get-AzStorageCacheAmlFileSystemSubnetRequiredSize](Get-AzStorageCacheAmlFileSystemSubnetRequiredSize.md)
Get the number of available IP addresses needed for the AML file system information provided.

### [Get-AzStorageCacheAscUsage](Get-AzStorageCacheAscUsage.md)
Gets the quantity used and quota limit for resources

### [Get-AzStorageCacheSku](Get-AzStorageCacheSku.md)
Get the list of StorageCache.Cache SKUs available to this subscription.

### [Get-AzStorageCacheTarget](Get-AzStorageCacheTarget.md)
Returns a Storage Target from a cache.

### [Get-AzStorageCacheUsageModel](Get-AzStorageCacheUsageModel.md)
Get the list of cache usage models available to this subscription.

### [Invoke-AzStorageCacheAmlFileSystemArchive](Invoke-AzStorageCacheAmlFileSystemArchive.md)
Archive data from the AML file system.

### [Invoke-AzStorageCacheInvalidateTarget](Invoke-AzStorageCacheInvalidateTarget.md)
Invalidate all cached data for a storage target.
Cached files are discarded and fetched from the back end on the next request.

### [New-AzStorageCache](New-AzStorageCache.md)
Create or update a cache.

### [New-AzStorageCacheAmlFileSystem](New-AzStorageCacheAmlFileSystem.md)
Create or update an AML file system.

### [New-AzStorageCacheDirectorySettingObject](New-AzStorageCacheDirectorySettingObject.md)
Create an in-memory object for CacheDirectorySettings.

### [New-AzStorageCacheNamespaceJunctionObject](New-AzStorageCacheNamespaceJunctionObject.md)
Create an in-memory object for NamespaceJunction.

### [New-AzStorageCacheNfsAccessPolicyObject](New-AzStorageCacheNfsAccessPolicyObject.md)
Create an in-memory object for NfsAccessPolicy.

### [New-AzStorageCacheNfsAccessRuleObject](New-AzStorageCacheNfsAccessRuleObject.md)
Create an in-memory object for NfsAccessRule.

### [New-AzStorageCachePrimingJobObject](New-AzStorageCachePrimingJobObject.md)
Create an in-memory object for PrimingJob.

### [New-AzStorageCacheTarget](New-AzStorageCacheTarget.md)
Create or update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.

### [New-AzStorageCacheTargetSpaceAllocationObject](New-AzStorageCacheTargetSpaceAllocationObject.md)
Create an in-memory object for StorageTargetSpaceAllocation.

### [Remove-AzStorageCache](Remove-AzStorageCache.md)
Schedules a cache for deletion.

### [Remove-AzStorageCacheAmlFileSystem](Remove-AzStorageCacheAmlFileSystem.md)
Schedules an AML file system for deletion.

### [Remove-AzStorageCacheTarget](Remove-AzStorageCacheTarget.md)
Removes a Storage Target from a cache.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual removal of the Storage Target may be delayed until the cache is healthy again.
Note that if the cache has data to flush to the Storage Target, the data will be flushed before the Storage Target will be deleted.

### [Restore-AzStorageCacheTargetSetting](Restore-AzStorageCacheTargetSetting.md)
Tells a storage target to restore its settings to their default values.

### [Resume-AzStorageCachePrimingJob](Resume-AzStorageCachePrimingJob.md)
Resumes a paused priming job.

### [Resume-AzStorageCacheTarget](Resume-AzStorageCacheTarget.md)
Resumes client access to a previously suspended storage target.

### [Start-AzStorageCache](Start-AzStorageCache.md)
Tells a Stopped state cache to transition to Active state.

### [Start-AzStorageCachePrimingJob](Start-AzStorageCachePrimingJob.md)
Create a priming job.
This operation is only allowed when the cache is healthy.

### [Stop-AzStorageCache](Stop-AzStorageCache.md)
Tells an Active cache to transition to Stopped state.

### [Stop-AzStorageCacheAmlFilesystemArchive](Stop-AzStorageCacheAmlFilesystemArchive.md)
Cancel archiving data from the AML file system.

### [Stop-AzStorageCachePrimingJob](Stop-AzStorageCachePrimingJob.md)
Schedule a priming job for deletion.

### [Suspend-AzStorageCachePrimingJob](Suspend-AzStorageCachePrimingJob.md)
Schedule a priming job to be paused.

### [Suspend-AzStorageCacheTarget](Suspend-AzStorageCacheTarget.md)
Suspends client access to a storage target.

### [Test-AzStorageCacheAmlFileSystemSubnet](Test-AzStorageCacheAmlFileSystemSubnet.md)
Check that subnets will be valid for AML file system create calls.

### [Update-AzStorageCache](Update-AzStorageCache.md)
Update a cache instance.

### [Update-AzStorageCacheAmlFileSystem](Update-AzStorageCacheAmlFileSystem.md)
Update an AML file system instance.

### [Update-AzStorageCacheFirmware](Update-AzStorageCacheFirmware.md)
Upgrade a cache's firmware if a new version is available.
Otherwise, this operation has no effect.

### [Update-AzStorageCacheSpaceAllocation](Update-AzStorageCacheSpaceAllocation.md)
Update cache space allocation.

### [Update-AzStorageCacheTargetDns](Update-AzStorageCacheTargetDns.md)
Tells a storage target to refresh its DNS information.

