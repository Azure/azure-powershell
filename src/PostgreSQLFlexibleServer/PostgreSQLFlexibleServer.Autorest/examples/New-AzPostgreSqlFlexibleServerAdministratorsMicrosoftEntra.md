### Example 1: Add a Microsoft Entra user as administrator
```powershell
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -PrincipalName "user@contoso.com" -PrincipalType "User" -ObjectId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : user@contoso.com
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
PrincipalType     : User
PrincipalName     : user@contoso.com
ObjectId          : 12345678-1234-1234-1234-123456789abc
TenantId          : 11111111-1111-1111-1111-111111111111
```

Adds a Microsoft Entra user as an administrator for the PostgreSQL Flexible Server.

### Example 2: Add a Microsoft Entra group as administrator
```powershell
New-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -PrincipalName "PostgreSQL-Admins" -PrincipalType "Group" -ObjectId "87654321-4321-4321-4321-210987654321"
```

```output
Name              : PostgreSQL-Admins
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
PrincipalType     : Group
PrincipalName     : PostgreSQL-Admins
ObjectId          : 87654321-4321-4321-4321-210987654321
TenantId          : 11111111-1111-1111-1111-111111111111
```

Adds a Microsoft Entra group as an administrator for the PostgreSQL Flexible Server.

