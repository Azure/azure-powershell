### Example 1: Create or replace a context cache container
```powershell
Set-AzStorageContextCacheContainer -ResourceGroupName "myResourceGroup" -ContextCacheName "mycontextcache" -Name "mycontainer" -ModelName "gpt-4" -TimeToLive 14
```

Creates or replaces the container. Use Update-AzStorageContextCacheContainer to modify retention without specifying the model again.
