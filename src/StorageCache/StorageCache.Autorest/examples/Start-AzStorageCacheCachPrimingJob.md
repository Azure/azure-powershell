### Example 1: Start cache priming job
```powershell
Start-AzStorageCacheCachPrimingJob -CacheName "myCache" -ResourceGroupName "myResourceGroup" -PrimingJobName "myPrimingJob" -PrimingManifestUrl "https://mystorageaccount.blob.core.windows.net/container/manifest.txt"
```

The HPC Cache service is being deprecated.

