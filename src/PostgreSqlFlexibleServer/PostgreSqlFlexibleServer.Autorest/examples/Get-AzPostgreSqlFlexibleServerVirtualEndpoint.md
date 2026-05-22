### Example 1: List all virtual endpoints in a server
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                          EndpointType Member                                 PropertiesVirtualEndpoints
----                          ------------ ------                                 --------------------------
example-virtual-endpoint      ReadWrite    {example-server-01, example-server-02} {example-virtual-endpoint.writer.postgres.database.azure.com, example-virtual-endpoint.reader.postgres.database.azure.com}
```

Lists all virtual endpoints in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one virtual endpoint in a server
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-virtual-endpoint
```

```output
Name                          EndpointType Member                                 PropertiesVirtualEndpoints
----                          ------------ ------                                 --------------------------
example-virtual-endpoint      ReadWrite    {example-server-01, example-server-02} {example-virtual-endpoint.writer.postgres.database.azure.com, example-virtual-endpoint.reader.postgres.database.azure.com}
```

Gets one virtual endpoint in an Azure Database for PostgreSQL flexible server with virtual endpoint name, server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
