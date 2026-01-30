### Example 1: Create a read-write virtual endpoint
```powershell
New-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -VirtualEndpointName "primary-endpoint" -EndpointType "ReadWrite" -Member @("myPostgreSqlServer", "read-replica-1")
```

```output
Name              : primary-endpoint
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
EndpointType      : ReadWrite
VirtualEndpoints  : {"primary-endpoint.postgres.database.azure.com"}
Members           : {"myPostgreSqlServer", "read-replica-1"}
State             : Creating
```

Creates a new read-write virtual endpoint that includes the primary server and a read replica.

### Example 2: Create a read-only virtual endpoint for analytics
```powershell
New-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -VirtualEndpointName "analytics-endpoint" -EndpointType "ReadOnly" -Member @("analytics-replica-1", "analytics-replica-2")
```

```output
Name              : analytics-endpoint
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
EndpointType      : ReadOnly
VirtualEndpoints  : {"analytics-endpoint.postgres.database.azure.com"}
Members           : {"analytics-replica-1", "analytics-replica-2"}
State             : Creating
```

Creates a new read-only virtual endpoint for analytics workloads using multiple read replicas.

