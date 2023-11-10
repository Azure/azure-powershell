### Example 1: Upgrade a cache's firmware if a new version is available.
```powershell
Update-AzStorageCacheFirmware -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

Upgrade a cache's firmware if a new version is available.
Otherwise, this operation has no effect.

### Example 2: Upgrade a cache's firmware if a new version is available.
```powershell
Update-AzStorageCacheFirmware -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Upgrade a cache's firmware if a new version is available.
Otherwise, this operation has no effect.