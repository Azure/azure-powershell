### Example 1: Remove virtual endpoints in a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServerVirtualEndpoint -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-virtual-endpoints
```

```output
```

Removes virtual endpoints from an Azure Database for PostgreSQL flexible server with virtual endpoint name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
