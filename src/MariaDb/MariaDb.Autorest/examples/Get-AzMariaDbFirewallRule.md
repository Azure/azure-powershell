### Example 1: List all firewall rule under a MariaDB
```powershell
PS C:\> Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig

Name       Type
----       ----
fr-cfgl3y  Microsoft.DBforMariaDB/servers/firewallRules
fr-usc9na  Microsoft.DBforMariaDB/servers/firewallRules
frname-001 Microsoft.DBforMariaDB/servers/firewallRules
```

This command lists all girewall rule under a MariaDB.

### Example 2: Get a firewall rule under a MariaDB
```powershell
PS C:\> Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig -Name frname-001

Name       Type
----       ----
frname-001 Microsoft.DBforMariaDB/servers/firewallRules
```

This command gets a firewall rule under a MariaDB.

