### Example 1: Restart PostgreSql server by resource group and server name
```powershell
<<<<<<< HEAD
Restart-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer
=======
 Restart-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet restarts PostgreSql server by resource group and server name.

### Example 2: Restart PostgreSql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/restart"
Restart-AzPostgreSqlServer -InputObject $ID
<<<<<<< HEAD
=======
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets restart PostgreSql server by identity.