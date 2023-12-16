### Example 1: Schedules an AML file system for deletion.
```powershell
Remove-AzStorageCacheAmlFileSystem -Name azps-cache-fs -ResourceGroupName azps_test_gp_storagecache
```

Schedules an AML file system for deletion.

### Example 2: Schedules an AML file system for deletion.
```powershell
Get-AzStorageCacheAmlFileSystem -ResourceGroupName azps_test_gp_storagecache -Name azps-cache-fs | Remove-AzStorageCacheAmlFileSystem 
```

Schedules an AML file system for deletion.