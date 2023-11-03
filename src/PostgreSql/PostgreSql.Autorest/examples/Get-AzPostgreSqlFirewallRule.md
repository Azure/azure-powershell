### Example 1: Lists all the Firewall Rules in specified PostgreSql server
```powershell
Get-AzPostgreSqlFirewallRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

This cmdlet lists all the Firewall Rule in specified PostgreSql server.

### Example 2: Get Firewall Rule by name
```powershell
Get-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

This cmdlet gets Firewall Rule by name.

### Example 3: Get Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Get-AzPostgreSqlFirewallRule -InputObject $ID
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

This cmdlet gets Firewall Rule by identity.