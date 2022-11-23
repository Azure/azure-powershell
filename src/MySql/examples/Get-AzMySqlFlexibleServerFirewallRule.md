### Example 1: Get firewall rules by name
```powershell
Get-AzMySqlFlexibleServerFirewallRule -Name firewallrule-test -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
FirewallRuleName   StartIPAddress   EndIPAddress
-----------------  ---------------  ---------------
firewallrule-test   12.12.12.12     23.23.23.23
```

This cmdlet gets firewall rules by name.

### Example 2: Get firewall rules by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/firewallRules/firewallrule-test"
Get-AzMySqlFlexibleServerFirewallRule -InputObject $ID
```

```output
FirewallRuleName   StartIPAddress   EndIPAddress
-----------------  ---------------  ---------------
firewallrule-test   12.12.12.12     23.23.23.23
```

This cmdlet gets firewall rules by identity.

### Example 3: Lists all the firewall rules in the specified MySql server
```powershell
Get-AzMySqlFlexibleServerFirewallRule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
FirewallRuleName   StartIPAddress   EndIPAddress
-----------------  ---------------  ---------------
firewallrule-test   12.12.12.12     23.23.23.23
firewallrule-test2  12.12.12.15     23.23.23.25
```

This cmdlet lists all the firewall rule in specified MySql server.
