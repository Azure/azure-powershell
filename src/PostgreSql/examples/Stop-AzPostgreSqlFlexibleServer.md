
### Example 1: Stop the server by resource name
```powershell
<<<<<<< HEAD
Stop-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
=======
 Stop-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Stop the server by name

### Example 2: Stop the server by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/stop"
Stop-AzPostgreSqlFlexibleServer -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/stop"
 Stop-AzPostgreSqlFlexibleServer -InputObject $ID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Stop the server by identity
