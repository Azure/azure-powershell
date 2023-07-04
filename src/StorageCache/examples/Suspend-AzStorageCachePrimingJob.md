### Example 1: Schedule a priming job to be paused.
```powershell
Suspend-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobId "00000000000_0000000000"
```

Schedule a priming job to be paused.

### Example 2: Schedule a priming job to be paused.
```powershell
Suspend-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobId "00000000000_0000000000" -PassThru
```

```output
True
```

Schedule a priming job to be paused.