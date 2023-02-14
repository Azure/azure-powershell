### Example 1: Update PostgreSql Firewall Rule by name
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
=======
 Update-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.2        0.0.0.3
```

This cmdlet updates PostgreSql Firewall Rule by name.

### Example 2: Update PostgreSql Firewall Rule by identity.
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Update-AzPostgreSqlFirewallRule -InputObject $ID -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PostgreSqlTestRG/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
 Update-AzPostgreSqlFirewallRule -InputObject $ID -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

These cmdlets update PostgreSql Firewall Rule by identity.

### Example 3: Update PostgreSql Firewall Rule by -ClientIPAddress.
```powershell
<<<<<<< HEAD
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
Update-AzPostgreSqlFirewallRule -InputObject $ID -ClientIPAddress 0.0.0.2
=======
 $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/servers/PostgreSqlTestServer/firewallRules/rule"
 Update-AzPostgreSqlFirewallRule -InputObject $ID --ClientIPAddress 0.0.0.2
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.2        0.0.0.2
```

These cmdlets update PostgreSql Firewall Rule by -ClientIPAddress.