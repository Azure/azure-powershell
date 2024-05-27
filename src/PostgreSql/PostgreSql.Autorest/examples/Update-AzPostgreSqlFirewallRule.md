### Example 1: Update PostgreSql Firewall Rule by name
```powershell
Update-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.2        0.0.0.3
```

This cmdlet updates PostgreSql Firewall Rule by name.

### Example 2: Update PostgreSql Firewall Rule by identity.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Update-AzPostgreSqlFirewallRule -InputObject $ID -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

These cmdlets update PostgreSql Firewall Rule by identity.

### Example 3: Update PostgreSql Firewall Rule by -ClientIPAddress.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Update-AzPostgreSqlFirewallRule -InputObject $ID -ClientIPAddress 0.0.0.2
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.2        0.0.0.2
```

These cmdlets update PostgreSql Firewall Rule by -ClientIPAddress.