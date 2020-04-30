### Example 1: Remove MySql server Virtual Network Rule by name
```powershell
PS C:\> Remove-AzMySqlVirtualNetworkRule -Name vnet -ResourceGroupName PowershellMySqlTest-ServerName mysql-test

```

This cmdlet removes MySql server Virtual Network Rule by name.

### Example 2: Remove MySql server Virtual Network Rule by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/virtualNetworkRules/vnet"
PS C:\> Remove-AzMySqlVirtualNetworkRule -InputObject $ID
 
```

These cmdlets remove MySql server Virtual Network Rule by identity.