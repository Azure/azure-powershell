### Example 1: List all Microsoft Entra administrators in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                                     ObjectId                                 PrincipalName                            PrincipalType TenantId
----                                     --------                                 -------------                            ------------- --------
dba@contoso.com                          00000000-0000-0000-0000-000000000000     dba@contoso.com                          User          11111111-1111-1111-1111-111111111111
operations@contoso.com                   22222222-2222-2222-2222-222222222222     operations@contoso.com                   Group         11111111-1111-1111-1111-111111111111
```

Lists all Microsoft Entra administrators in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one Microsoft Entra administrator in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -ObjectId 00000000-0000-0000-0000-000000000000
```

```output
Name                                     ObjectId                                 PrincipalName                            PrincipalType TenantId
----                                     --------                                 -------------                            ------------- --------
dba@contoso.com                          00000000-0000-0000-0000-000000000000     dba@contoso.com                          User          11111111-1111-1111-1111-111111111111
operations@contoso.com                   22222222-2222-2222-2222-222222222222     operations@contoso.com                   Group         11111111-1111-1111-1111-111111111111
```

Gets one Microsoft Entra administrator in an Azure Database for PostgreSQL flexible server with object identifier, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
