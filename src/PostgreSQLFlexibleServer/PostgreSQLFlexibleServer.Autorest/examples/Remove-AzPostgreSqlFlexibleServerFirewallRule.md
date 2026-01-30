### Example 1: Remove a firewall rule from PostgreSQL Flexible Server
```powershell
Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -FirewallRuleName "AllowOldOffice"
```

Removes the specified firewall rule from the PostgreSQL Flexible Server. Access from the IP range defined in this rule will no longer be allowed.

### Example 2: Remove multiple firewall rules
```powershell
@("TempRule1", "TempRule2") | ForEach-Object { Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01" -FirewallRuleName $_ -Force }
```

Removes multiple temporary firewall rules without confirmation prompts. This is useful for cleanup operations in development environments.

