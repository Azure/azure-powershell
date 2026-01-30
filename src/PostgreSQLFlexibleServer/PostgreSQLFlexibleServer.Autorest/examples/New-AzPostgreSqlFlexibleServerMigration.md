### Example 1: Create an online migration from an existing PostgreSQL server
```powershell
New-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -MigrationName "migration-to-flexible" -SourceDbServerName "mySourcePostgreSqlServer" -SourceDbServerResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/servers/mySourcePostgreSqlServer" -MigrationMode "Online" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : migration-to-flexible
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
SourceServerName  : mySourcePostgreSqlServer
State             : InProgress
MigrationMode     : Online
StartedOn         : 2024-01-15T10:30:00Z
```

Creates an online migration from a PostgreSQL Single Server to a PostgreSQL Flexible Server.

### Example 2: Create an offline migration with specific databases
```powershell
New-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-flexible" -MigrationName "offline-migration-001" -SourceDbServerName "prod-postgresql-single" -SourceDbServerResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/production-rg/providers/Microsoft.DBforPostgreSQL/servers/prod-postgresql-single" -MigrationMode "Offline" -DbsToMigrate @("userdb", "appdb") -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : offline-migration-001
ResourceGroupName : production-rg
TargetServerName  : prod-postgresql-flexible
SourceServerName  : prod-postgresql-single
State             : InProgress
MigrationMode     : Offline
DatabasesToMigrate: {"userdb", "appdb"}
StartedOn         : 2024-01-20T09:00:00Z
```

Creates an offline migration for specific databases from a PostgreSQL Single Server to a PostgreSQL Flexible Server.

