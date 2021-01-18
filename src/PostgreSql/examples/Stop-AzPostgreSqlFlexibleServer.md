
### Example 1: Stop the server by resource name
```powershell
PS C:\> Stop-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

Stop the server by name

### Example 2: Stop the server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test/stop"
PS C:\> Stop-AzPostgreSqlFlexibleServer -InputObject $ID
```

Stop the server by identity
