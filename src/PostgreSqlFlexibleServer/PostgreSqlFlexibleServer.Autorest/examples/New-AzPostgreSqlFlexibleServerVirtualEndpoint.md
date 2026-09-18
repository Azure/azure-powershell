### Example 1: Create virtual endpoints in a flexible server
```powershell
New-AzPostgreSqlFlexibleServerVirtualEndpoint -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-virtual-endpoints -EndpointType ReadWrite -Member example-server
```

```output
EndpointType                 : ReadWrite
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/virtualendpoints/example-virtual-endpoints
Member                       : {example-server}
Name                         : example-virtual-endpoints
PropertiesVirtualEndpoints   : {example-virtual-endpoints.writer.postgres.database.azure.com, example-virtual-endpoints.reader.postgres.database.azure.com}
ResourceGroupName            : example-resource-group
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/virtualendpoints
```

Creates virtual endpoints in an Azure Database for PostgreSQL flexible server with member servers, virtual endpoint type, virtual endpoint name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
