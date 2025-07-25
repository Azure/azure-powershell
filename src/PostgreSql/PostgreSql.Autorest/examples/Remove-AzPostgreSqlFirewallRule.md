### Example 1: Remove PostgreSql Firewall Rule by name
```powershell
Remove-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
```

This cmdlet removes PostgreSql Firewall Rule by name.

### Example 2: Remove PostgreSql Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Remove-AzPostgreSqlFirewallRule -InputObject $ID
```

These cmdlets remove PostgreSql Firewall Rule by identity.