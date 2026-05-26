### Example 1: Update virtual endpoints in a flexible server
```powershell
Update-AzPostgreSqlFlexibleServerVirtualEndpoint -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-virtual-endpoints-EndpointType ReadWrite -Member example-server
```

```output
```

Updates virtual endpoints in an Azure Database for PostgreSQL flexible server with member servers, virtual endpoint type, virtual endpoint name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
