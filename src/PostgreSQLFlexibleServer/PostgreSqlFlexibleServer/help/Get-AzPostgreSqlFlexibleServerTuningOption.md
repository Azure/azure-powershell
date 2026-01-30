---
external help file: Az.PostgreSqlFlexibleServer-help.xml
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
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] -TuningOption <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerTuningOption -TuningOption <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerTuningOption -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the tuning options of a server.

## EXAMPLES

### Example 1: List all tuning options for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
ConfigurationName    CurrentValue RecommendedValue Description
-----------------    ------------ ---------------- -----------
max_connections      100          150              Increase for higher concurrency
shared_buffers       32MB         128MB            Optimize memory usage
work_mem             4MB          8MB              Improve query performance
effective_cache_size 128MB        512MB            Better query planning
```

Lists all available tuning options with current and recommended values for the PostgreSQL Flexible Server.

### Example 2: Get tuning options for a specific configuration area
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -TuningOptionName "memory"
```

```output
ConfigurationName    CurrentValue RecommendedValue Description                     Impact
-----------------    ------------ ---------------- -----------                     ------
shared_buffers       64MB         256MB            Optimize buffer pool size      High
work_mem             4MB          16MB             Improve sorting and hashing     Medium
effective_cache_size 256MB        1GB              Better query cost estimation   High
```

Retrieves memory-related tuning options and recommendations for optimizing the PostgreSQL Flexible Server performance.

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
