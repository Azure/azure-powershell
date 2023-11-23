### Example 1: Create a new MySql server Virtual Network Rule
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.Network/virtualNetworks/MySqlVNet/subnets/MysqlSubnet1"
New-AzMySqlVirtualNetworkRule -Name vnet -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -SubnetId $ID
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

These cmdlets create a MySql server Virtual Network Rule.