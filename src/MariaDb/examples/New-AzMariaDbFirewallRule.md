### Example 1: Create a firewall rule under a MariaDB
```powershell
PS C:\> New-AzMariaDbFirewallRule -Name firewall-101 -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -EndIPAddress 0.0.2.255 -StartIPAddress 0.0.2.1

Name         Type
----         ----
firewall-101 Microsoft.DBforMariaDB/servers/firewallRules
```

This command creates a firewall rule under a MariaDB.


