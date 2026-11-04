### Example 1: Unlink an endpoint after deleting the source cache
```powershell
Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint -ClusterName "cache1" -ResourceGroupName "rg1" -PassThru
```

```output
True
```

After the source Azure Cache for Redis resource has been deleted, permanently unlinks its endpoint from the Azure Managed Redis cluster.
