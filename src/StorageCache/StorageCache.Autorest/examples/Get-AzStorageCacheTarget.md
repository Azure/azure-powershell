### Example 1: List Storage Target by Cache Name.
```powershell
Get-AzStorageCacheTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

List Storage Target by Cache Name.

### Example 2: Get a Storage Target by Storage Target Name.
```powershell
Get-AzStorageCacheTarget -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -Name azps-cachetarget
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

Get a Storage Target by Storage Target Name.