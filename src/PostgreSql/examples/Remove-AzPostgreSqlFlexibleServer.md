### Example 1: Remove PostgreSql server by resourceGroup and server name
```powershell
Remove-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

This cmdlet removes PostgreSql server by resourceGroup and server name.

### Example 2: Remove PostgreSql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test"
Remove-AzPostgreSqlFlexibleServer -InputObject $ID
```

These cmdlets remove PostgreSql server by identity.