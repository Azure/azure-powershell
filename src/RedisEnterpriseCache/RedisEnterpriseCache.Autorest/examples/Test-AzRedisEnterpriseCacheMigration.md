### Example 1: Validate a migration before starting
```powershell
Test-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1" -SkipDataMigration
```

```output
Error   : {{
            "disparities": [ ]
          }}
IsValid : False
Warning : {{
            "disparities": [
              {
                "category": "Clustering Mode",
                "message": "The target resource has a clustering policy, but the source resource is not clustered. Please ensure your client library is cluster-aware before migration, or select a target resource without a clustering policy."
              }
            ]
          }}
```

Validates whether a migration from the source Azure Cache for Redis to the target Redis Enterprise cache is possible.

