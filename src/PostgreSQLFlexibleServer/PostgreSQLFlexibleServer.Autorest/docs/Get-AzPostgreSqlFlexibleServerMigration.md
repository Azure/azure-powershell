---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservermigration
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerMigration

## SYNOPSIS
Gets information about a migration.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerMigration -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-MigrationListFilter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerMigration -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerMigration -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerMigration -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a migration.

## EXAMPLES

### Example 1: Get all migrations for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : migration-001
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
SourceServerName  : mySourcePostgreSqlServer
State             : InProgress
MigrationMode     : Online
StartedOn         : 2024-01-15T10:30:00Z

Name              : migration-002
ResourceGroupName : myResourceGroup
TargetServerName  : myTargetPostgreSqlServer
SourceServerName  : myOldPostgreSqlServer
State             : Succeeded
MigrationMode     : Offline
StartedOn         : 2024-01-10T08:15:00Z
EndedOn           : 2024-01-10T12:45:00Z
```

Retrieves all migrations for the target PostgreSQL Flexible Server.

### Example 2: Get a specific migration by name
```powershell
Get-AzPostgreSqlFlexibleServerMigration -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-01" -MigrationName "prod-migration-001" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name              : prod-migration-001
ResourceGroupName : production-rg
TargetServerName  : prod-postgresql-01
SourceServerName  : legacy-postgresql-server
State             : Succeeded
MigrationMode     : Online
StartedOn         : 2024-01-20T14:00:00Z
EndedOn           : 2024-01-20T18:30:00Z
DatabasesToMigrate: {"userdb", "appdb", "logdb"}
```

Retrieves details for a specific migration operation by name.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentityFlexibleServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MigrationListFilter
Migration list filter.
Indicates if the request should retrieve only active migrations or all migrations.
Defaults to Active.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of migration.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFlexibleServer
Aliases: MigrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the server.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration

## NOTES

## RELATED LINKS

