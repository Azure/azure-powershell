### Example 1: Suspends client access to a storage target.
```powershell
Suspend-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Suspends client access to a storage target.

### Example 2: Suspends client access to a storage target.
```powershell
Suspend-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Suspends client access to a storage target.