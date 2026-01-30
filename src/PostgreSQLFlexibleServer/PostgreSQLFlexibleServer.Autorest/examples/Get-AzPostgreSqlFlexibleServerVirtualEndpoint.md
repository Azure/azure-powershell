### Example 1: List all virtual endpoints for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name              : read-replica-endpoint
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
EndpointType      : ReadWrite
VirtualEndpoints  : {"primary-endpoint.postgres.database.azure.com", "read-endpoint.postgres.database.azure.com"}
Members           : {"primary-server", "read-replica-1"}

Name              : analytics-endpoint
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
EndpointType      : ReadOnly
VirtualEndpoints  : {"analytics-endpoint.postgres.database.azure.com"}
Members           : {"analytics-replica"}
```

Retrieves all virtual endpoints configured for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific virtual endpoint by name
```powershell
Get-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -VirtualEndpointName "read-replica-endpoint"
```

```output
Name              : read-replica-endpoint
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
EndpointType      : ReadWrite
VirtualEndpoints  : {"read-endpoint.postgres.database.azure.com"}
Members           : {"prod-postgresql-01", "prod-read-replica-1"}
State             : Ready
```

Retrieves details for a specific virtual endpoint by name.

