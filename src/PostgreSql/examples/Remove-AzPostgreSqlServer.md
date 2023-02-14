### Example 1: Remove PostgreSql server by resourceGroup and server name
```powershell
<<<<<<< HEAD
Remove-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer
=======
 Remove-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet removes PostgreSql server by resourceGroup and server name.

### Example 2: Remove PostgreSql server by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer"
Remove-AzPostgreSqlServer -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer"
 Remove-AzPostgreSqlServer -InputObject $ID
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets remove PostgreSql server by identity.