### Example 1: Tells a storage target to refresh its DNS information.
```powershell
Update-AzStorageCacheTargetDns -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -StorageTargetName azps-cachetarget
```

Tells a storage target to refresh its DNS information.

### Example 2: Tells a storage target to refresh its DNS information.
```powershell
Update-AzStorageCacheTargetDns -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -StorageTargetName azps-cachetarget -PassThru
```

```output
True
```

Tells a storage target to refresh its DNS information.