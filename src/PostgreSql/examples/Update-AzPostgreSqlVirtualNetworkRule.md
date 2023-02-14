### Example 1: Update PostgreSql Virtual Network Rule by name
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.Network/virtualNetworks/PostgreSqlVNet/subnets/default2"
Update-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -SubnetId $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.Network/virtualNetworks/PostgreSqlVNet/subnets/default2"
 Update-AzPostgreSqlVirtualNetworkRule -Name vnet -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -SubnetId $ID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

This cmdlet updates PostgreSql Virtual Network Rule by name.

### Example 2: Update PostgreSql Virtual Network Rule by identity.
```powershell
<<<<<<< HEAD
$SubnetID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.Network/virtualNetworks/PostgreSqlVNet/subnets/default"
$VNetID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
Update-AzPostgreSqlVirtualNetworkRule -InputObject $VNetID -SubnetId $SubnetID
=======
 $SubnetID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.Network/virtualNetworks/PostgreSqlVNet/subnets/default"
 $VNetID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/virtualNetworkRules/vnet"
 Update-AzPostgreSqlVirtualNetworkRule -InputObject $VNetID -SubnetId $SubnetID
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name Type
---- ----
vnet Microsoft.DBforPostgreSQL/servers/virtualNetworkRules
```

These cmdlets update PostgreSql Virtual Network Rule by identity.