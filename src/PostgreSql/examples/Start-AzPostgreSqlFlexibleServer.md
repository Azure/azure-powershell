### Example 1: Start the server by resource name
```powershell
<<<<<<< HEAD
Start-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
=======
 Start-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Start the server by name

### Example 2: Start the server by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/start"
Start-AzPostgreSqlFlexibleServer -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/start"
 Start-AzPostgreSqlFlexibleServer -InputObject $ID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Start the server by identity
