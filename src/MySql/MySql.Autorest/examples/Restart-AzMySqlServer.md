### Example 1: Restart MySql server by resource group and server name
```powershell
Restart-AzMySqlServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

This cmdlet restarts MySql server by resource group and server name.

### Example 2: Restart MySql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/restart"
Restart-AzMySqlServer -InputObject $ID
```

These cmdlets restart MySql server by identity.