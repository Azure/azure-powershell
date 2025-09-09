### Example 1: Create a new storage target
```powershell
New-AzStorageCacheStorageTarget -CacheName "myCache" -ResourceGroupName "myResourceGroup" -StorageTargetName "myTarget" -Junctions @(@{NamespacePath="/path1"; NfsExport="/export1"; TargetPath=""})
```

The HPC Cache service is being deprecated.

