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
New-AzRedisEnterpriseCacheDatabase -Name "MyCache2" -ResourceGroupName "MyGroup" -ClientProtocol "Encrypted" -EvictionPolicy "NoEviction" -ClusteringPolicy "EnterpriseCluster" -GroupNickname "GroupNickname" -LinkedDatabase '{id:"/subscriptions/sub1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache1/databases/default"}','{id:"/subscriptions/sub1/resourceGroups/MyGroup/providers/Microsoft.Cache/redisEnterprise/MyCache2/databases/default"}'
```

```output
Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

```

This command creates a georeplicated database named default for a Redis Enterprise cache named MyCache2. This database is supposed to be linked with a database default of a preexisting cache MyCache1
