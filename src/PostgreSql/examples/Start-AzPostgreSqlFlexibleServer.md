### Example 1: Start the server by resource name
```powershell
PS C:\> Start-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

Start the server by name

### Example 2: Start the server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test/start"
PS C:\> Start-AzPostgreSqlFlexibleServer -InputObject $ID
```

Start the server by identity
