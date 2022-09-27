
### Example 1: Stop the server by resource name
```powershell
Stop-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

Stop the server by name

### Example 2: Stop the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/stop"
Stop-AzMySqlFlexibleServer -InputObject $ID
```

Stop the server by identity
