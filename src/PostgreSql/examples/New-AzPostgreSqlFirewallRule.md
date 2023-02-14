### Example 1: Create a new PostgreSql server Firewall Rule
```powershell
<<<<<<< HEAD
New-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
=======
 New-AzPostgreSqlFirewallRule -Name rule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name StartIPAddress EndIPAddress
---- -------------- ------------
rule 0.0.0.0        0.0.0.1
```

This cmdlets create a PostgreSql server Firewall Rule.

### Example 2: Create a new PostgreSql Firewall Rule using -ClientIPAddress.
```powershell
<<<<<<< HEAD
New-AzPostgreSqlFirewallRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -ClientIPAddress 0.0.0.1
=======
 New-AzPostgreSqlFirewallRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -ClientIPAddress 0.0.0.1
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name                                StartIPAddress EndIPAddress
----                                -------------- ------------
ClientIPAddress_2020-08-11_18-19-27 0.0.0.1        0.0.0.1
```

This cmdlets create a PostgreSql Firewall Rule using -ClientIPAddress.

### Example 3: Create a new PostgreSql Firewall Rule to allow all IPs
```powershell
<<<<<<< HEAD
New-AzPostgreSqlFirewallRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -AllowAll
=======
 New-AzPostgreSqlFirewallRule -ResourceGroupName PostgreSqlTestRG -ServerName PostgreSqlTestServer -AllowAll
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
Name                         StartIPAddress EndIPAddress
----                         -------------- ------------
AllowAll_2020-08-11_18-19-27 0.0.0.0        255.255.255.255
```

This cmdlets create a new PostgreSql Firewall Rule to allow all IPs.

