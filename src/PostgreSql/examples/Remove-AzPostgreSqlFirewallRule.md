### Example 1: Remove PostgreSql Firewall Rule by name
```powershell
<<<<<<< HEAD
Remove-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
=======
 Remove-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This cmdlet removes PostgreSql Firewall Rule by name.

### Example 2: Remove PostgreSql Firewall Rule by identity
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Remove-AzPostgreSqlFirewallRule -InputObject $ID
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
 Remove-AzPostgreSqlFirewallRule -InputObject $ID
 
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

These cmdlets remove PostgreSql Firewall Rule by identity.