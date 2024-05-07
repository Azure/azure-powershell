### Example 1: Restart PostgreSql server by resource group and server name
```powershell
Restart-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer
```

This cmdlet restarts PostgreSql server by resource group and server name.

### Example 2: Restart PostgreSql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/restart"
Restart-AzPostgreSqlServer -InputObject $ID
```

These cmdlets restart PostgreSql server by identity.