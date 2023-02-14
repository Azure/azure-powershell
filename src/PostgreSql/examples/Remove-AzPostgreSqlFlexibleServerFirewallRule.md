### Example 1: Remove PostgreSql Firewall Rule by name
```powershell
Remove-AzPostgreSqlFlexibleServerFirewallRule -Name firewall-rule-test -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
<<<<<<< HEAD
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet removes PostgreSql Firewall Rule by name.

### Example 2: Remove PostgreSql Firewall Rule by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/firewallRules/firewall-rule-test"
Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/firewallRules/firewall-rule-test"
 Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets remove PostgreSql Firewall Rule by identity.
