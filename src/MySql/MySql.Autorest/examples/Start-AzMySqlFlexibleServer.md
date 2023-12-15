### Example 1: Start the server by resource name
```powershell
Start-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

Start the server by name

### Example 2: Start the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/start"
Start-AzMySqlFlexibleServer -InputObject $ID
```

Start the server by identity
