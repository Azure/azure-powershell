### Example 1: Create a firewall rule under a MariaDB
```powershell
<<<<<<< HEAD
New-AzMariaDbFirewallRule -Name firewall-101 -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -EndIPAddress 0.0.2.255 -StartIPAddress 0.0.2.1
```

```output
=======
PS C:\> New-AzMariaDbFirewallRule -Name firewall-101 -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -EndIPAddress 0.0.2.255 -StartIPAddress 0.0.2.1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name         StartIPAddress EndIPAddress
----         -------------- ------------
firewall-101 0.0.2.1        0.0.2.255
```

This command creates a firewall rule under a MariaDB.

### Example 2: Create a new MariaDB Firewall Rule using -ClientIPAddress.
```powershell
<<<<<<< HEAD
New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -ClientIPAddress 0.0.0.1
```

```output
=======
PS C:\> New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -ClientIPAddress 0.0.0.1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                StartIPAddress EndIPAddress
----                                -------------- ------------
ClientIPAddress_2020-08-11_18-19-27 0.0.0.1        0.0.0.1
```

This cmdlets create a MariaDB Firewall Rule using -ClientIPAddress.

### Example 3: Create a new MariaDB Firewall Rule to allow all IPs
```powershell
<<<<<<< HEAD
New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -AllowAll
```

```output
=======
PS C:\> New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -AllowAll

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                         StartIPAddress EndIPAddress
----                         -------------- ------------
AllowAll_2020-08-11_18-19-27 0.0.0.0        255.255.255.255
```

This cmdlets create a new MariaDB Firewall Rule to allow all IPs.


