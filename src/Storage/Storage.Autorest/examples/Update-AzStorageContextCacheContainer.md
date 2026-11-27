### Example 1: Change context cache container retention
```powershell
Update-AzStorageContextCacheContainer -ResourceGroupName "myResourceGroup" -ContextCacheName "mycontextcache" -Name "mycontainer" -TimeToLive 30
```

Changes retention to 30 days without sending the immutable model or provider properties.
