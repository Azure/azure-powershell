### Example 1: Remove MySql server Virtual Network Rule by name
```powershell
Remove-AzMySqlVirtualNetworkRule -Name vnet -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

This cmdlet removes MySql server Virtual Network Rule by name.

### Example 2: Remove MySql server Virtual Network Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/virtualNetworkRules/vnet"
Remove-AzMySqlVirtualNetworkRule -InputObject $ID
```

These cmdlets remove MySql server Virtual Network Rule by identity.