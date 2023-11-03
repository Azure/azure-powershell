### Example 1: Lists all the Virtual Network Rules in specified PostgreSql server
```powershell
Get-AzPostgreSqlVirtualNetworkRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer 
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet lists all the Virtual Network Rules in specified PostgreSql server.

### Example 2: Get Virtual Network Rule by name
```powershell
Get-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by name.

### Example 3: Get Virtual Network Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
Get-AzPostgreSqlVirtualNetworkRule -InputObject $ID
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by identity.