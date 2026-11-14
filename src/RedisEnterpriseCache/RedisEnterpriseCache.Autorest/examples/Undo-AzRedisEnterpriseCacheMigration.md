### Example 1: Roll back a completed migration
```powershell
Undo-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -RollbackReason "testing" -PassThru
```

```output
True
```

Rolls back a completed migration while it remains eligible for rollback.
