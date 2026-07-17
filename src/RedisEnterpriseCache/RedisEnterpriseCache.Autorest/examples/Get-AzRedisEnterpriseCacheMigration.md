### Example 1: Get migration status for a cache
```powershell
Get-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1"
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

Gets the migration status for the specified Redis Enterprise cache cluster.

