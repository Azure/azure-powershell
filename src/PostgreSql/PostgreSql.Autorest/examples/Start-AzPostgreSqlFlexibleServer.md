### Example 1: Start the server by resource name
```powershell
Start-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

Start the server by name

### Example 2: Start the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/start"
Start-AzPostgreSqlFlexibleServer -InputObject $ID
```

Start the server by identity
