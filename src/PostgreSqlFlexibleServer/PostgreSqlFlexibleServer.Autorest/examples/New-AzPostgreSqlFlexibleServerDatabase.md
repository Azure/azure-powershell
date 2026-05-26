### Example 1: Add a database to a flexible server
```powershell
New-AzPostgreSqlFlexibleServerDatabase -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-database
```

```output
Charset                      : UTF8
Collation                    : en_US.utf8
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/databases/example-database
Name                         : example-database
ResourceGroupName            : example-resource-group
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/databases
```

Adds a database to an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
