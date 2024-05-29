### Example 1: Remove MySql Firewall Rule by name
```powershell
Remove-AzMySqlFirewallRule -Name rule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

This cmdlet removes MySql Firewall Rule by name.

### Example 2: Remove MySql Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/firewallRules/rule"
Remove-AzMySqlFirewallRule -InputObject $ID
```

These cmdlets remove MySql Firewall Rule by identity.