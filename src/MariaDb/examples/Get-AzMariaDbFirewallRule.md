### Example 1: List all firewall rule under a MariaDB
```powershell
<<<<<<< HEAD
Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig
```

```output
=======
PS C:\> Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name       Type
----       ----
fr-cfgl3y  Microsoft.DBforMariaDB/servers/firewallRules
fr-usc9na  Microsoft.DBforMariaDB/servers/firewallRules
frname-001 Microsoft.DBforMariaDB/servers/firewallRules
```

This command lists all girewall rule under a MariaDB.

### Example 2: Get a firewall rule under a MariaDB
```powershell
<<<<<<< HEAD
Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig -Name frname-001
```

```output
=======
PS C:\> Get-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-test-4rmtig -Name frname-001

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name       Type
----       ----
frname-001 Microsoft.DBforMariaDB/servers/firewallRules
```

This command gets a firewall rule under a MariaDB.

