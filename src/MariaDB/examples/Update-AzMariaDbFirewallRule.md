### Example 1: Update MariaDb firewall rule
```powershell
PS C:\> Update-AzMariaDbFirewallRule -Name fr-cfgl3y -ServerName mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 -StartIPAddress 0.0.3.1 -EndIPAddress 0.0.3.255

Name      Type
----      ----
fr-cfgl3y Microsoft.DBforMariaDB/servers/firewallRules
```

This command updates a MariaDb firewall rule.


