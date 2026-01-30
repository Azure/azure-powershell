### Example 1: Get all migrations for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : migration-001
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
SourceServerName  : mySourcePostgreSqlServer
State             : InProgress
MigrationMode     : Online
StartedOn         : 2024-01-15T10:30:00Z

Name              : migration-002
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
SourceServerName  : myOldPostgreSqlServer
State             : Succeeded
MigrationMode     : Offline
StartedOn         : 2024-01-10T08:15:00Z
EndedOn           : 2024-01-10T12:45:00Z
```

Retrieves all migrations for the target PostgreSQL Flexible Server.

### Example 2: Get a specific migration by name
```powershell
Get-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-01" -MigrationName "prod-migration-001" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : prod-migration-001
ResourceGroupName : production-rg
TargetServerName  : prod-postgresql-01
SourceServerName  : legacy-postgresql-server
State             : Succeeded
MigrationMode     : Online
StartedOn         : 2024-01-20T14:00:00Z
EndedOn           : 2024-01-20T18:30:00Z
DatabasesToMigrate: {"userdb", "appdb", "logdb"}
```

Retrieves details for a specific migration operation by name.

