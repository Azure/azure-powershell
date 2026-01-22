### Example 1: Create a firewall rule to allow a specific IP address
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -FirewallRuleName "AllowMyOffice" -StartIPAddress "203.0.113.1" -EndIPAddress "203.0.113.10"
```

```output
Name          : AllowMyOffice
StartIPAddress: 203.0.113.1
EndIPAddress  : 203.0.113.10
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/myResourceGroup/providers/Microsoft.DBforPostgreSQL/flexibleServers/myPostgreSqlServer/firewallRules/AllowMyOffice
```

Creates a firewall rule allowing access from IP addresses 203.0.113.1 to 203.0.113.10.

### Example 2: Create a firewall rule to allow Azure services
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -FirewallRuleName "AllowAzureServices" -StartIPAddress "0.0.0.0" -EndIPAddress "0.0.0.0"
```

```output
Name          : AllowAzureServices
StartIPAddress: 0.0.0.0
EndIPAddress  : 0.0.0.0
Id            : /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-rg/providers/Microsoft.DBforPostgreSQL/flexibleServers/prod-postgresql-01/firewallRules/AllowAzureServices
```

Creates a firewall rule allowing access from Azure services by using the special 0.0.0.0 to 0.0.0.0 IP range.

