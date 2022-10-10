### Example 1: Lists all the Firewall Rules in specified MySql server
```powershell
Get-AzMySqlFirewallRule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlet lists all the Firewall Rule in specified MySql server.

### Example 2: Get Firewall Rule by name
```powershell
Get-AzMySqlFirewallRule -Name rule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlet gets Firewall Rule by name.

### Example 3: Get Firewall Rule by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test/firewallRules/rule"
Get-AzMySqlFirewallRule -InputObject $ID
```

```output
Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlet gets Firewall Rule by identity.