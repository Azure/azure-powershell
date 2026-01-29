---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservertuningoption
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerTuningOption

## SYNOPSIS
Gets the tuning options of a server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName <String> -ServerName <String>
 -TuningOption <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerTuningOption -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerTuningOption -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity>
 -TuningOption <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the tuning options of a server.

## EXAMPLES

### Example 1: Get all tuning options for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                : shared_buffers
CurrentValue        : 128MB
RecommendedValue    : 256MB
Category           : Memory
Description        : Sets the amount of memory the database server uses for shared memory buffers
RequiresRestart    : True
TuningReason       : Improve query performance

Name                : effective_cache_size
CurrentValue        : 4GB
RecommendedValue    : 6GB
Category           : Memory
Description        : Sets the planner's assumption about the effective size of the disk cache
RequiresRestart    : False
TuningReason       : Better query planning
```

Retrieves all available tuning options for the specified PostgreSQL Flexible Server.

### Example 2: Get a specific tuning option
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -TuningOptionName "max_connections"
```

```output
Name                : max_connections
CurrentValue        : 100
RecommendedValue    : 150
Category           : Connections
Description        : Sets the maximum number of concurrent connections
RequiresRestart    : True
TuningReason       : Handle increased load
```

Retrieves details for a specific tuning option for the PostgreSQL Flexible Server.

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

### -TuningOption
The name of the tuning option.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFlexibleServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITuningOptions

## NOTES

## RELATED LINKS

