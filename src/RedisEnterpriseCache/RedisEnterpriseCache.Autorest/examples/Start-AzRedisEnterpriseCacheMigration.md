### Example 1: Start a migration from Azure Cache for Redis
```powershell
$sourceResourceId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1"
Start-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId $sourceResourceId -ForceMigrate -SwitchDns -SkipDataMigration |
    Format-List Name, ProvisioningState, SourceType, TargetResourceId, CreationTime, LastModifiedTime, RollbackEligibleUntil
```

```output
Name                  : cache1/default
ProvisioningState     : Succeeded
SourceType            : AzureCacheForRedis
TargetResourceId      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Cache/redisEnterprise/cache1
CreationTime          : 30-10-2026 11:09:22
LastModifiedTime      : 30-10-2026 11:14:35
RollbackEligibleUntil : 29-11-2026 11:14:35
```

Starts a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis, switches the source DNS endpoint, and skips data migration.
