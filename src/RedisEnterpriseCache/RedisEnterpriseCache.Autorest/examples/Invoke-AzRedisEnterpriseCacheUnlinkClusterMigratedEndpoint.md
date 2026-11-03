### Example 1: Unlink an endpoint after an Azure Cache for Redis Enterprise migration
```powershell
Invoke-AzRedisEnterpriseCacheUnlinkClusterMigratedEndpoint -ClusterName "cache1" -ResourceGroupName "rg1" -PassThru
```

```output
True
```

Permanently unlinks the legacy Azure Cache for Redis Enterprise endpoint after the cluster has been migrated to Azure Managed Redis.
