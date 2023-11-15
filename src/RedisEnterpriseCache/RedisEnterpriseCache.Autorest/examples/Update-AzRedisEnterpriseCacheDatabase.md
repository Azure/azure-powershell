### Example 1: Update client protocol property of a database
```powershell
Update-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -ClientProtocol "Plaintext"
```

```output
Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

```

This command updates the client protocol of the database for the Redis Enterprise cache named MyCache.

### Example 2: Update client protocol and eviction policy properties of a database
```powershell
Update-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -ClientProtocol "Encrypted" -EvictionPolicy "NoEviction"
```

```output
Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

```

This command updates the client protocol and eviction policy of the database for the Redis Enterprise cache named MyCache.

