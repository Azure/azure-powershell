### Example 1: Restart the server by resource name
```powershell
Restart-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

Restart the server by name

### Example 2: Restart the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/restart"
Restart-AzMySqlFlexibleServer -InputObject $ID
```

Restart the server by identity

### Example 2: Restart the server with failover
```powershell
Restart-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test -RestartWithFailover Enabled
```

Restart the server with failover