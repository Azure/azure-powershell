### Example 1: Create or update a Storage Target.
```powershell
New-AzStorageCacheTarget -CacheName azps-storagecache -Name azps-cachetarget -ResourceGroupName azps_test_gp_storagecache -Nfs3Target "10.0.44.44" -Nfs3UsageModel "READ_WRITE" -Nfs3VerificationTimer 30 -TargetType 'nfs3'
```

```output
Name             Location ResourceGroupName         State
----             -------- -----------------         -----
azps-cachetarget eastus   azps_test_gp_storagecache Ready
```

Create or update a Storage Target.
This operation is allowed at any time, but if the cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the cache is healthy again.