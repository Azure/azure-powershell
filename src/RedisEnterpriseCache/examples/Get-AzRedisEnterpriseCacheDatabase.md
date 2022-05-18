### Example 1: Get database information
```powershell
Get-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup"
```

```output
Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

```

This command gets information about a database in the Redis Enterprise cache named MyCache.
