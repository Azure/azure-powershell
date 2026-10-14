### Example 1: Check if a name is available or already used for a migration in a flexible server
```powershell
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName server-name -Name example-migration
```

```output
When name is available:

Message       : 
Name          : example-migration
NameAvailable : True
Reason        : 
Type          : Microsoft.DBforPostgreSQL/flexibleServers/migrations


When name is already used:

Message       : N0002: There is already a migration with the same name. Please try a different one.
Name          : example-migration
NameAvailable : False
Reason        : AlreadyExists
Type          : Microsoft.DBforPostgreSQL/flexibleServers/migrations


When name is invalid:

Message       : N0001: Invalid migration-name. It should start and end with alphanumeric characters and can contain _ and - only as special characters.
Name          : example~migration
NameAvailable : False
Reason        : Invalid
Type          : Microsoft.DBforPostgreSQL/flexibleServers/migrations
```

Checks if a name is available or already used for a migration in an Azure Database for PostgreSQL flexible server with resource type, migration name, server name, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
