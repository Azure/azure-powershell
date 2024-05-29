### Example 1: Remove PostgreSql server Virtual Network Rule by name
```powershell
Remove-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
```

This cmdlet removes PostgreSql server Virtual Network Rule by name.

### Example 2: Remove PostgreSql server Virtual Network Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
Remove-AzPostgreSqlVirtualNetworkRule -InputObject $ID
```

These cmdlets remove PostgreSql server Virtual Network Rule by identity.