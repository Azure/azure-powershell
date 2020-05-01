### Example 1: Remove MySql server by resourceGroup and server name
```powershell
PS C:\> Remove-AzMySqlServer -ResourceGroupName PowershellMySqlTest -Name mysql-test

```

This cmdlet removes MySql server by resourceGroup and server name.

### Example 2: Remove MySql server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test"
PS C:\> Remove-AzMySqlServer -InputObject $ID
 
```

These cmdlets remove MySql server by identity.