### Example 1: Remove PostgreSql server by resourceGroup and server name
```powershell
PS C:\> Remove-AzPostgreSqlServer -ResourceGroupName PostgreSqlTestRG -Name PostgreSqlTestServer

```

This cmdlet removes PostgreSql server by resourceGroup and server name.

### Example 2: Remove PostgreSql server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer"
PS C:\> Remove-AzPostgreSqlServer -InputObject $ID
 
```

These cmdlets remove PostgreSql server by identity.