### Example 1: Check if a migration name is available
```powershell
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -MigrationName "my-new-migration" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name      : my-new-migration
Available : True
Reason    : 
Message   : Migration name is available
```

Checks if the specified migration name is available for the target PostgreSQL Flexible Server.

### Example 2: Check availability for an already used migration name
```powershell
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-01" -MigrationName "existing-migration" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name      : existing-migration
Available : False
Reason    : AlreadyExists
Message   : Migration name 'existing-migration' is already in use for this server
```

Checks availability for a migration name that is already in use, returning details about why it's not available.

