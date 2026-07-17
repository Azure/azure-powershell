### Example 1: Cancel an in-progress migration
```powershell
Undo-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1"
```

```output
True

```

Cancels an in-progress migration to the specified Redis Enterprise cache cluster.
