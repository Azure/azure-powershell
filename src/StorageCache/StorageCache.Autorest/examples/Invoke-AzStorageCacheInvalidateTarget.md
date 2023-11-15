### Example 1: Invalidate all cached data for a storage target.
```powershell
Invoke-AzStorageCacheInvalidateTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -StorageTargetName azps-cachetarget
```

Invalidate all cached data for a storage target.
Cached files are discarded and fetched from the back end on the next request.

### Example 2: Invalidate all cached data for a storage target.
```powershell
Invoke-AzStorageCacheInvalidateTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -StorageTargetName azps-cachetarget -PassThru
```

```output
True
```

Invalidate all cached data for a storage target.
Cached files are discarded and fetched from the back end on the next request.