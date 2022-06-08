### Example 1: Create a database for a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -Module "{name:RedisBloom, args:`"ERROR_RATE 0.00 INITIAL_SIZE 400`"}","{name:RedisTimeSeries, args:`"RETENTION_POLICY 20`"}","{name:RediSearch}" -ClientProtocol "Plaintext" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -Port 10000 -AofPersistenceEnabled -AofPersistenceFrequency "always"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```

This command creates a database named default for a Redis Enterprise cache named MyCache.

### Example 2: Create a georeplicated database for a Redis Enterprise cache
```powershell
New-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -ClientProtocol "Plaintext" -EvictionPolicy "Encrypted" -ClusteringPolicy "EnterpriseCluster" -EvictionPolicy "NoEviction" -Port 10000 -GroupNickname "GroupName" -LinkedDatabases "/subscriptions/subid1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default" -LinkedDatabases "/subscriptions/subid1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache/databases/default"
```

```output
Location Name    Type                            Zone Database
-------- ----    ----                            ---- --------
West US  MyCache Microsoft.Cache/redisEnterprise      {default}

```
