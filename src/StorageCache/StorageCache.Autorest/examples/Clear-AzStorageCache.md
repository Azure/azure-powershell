### Example 1: Tells a cache to write all dirty data to the Storage Target(s).
```powershell
Clear-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

Tells a cache to write all dirty data to the Storage Target(s).
During the flush, clients will see errors returned until the flush is complete.

### Example 2: Tells a cache to write all dirty data to the Storage Target(s).
```powershell
Clear-AzStorageCache -Name azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Tells a cache to write all dirty data to the Storage Target(s).
During the flush, clients will see errors returned until the flush is complete.