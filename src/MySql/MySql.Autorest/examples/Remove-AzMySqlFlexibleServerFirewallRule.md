### Example 1: Remove MySql Firewall Rule by name
```powershell
Remove-AzMySqlFlexibleServerFirewallRule -Name firewall-rule-test -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

This cmdlet removes MySql Firewall Rule by name.

### Example 2: Remove MySql Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test/firewallRules/firewall-rule-test"
Remove-AzMySqlFlexibleServerFirewallRule -InputObject $ID
```

These cmdlets remove MySql Firewall Rule by identity.
