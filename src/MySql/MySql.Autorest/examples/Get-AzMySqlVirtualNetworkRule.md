### Example 1: Lists all the Virtual Network Rules in specified MySql server
```powershell
Get-AzMySqlVirtualNetworkRule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

This cmdlet lists all the Virtual Network Rules in specified MySql server.

### Example 2: Get Virtual Network Rule by name
```powershell
Get-AzMySqlVirtualNetworkRule -Name vnet -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by name.

### Example 3: Get Virtual Network Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/virtualNetworkRules/vnet"
Get-AzMySqlVirtualNetworkRule -InputObject $ID
```

```output
Name Type
---- ----
vnet Microsoft.DBforMySQL/servers/virtualNetworkRules
```

This cmdlet gets Virtual Network Rule by identity.