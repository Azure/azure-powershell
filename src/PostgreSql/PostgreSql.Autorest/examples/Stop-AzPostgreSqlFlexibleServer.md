
### Example 1: Stop the server by resource name
```powershell
Stop-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

Stop the server by name

### Example 2: Stop the server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/stop"
Stop-AzPostgreSqlFlexibleServer -InputObject $ID
```

Stop the server by identity
