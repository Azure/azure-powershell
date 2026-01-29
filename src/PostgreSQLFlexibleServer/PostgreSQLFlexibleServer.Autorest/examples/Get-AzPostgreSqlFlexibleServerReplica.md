### Example 1: Get all read replicas for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name               : myPostgreSqlServer-replica-1
ResourceGroupName  : myResourceGroup
Location           : East US 2
SourceServerName   : myPostgreSqlServer
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D2s_v3
StorageSizeGb      : 128

Name               : myPostgreSqlServer-replica-2
ResourceGroupName  : myResourceGroup
Location           : Central US
SourceServerName   : myPostgreSqlServer
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D2s_v3
StorageSizeGb      : 128
```

Retrieves all read replicas for the specified PostgreSQL Flexible Server.

### Example 2: Get replicas across all resource groups
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01"
```

```output
Name               : prod-postgresql-01-read-replica
ResourceGroupName  : production-rg
Location           : West Europe
SourceServerName   : prod-postgresql-01
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D4s_v3
StorageSizeGb      : 256
ReplicationLag     : 00:00:02.150
```

Retrieves information about read replicas for a production PostgreSQL Flexible Server.

