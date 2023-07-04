### Example 1: Tells the cache to write all dirty data to the Storage Target's backend storage.
```powershell
Clear-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Tells the cache to write all dirty data to the Storage Target's backend storage.
Client requests to this storage target's namespace will return errors until the flush operation completes.

### Example 2: Tells the cache to write all dirty data to the Storage Target's backend storage.
```powershell
Clear-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Tells the cache to write all dirty data to the Storage Target's backend storage.
Client requests to this storage target's namespace will return errors until the flush operation completes.