### Example 1: Create a new PostgreSql server Firewall Rule
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -Name firewallrule-test -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
```

```output
Name              StartIPAddress EndIPAddress
----------------- -------------- ------------
firewallrule-test 0.0.0.0        0.0.0.1
```

This cmdlets create a PostgreSql server Firewall Rule.


### Example 2: Create a new PostgreSql Firewall Rule using -ClientIPAddress.
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -ClientIPAddress 0.0.0.1
```

```output
Name                                StartIPAddress EndIPAddress
----                                -------------- ------------
ClientIPAddress_2020-08-11_18-19-27 0.0.0.1        0.0.0.1
```

This cmdlets create a PostgreSql Firewall Rule using -ClientIPAddress.

### Example 3: Create a new PostgreSql Firewall Rule to allow all IPs
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -AllowAll
```

```output
Name                         StartIPAddress EndIPAddress
----                         -------------- ------------
AllowAll_2020-08-11_18-19-27 0.0.0.0        255.255.255.255
```

This cmdlets create a new PostgreSql Firewall Rule to allow all IPs.