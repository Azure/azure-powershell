### Example 1: Validate a migration before starting
```powershell
$sourceResourceId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1"
$result = Test-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId $sourceResourceId -SkipDataMigration
$result.IsValid
$result.Warning.Disparity | Format-List Category, Message
```

```output
False

Category : Clustering Mode
Message  : The target resource has a clustering policy, but the source resource is not clustered. Please ensure your client library is
           cluster-aware before migration, or select a target resource without a clustering policy.
```

Validates the migration and displays the clustering mismatch that must be resolved or explicitly accepted with `-ForceMigrate` when starting the migration.
