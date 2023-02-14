### Example 1: Remove PostgreSql server by resourceGroup and server name
```powershell
Remove-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet removes PostgreSql server by resourceGroup and server name.

### Example 2: Remove PostgreSql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test"
Remove-AzPostgreSqlFlexibleServer -InputObject $ID
<<<<<<< HEAD
=======
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets remove PostgreSql server by identity.