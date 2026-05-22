### Example 1: Add a Microsoft Entra administrator to a flexible server
```powershell
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -PrincipalName dba@microsoft.com -PrincipalType User -ObjectId 00000000-0000-0000-0000-000000000000 -TenantId 11111111-1111-1111-1111-111111111111
```

```output
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/administrators/00000000-0000-0000-0000-000000000000
Name                         : dba@contoso.com
ObjectId                     : 00000000-0000-0000-0000-000000000000
PrincipalName                : dba@contoso.com
PrincipalType                : User
ResourceGroupName            : example-resource-group
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TenantId                     : 11111111-1111-1111-1111-111111111111
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/administrators
```

Adds a Microsoft Entra administrator to an Azure Database for PostgreSQL flexible server that has Microsoft Entra authentication enabled. If subscription is not passed explicitly, it's taken from default context.
