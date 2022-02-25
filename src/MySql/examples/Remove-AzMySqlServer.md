### Example 1: Remove MySql server by resourceGroup and server name
```powershell
Remove-AzMySqlServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

This cmdlet removes MySql server by resourceGroup and server name.

### Example 2: Remove MySql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test"
Remove-AzMySqlServer -InputObject $ID
```

These cmdlets remove MySql server by identity.