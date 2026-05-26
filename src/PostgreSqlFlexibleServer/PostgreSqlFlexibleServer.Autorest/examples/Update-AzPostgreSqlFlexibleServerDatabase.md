### Example 1: Update a database in a flexible server
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFlexibleServerDatabase -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-database -Collation en_US.utf8 -Charset UTF8
=======
Update-AzPostgreSqlFlexibleServerDatabase -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-database -Collation en_US.utf8 -Charset UTF8
>>>>>>> 15f018d78f3a5ebd1cabcfc830b54ee117a67146
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

Updates a database in an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
