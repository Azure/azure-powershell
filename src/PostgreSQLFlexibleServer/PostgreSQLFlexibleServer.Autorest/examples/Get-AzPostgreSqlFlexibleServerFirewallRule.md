### Example 1: List all firewall rules on a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name          StartIPAddress EndIPAddress
----          -------------- ------------
AllowMyOffice 203.0.113.1    203.0.113.10
AllowHome     198.51.100.1   198.51.100.1
```

Lists all firewall rules configured on the specified PostgreSQL Flexible Server.

### Example 2: Get a specific firewall rule
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -FirewallRuleName "AllowMyOffice"
```

```output
Name          : AllowMyOffice
StartIPAddress: 203.0.113.1
EndIPAddress  : 203.0.113.10
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/firewallRules/AllowMyOffice
```

Retrieves detailed information about a specific firewall rule on the PostgreSQL Flexible Server.

