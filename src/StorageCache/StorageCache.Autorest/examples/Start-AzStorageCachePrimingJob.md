### Example 1: Create a priming job.
```powershell
Start-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobName azps-priming-job -PrimingManifestUrl "https://contosostorage.blob.core.windows.net/contosoblob/00000000_00000000000000000000000000000000.00000000000.FFFFFFFF.00000000?sp=r&st=2021-08-11T19:33:35Z&se=2021-08-12T03:33:35Z&spr=https&sv=2020-08-04&sr=b&sig=<secret-value-from-key>"
```

Create a priming job.
This operation is only allowed when the cache is healthy.

### Example 2: Create a priming job.
```powershell
Start-AzStorageCachePrimingJob -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -PrimingJobName azps-priming-job3 -PrimingManifestUrl "https://contosostorage.blob.core.windows.net/contosoblob/00000000_00000000000000000000000000000000.00000000000.FFFFFFFF.00000000?sp=r&st=2021-08-11T19:33:35Z&se=2021-08-12T03:33:35Z&spr=https&sv=2020-08-04&sr=b&sig=<secret-value-from-key>" -PassThru
```

```output
True
```

Create a priming job.
This operation is only allowed when the cache is healthy.