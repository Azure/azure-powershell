### Example 1: Remove PostgreSql server by resourceGroup and server name
```powershell
PS C:\> Remove-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test

```

This cmdlet removes PostgreSql server by resourceGroup and server name.

### Example 2: Remove PostgreSql server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test"
PS C:\> Remove-AzPostgreSqlFlexibleServer -InputObject $ID
 
```

These cmdlets remove PostgreSql server by identity.