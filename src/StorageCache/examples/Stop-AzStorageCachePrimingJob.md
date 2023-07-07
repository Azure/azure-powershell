### Example 1: Schedule a priming job for deletion.
```powershell
Stop-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobId "00000000000_0000000000"
```

Schedule a priming job for deletion.

### Example 2: Schedule a priming job for deletion.
```powershell
Stop-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobId "00000000000_0000000000" -PassThru
```

```output
True
```

Schedule a priming job for deletion.