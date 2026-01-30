---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservertuningoptionrecommendation
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation

## SYNOPSIS
Lists available object recommendations.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName <String> -ServerName <String>
 -TuningOption <String> [-SubscriptionId <String[]>] [-RecommendationType <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists available object recommendations.

## EXAMPLES

### Example 1: Get tuning recommendations for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                : shared_buffers
CurrentValue        : 128MB
RecommendedValue    : 256MB
ReasonForRecommendation : Current value is too low for your workload pattern
ExpectedImpact      : 20% improvement in query performance
Category           : Memory
Priority           : High
ImplementationEffort : Medium
```

Retrieves performance tuning recommendations for the specified PostgreSQL Flexible Server.

### Example 2: Get recommendations for a specific parameter
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -TuningOptionName "checkpoint_completion_target"
```

```output
Name                : checkpoint_completion_target
CurrentValue        : 0.5
RecommendedValue    : 0.8
ReasonForRecommendation : Checkpoint I/O spikes are causing performance degradation
ExpectedImpact      : Smoother I/O distribution
Category           : Disk I/O
Priority           : Medium
ImplementationEffort : Low
RestartRequired    : False
```

Retrieves recommendations for a specific tuning parameter.

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

### -RecommendationType
Recommendations list filter.
Retrieves recommendations based on type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendation

## NOTES

## RELATED LINKS

