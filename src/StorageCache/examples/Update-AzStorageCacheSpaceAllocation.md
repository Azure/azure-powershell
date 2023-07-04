### Example 1: Update cache space allocation.
```powershell
$object = New-AzStorageCacheTargetSpaceAllocationObject -AllocationPercentage 100 -Name azps-cachetarget
Update-AzStorageCacheSpaceAllocation -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -SpaceAllocation $object
```

Update cache space allocation.

### Example 2: Update cache space allocation.
```powershell
$object = New-AzStorageCacheTargetSpaceAllocationObject -AllocationPercentage 100 -Name azps-cachetarget
Update-AzStorageCacheSpaceAllocation -CacheName azps-storagecache -ResourceGroupName azps_test_gp_storagecache -SpaceAllocation $object -PassThru
```

```output
True
```

Update cache space allocation.