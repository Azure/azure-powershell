### Example 1: Create a context cache container with seven-day retention
```powershell
New-AzStorageContextCacheContainer -ResourceGroupName "myResourceGroup" -ContextCacheName "mycontextcache" -Name "mycontainer" -ModelName "gpt-4" -TimeToLive 7
```

Creates an OpenAI context cache container. TimeToLive accepts 1 through 30 days; omitting it allows the service's one-day default.
