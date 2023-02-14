### Example 1: Remove PostgreSql server Virtual Network Rule by name
```powershell
<<<<<<< HEAD
Remove-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
=======
 Remove-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet removes PostgreSql server Virtual Network Rule by name.

### Example 2: Remove PostgreSql server Virtual Network Rule by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
Remove-AzPostgreSqlVirtualNetworkRule -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
 Remove-AzPostgreSqlVirtualNetworkRule -InputObject $ID
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets remove PostgreSql server Virtual Network Rule by identity.