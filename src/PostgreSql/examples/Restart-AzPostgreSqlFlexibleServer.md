### Example 1: Restart the server by resource name
```powershell
<<<<<<< HEAD
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
=======
 Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Restart the server by name

### Example 2: Restart the server by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test/restart"
Restart-AzPostgreSqlFlexibleServer -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test/restart"
 Restart-AzPostgreSqlFlexibleServer -InputObject $ID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Restart the server by identity

### Example 3: Restart the server with planned failover
```powershell
<<<<<<< HEAD
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode PlannedFailover
=======
 Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode PlannedFailover
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Restart the server by name with planned failover

### Example 4: Restart the server with forced failover
```powershell
<<<<<<< HEAD
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode ForcedFailover
=======
 Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode ForcedFailover
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Restart the server by name with forced failover