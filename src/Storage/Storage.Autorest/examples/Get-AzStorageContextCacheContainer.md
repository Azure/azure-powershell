### Example 1: List containers in a context cache
```powershell
Get-AzStorageContextCacheContainer -ResourceGroupName "myResourceGroup" -ContextCacheName "mycontextcache"
```

Lists containers in the cache. Add Name to get one container, including its provider, model, and retention settings.
