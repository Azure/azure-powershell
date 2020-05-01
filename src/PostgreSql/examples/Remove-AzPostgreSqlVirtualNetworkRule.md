### Example 1: Remove PostgreSql server Virtual Network Rule by name
```powershell
PS C:\> Remove-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer

```

This cmdlet removes PostgreSql server Virtual Network Rule by name.

### Example 2: Remove PostgreSql server Virtual Network Rule by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
PS C:\> Remove-AzPostgreSqlVirtualNetworkRule -InputObject $ID
 
```

These cmdlets remove PostgreSql server Virtual Network Rule by identity.