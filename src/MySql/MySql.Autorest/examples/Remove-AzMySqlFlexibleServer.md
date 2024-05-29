### Example 1: Remove MySql server by resourceGroup and server name
```powershell
Remove-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

This cmdlet removes MySql server by resourceGroup and server name.

### Example 2: Remove MySql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test"
Remove-AzMySqlFlexibleServer -InputObject $ID
```

These cmdlets remove MySql server by identity.