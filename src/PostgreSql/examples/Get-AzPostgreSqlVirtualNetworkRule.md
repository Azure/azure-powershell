### Example 1: Lists all the Virtual Network Rules in specified PostgreSql server
```powershell
<<<<<<< HEAD
Get-AzPostgreSqlVirtualNetworkRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer 
=======
 Get-AzPostgreSqlVirtualNetworkRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet lists all the Virtual Network Rules in specified PostgreSql server.

### Example 2: Get Virtual Network Rule by name
```powershell
<<<<<<< HEAD
Get-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
=======
 Get-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by name.

### Example 3: Get Virtual Network Rule by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
Get-AzPostgreSqlVirtualNetworkRule -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
 Get-AzPostgreSqlVirtualNetworkRule -InputObject $ID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by identity.