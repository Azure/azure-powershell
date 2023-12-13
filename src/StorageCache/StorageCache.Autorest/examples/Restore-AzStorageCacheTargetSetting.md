### Example 1: Tells a storage target to restore its settings to their default values.
```powershell
Restore-AzStorageCacheTargetSetting -CacheName azps-storagecache -StorageTargetName azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Tells a storage target to restore its settings to their default values.

### Example 2: Tells a storage target to restore its settings to their default values.
```powershell
Restore-AzStorageCacheTargetSetting -CacheName azps-storagecache -StorageTargetName azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Tells a storage target to restore its settings to their default values.