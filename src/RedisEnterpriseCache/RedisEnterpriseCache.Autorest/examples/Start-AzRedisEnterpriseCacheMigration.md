### Example 1: Start a migration to Redis Enterprise
```powershell
Start-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -JsonString '{"properties":{"sourceResourceId":"/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1","sourceType":"AzureCacheForRedis","skipDataMigration":true,"switchDns":true}}'
```

Starts a migration from an Azure Cache for Redis instance to the specified Redis Enterprise cache cluster.

