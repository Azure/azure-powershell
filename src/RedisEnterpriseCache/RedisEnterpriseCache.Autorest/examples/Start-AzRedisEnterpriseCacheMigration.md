### Example 1: Start a migration to Redis Enterprise
```powershell
Start-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1" -SwitchDns -SkipDataMigration
```

```output
AzureAsyncOperation          :
CreationTime                 : 24-06-2026 06:42:15
Id                           : /subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redisEnterprise/cache1/migrations/default
LastModifiedTime             : 24-06-2026 06:47:31
Location                     :
Name                         : cache1/default
Property                     : {
                                 "sourceType": "AzureCacheForRedis",
                                 "targetResourceId": "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redisEnterprise/cache1",
                                 "provisioningState": "Succeeded",
                                 "creationTime": "2026-06-24T06:42:15.0533333Z",
                                 "lastModifiedTime": "2026-06-24T06:47:31.0466667Z",
                                 "sourceResourceId": "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1",
                                 "switchDns": true,
                                 "skipDataMigration": true
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : rg1
SourceType                   : AzureCacheForRedis
StatusDetail                 :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetResourceId             : /subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redisEnterprise/cache1
Type                         : Microsoft.Cache/redisEnterprise/migrations
```

Starts a migration from an Azure Cache for Redis instance to the specified Azure Managed Redis resource.

