### Example 1: Remove PostgreSql Firewall Rule by name
```powershell
Remove-AzPostgreSqlFlexibleServerFirewallRule -Name firewall-rule-test -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

This cmdlet removes PostgreSql Firewall Rule by name.

### Example 2: Remove PostgreSql Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/firewallRules/firewall-rule-test"
Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID
```

These cmdlets remove PostgreSql Firewall Rule by identity.
