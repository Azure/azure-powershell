### Example 1: Validate a migration before starting
```powershell
Test-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1" -SkipDataMigration
```

Validates whether a migration from the source Azure Cache for Redis to the target Redis Enterprise cache is possible.

