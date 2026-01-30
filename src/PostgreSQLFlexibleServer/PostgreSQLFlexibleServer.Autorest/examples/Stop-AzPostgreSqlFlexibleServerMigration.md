### Example 1: Stop an ongoing migration
```powershell
Stop-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -MigrationName "migration-001" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

Stops the specified migration operation. This will cancel the migration and may result in data loss if the migration was in progress.

### Example 2: Force stop a migration without confirmation
```powershell
Stop-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "development-rg" -TargetDbServerName "dev-postgresql-01" -MigrationName "test-migration" -Force -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

Force stops the migration operation without prompting for confirmation. Use with caution as this may result in partial data migration.

