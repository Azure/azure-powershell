### Example 1: Removes a Storage Target from a cache.
```powershell
Remove-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Removes a Storage Target from a cache.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual removal of the Storage Target may be delayed until the cache is healthy again.
Note that if the cache has data to flush to the Storage Target, the data will be flushed before the Storage Target will be deleted.

### Example 2: Removes a Storage Target from a cache.
```powershell
Get-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache | Remove-AzStorageCacheTarget
```

Removes a Storage Target from a cache.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual removal of the Storage Target may be delayed until the cache is healthy again.
Note that if the cache has data to flush to the Storage Target, the data will be flushed before the Storage Target will be deleted.