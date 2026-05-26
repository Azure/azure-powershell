### Example 1: Remove a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
```

Removes an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Remove a flexible server corresponding to specific resource identifier
```powershell
$ID = "/subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server"
Remove-AzPostgreSqlFlexibleServer -InputObject $ID
```

```output
```

Removes an Azure Database for PostgreSQL flexible server with the specific resource identifier of the server, explicitly passed as an argument.
