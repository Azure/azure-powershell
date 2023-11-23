### Example 1: Schedules a cache for deletion.
```powershell
Remove-AzStorageCache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache
```

Schedules a cache for deletion.

### Example 2: Schedules a cache for deletion.
```powershell
Get-AzStorageCache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache | Remove-AzStorageCache
```

Schedules a cache for deletion.