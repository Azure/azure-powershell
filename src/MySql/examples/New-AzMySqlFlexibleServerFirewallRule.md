### Example 1: Create a new MySql server Firewall Rule
```powershell
New-AzMySqlFlexibleServerFirewallRule -Name firewallrule-test -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0
```

```output
Name              StartIPAddress EndIPAddress
----------------- -------------- ------------
firewallrule-test 0.0.0.0        0.0.0.1
```

This cmdlets create a MySql server Firewall Rule.


### Example 2: Create a new MySql Firewall Rule using -ClientIPAddress.
```powershell
New-AzMySqlFlexibleServerFirewallRule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -ClientIPAddress 0.0.0.1
```

```output
Name                                StartIPAddress EndIPAddress
----                                -------------- ------------
ClientIPAddress_2020-08-11_18-19-27 0.0.0.1        0.0.0.1
```

This cmdlets create a MySql Firewall Rule using -ClientIPAddress.

### Example 3: Create a new MySql Firewall Rule to allow all IPs
```powershell
New-AzMySqlFlexibleServerFirewallRule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -AllowAll
```

```output
Name                         StartIPAddress EndIPAddress
----                         -------------- ------------
AllowAll_2020-08-11_18-19-27 0.0.0.0        255.255.255.255
```

This cmdlets create a new MySql Firewall Rule to allow all IPs.