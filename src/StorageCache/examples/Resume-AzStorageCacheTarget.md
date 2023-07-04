### Example 1: Resumes client access to a previously suspended storage target.
```powershell
Resume-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Resumes client access to a previously suspended storage target.

### Example 2: Resumes client access to a previously suspended storage target.
```powershell
Resume-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -PassThru
```

```output
True
```

Resumes client access to a previously suspended storage target.