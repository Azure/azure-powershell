### Example 1: Remove a firewall rule from a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-firewall-rule
```

```output
```

Removes a firewall rule from an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
