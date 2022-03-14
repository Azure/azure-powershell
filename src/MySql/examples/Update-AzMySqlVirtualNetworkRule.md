### Example 1: Update MySql Virtual Network Rule by name
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet2"
Update-AzMySqlVirtualNetworkRule -Name $env.VNetName -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SubnetId $ID
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

This cmdlet updates MySql Virtual Network Rule by name.

### Example 2: Update MySql Virtual Network Rule by identity.
```powershell
$SubnetID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
$VNetID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/virtualNetworkRules/vnet"
Update-AzMySqlVirtualNetworkRule -InputObject $VNetID -SubnetId $SubnetID
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

These cmdlets update MySql Virtual Network Rule by identity.