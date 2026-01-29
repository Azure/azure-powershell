### Example 1: Update a migration to add more databases
```powershell
Update-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -MigrationName "migration-001" -DbsToMigrate @("userdb", "appdb", "logdb") -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : migration-001
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
State             : InProgress
DatabasesToMigrate: {"userdb", "appdb", "logdb"}
LastModified      : 2024-01-15T11:00:00Z
```

Updates an existing migration to include additional databases in the migration scope.

### Example 2: Update migration settings
```powershell
Update-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-01" -MigrationName "prod-migration-001" -SetupLogicalReplicationOnSourceDbIfNeeded -OverwriteDbsInTarget -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : prod-migration-001
ResourceGroupName : production-rg
TargetServerName  : prod-postgresql-01
State             : InProgress
LogicalReplication: Enabled
OverwriteDatabases: Enabled
LastModified      : 2024-01-20T15:30:00Z
```

Updates migration settings to enable logical replication on the source and allow overwriting databases on the target.

