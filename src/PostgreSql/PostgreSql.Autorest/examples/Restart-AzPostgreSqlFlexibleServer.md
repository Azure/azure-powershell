### Example 1: Restart the server by resource name
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

Restart the server by name

### Example 2: Restart the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test/restart"
Restart-AzPostgreSqlFlexibleServer -InputObject $ID
```

Restart the server by identity

### Example 3: Restart the server with planned failover
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode PlannedFailover
```

Restart the server by name with planned failover

### Example 4: Restart the server with forced failover
```powershell
Restart-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test -RestartWithFailover -FailoverMode ForcedFailover
```

Restart the server by name with forced failover