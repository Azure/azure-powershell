---
Module Name: HpcCache
Module Guid: 5644f9a4-c709-49fc-b6ae-afce8fdc21f3
Download Help Link: https://docs.microsoft.com/powershell/module/hpccache
Help Version: 1.0.0.0
Locale: en-US
---

# HpcCache Module
## Description
Microsoft Azure PowerShell: HpcCache cmdlets

## HpcCache Cmdlets
### [Clear-AzHpcCacheCach](Clear-AzHpcCacheCach.md)
Tells a Cache to write all dirty data to the Storage Target(s).
During the flush, clients will see errors returned until the flush is complete.

### [Debug-AzHpcCacheCachInfo](Debug-AzHpcCacheCachInfo.md)
Tells a Cache to write generate debug info for support to process.

### [Get-AzHpcCacheAscOperation](Get-AzHpcCacheAscOperation.md)
Gets the status of an asynchronous operation for the Azure HPC Cache

### [Get-AzHpcCacheCach](Get-AzHpcCacheCach.md)
Returns a Cache.

### [Get-AzHpcCacheSku](Get-AzHpcCacheSku.md)
Get the list of StorageCache.Cache SKUs available to this subscription.

### [Get-AzHpcCacheStorageTarget](Get-AzHpcCacheStorageTarget.md)
Returns a Storage Target from a Cache.

### [Get-AzHpcCacheUsageModel](Get-AzHpcCacheUsageModel.md)
Get the list of Cache Usage Models available to this subscription.

### [New-AzHpcCacheCach](New-AzHpcCacheCach.md)
Create or update a Cache.

### [New-AzHpcCacheCacheDirectorySettingsObject](New-AzHpcCacheCacheDirectorySettingsObject.md)
Create a in-memory object for CacheDirectorySettings

### [New-AzHpcCacheNamespaceJunctionObject](New-AzHpcCacheNamespaceJunctionObject.md)
Create a in-memory object for NamespaceJunction

### [New-AzHpcCacheNfsAccessPolicyObject](New-AzHpcCacheNfsAccessPolicyObject.md)
Create a in-memory object for NfsAccessPolicy

### [New-AzHpcCacheNfsAccessRuleObject](New-AzHpcCacheNfsAccessRuleObject.md)
Create a in-memory object for NfsAccessRule

### [New-AzHpcCacheStorageTarget](New-AzHpcCacheStorageTarget.md)
Create or update a Storage Target.
This operation is allowed at any time, but if the Cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the Cache is healthy again.

### [Remove-AzHpcCacheCach](Remove-AzHpcCacheCach.md)
Schedules a Cache for deletion.

### [Remove-AzHpcCacheStorageTarget](Remove-AzHpcCacheStorageTarget.md)
Removes a Storage Target from a Cache.
This operation is allowed at any time, but if the Cache is down or unhealthy, the actual removal of the Storage Target may be delayed until the Cache is healthy again.
Note that if the Cache has data to flush to the Storage Target, the data will be flushed before the Storage Target will be deleted.

### [Set-AzHpcCacheCach](Set-AzHpcCacheCach.md)
Create or update a Cache.

### [Set-AzHpcCacheStorageTarget](Set-AzHpcCacheStorageTarget.md)
Create or update a Storage Target.
This operation is allowed at any time, but if the Cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the Cache is healthy again.

### [Start-AzHpcCacheCach](Start-AzHpcCacheCach.md)
Tells a Stopped state Cache to transition to Active state.

### [Stop-AzHpcCacheCach](Stop-AzHpcCacheCach.md)
Tells an Active Cache to transition to Stopped state.

### [Update-AzHpcCacheCach](Update-AzHpcCacheCach.md)
Update a Cache instance.

### [Update-AzHpcCacheCachFirmware](Update-AzHpcCacheCachFirmware.md)
Upgrade a Cache's firmware if a new version is available.
Otherwise, this operation has no effect.

### [Update-AzHpcCacheStorageTargetDns](Update-AzHpcCacheStorageTargetDns.md)
Tells a storage target to refresh its DNS information.

