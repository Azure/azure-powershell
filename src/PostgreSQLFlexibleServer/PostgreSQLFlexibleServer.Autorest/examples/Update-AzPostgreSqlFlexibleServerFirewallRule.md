### Example 1: Update IP address range for a firewall rule
```powershell
Update-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -FirewallRuleName "AllowMyOffice" -StartIPAddress "203.0.113.1" -EndIPAddress "203.0.113.20"
```

```output
Name          : AllowMyOffice
StartIPAddress: 203.0.113.1
EndIPAddress  : 203.0.113.20
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/firewallRules/AllowMyOffice
```

Updates an existing firewall rule to expand the allowed IP address range from 10 to 20 addresses.

### Example 2: Update firewall rule to allow single IP address
```powershell
Update-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -FirewallRuleName "AdminAccess" -StartIPAddress "198.51.100.10" -EndIPAddress "198.51.100.10"
```

```output
Name          : AdminAccess
StartIPAddress: 198.51.100.10
EndIPAddress  : 198.51.100.10
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-rg/providers/Microsoft.DBforPostgreSQL/flexibleServers/prod-postgresql-01/firewallRules/AdminAccess
```

Updates a firewall rule to allow access from a single specific IP address for administrative purposes.

