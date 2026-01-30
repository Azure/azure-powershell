### Example 1: List all Microsoft Entra administrators for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myresourcegroup" -ServerName "myserver"
```

```output
ObjectId                           PrincipalName                PrincipalType TenantId
--------                           -------------                ------------- --------
oooooooo-oooo-oooo-oooo-oooooooooooo exampleuser@contoso.com     User          tttttttt-tttt-tttt-tttt-tttttttttttt
oooooooo-oooo-oooo-oooo-oooooooooooo PostgreSQLAdmins@contoso.com Group         tttttttt-tttt-tttt-tttt-tttttttttttt
```

Lists all Microsoft Entra administrators configured for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific Microsoft Entra administrator by Object ID
```powershell
Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName "myresourcegroup" -ServerName "myserver" -ObjectId "oooooooo-oooo-oooo-oooo-oooooooooooo"
```

```output
ObjectId                           PrincipalName           PrincipalType TenantId
--------                           -------------           ------------- --------
oooooooo-oooo-oooo-oooo-oooooooooooo exampleuser@contoso.com User          tttttttt-tttt-tttt-tttt-tttttttttttt
```

Gets information about the specific Microsoft Entra administrator with the specified Object ID.

