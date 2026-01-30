### Example 1: Update virtual endpoint members
```powershell
Update-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -VirtualEndpointName "read-endpoint" -Member @("myPostgreSqlServer", "read-replica-1", "read-replica-2")
```

```output
Name              : read-endpoint
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
EndpointType      : ReadWrite
Members           : {"myPostgreSqlServer", "read-replica-1", "read-replica-2"}
State             : Updating
```

Updates the virtual endpoint to include an additional read replica in the member list.

### Example 2: Update virtual endpoint to change endpoint type
```powershell
Update-AzPostgreSqlFlexibleServerVirtualEndpoint -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -VirtualEndpointName "flexible-endpoint" -EndpointType "ReadOnly" -Member @("read-replica-1", "read-replica-2")
```

```output
Name              : flexible-endpoint
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
EndpointType      : ReadOnly
Members           : {"read-replica-1", "read-replica-2"}
State             : Updating
```

Updates the virtual endpoint to change it from ReadWrite to ReadOnly and updates the member list accordingly.

