### Example 1: Migrate from virtual network integration to Private Link network model a flexible server 
```powershell
Move-AzPostgreSqlFlexibleServerNetworkMode -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
ResourceGroupName : 
ServerName        : example-server
State             : Succeeded
SubscriptionId    : aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e
XmsRequestId      : 00000000-1111-1111-1111-111111111111
```

Migrates an Azure Database for PostgreSQL flexible server from virtual network integration to Private Link network model. If subscription is not passed explicitly, it's taken from default context.
