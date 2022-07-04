### Example 1: Update MariaDB firewall rule
```powershell
Update-AzMariaDbFirewallRule -Name fr-cfgl3y -ServerName mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 -StartIPAddress 0.0.3.1 -EndIPAddress 0.0.3.255
```

```output
Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.3.1        0.0.3.255
```

This command updates a MariaDB firewall rule.

### Example 2: Update MariaDB Firewall Rule by identity.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/mariadb-test-qu5ov0/providers/Microsoft.DBforMariaDB/servers/mariadb-test-4rmtig/firewallRules/fr-cfgl3y"
Update-AzMariaDbFirewallRule -InputObject $ID -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2
```

```output
Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.0.2        0.0.0.3
```

The cmdlet updates MariaDB Firewall Rule by identity.

### Example 3: Update MariaDB Firewall Rule by -ClientIPAddress.
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/mariadb-test-qu5ov0/providers/Microsoft.DBforMariaDB/servers/mariadb-test-4rmtig/firewallRules/fr-cfgl3y"
Update-AzMariaDbFirewallRule -InputObject $ID -ClientIPAddress 0.0.0.2
```

```output
Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.0.2        0.0.0.2
```

The cmdlet updates MariaDB Firewall Rule by -ClientIPAddress.
