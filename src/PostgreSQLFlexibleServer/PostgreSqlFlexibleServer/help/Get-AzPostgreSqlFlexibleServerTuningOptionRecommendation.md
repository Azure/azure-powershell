---
external help file: Az.PostgreSqlFlexibleServer-help.xml
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
ConfigurationName    CurrentValue RecommendedValue Reason                      Impact
-----------------    ------------ ---------------- ------                      ------
max_connections      100          200              High connection usage       High
shared_buffers       32MB         128MB            Optimize for workload size  High
work_mem             4MB          8MB              Improve query performance   Medium
```

Retrieves personalized tuning recommendations based on the current workload and usage patterns of the PostgreSQL Flexible Server.

### Example 2: Get recommendations for specific performance areas
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -RecommendationType "Memory"
```

```output
ConfigurationName    CurrentValue RecommendedValue Reason                         Impact EstimatedImprovement
-----------------    ------------ ---------------- ------                         ------ --------------------
shared_buffers       64MB         256MB            Memory underutilized           High   15-20% query performance
effective_cache_size 128MB        1GB              Better query cost estimation  High   10-15% planning efficiency
work_mem             4MB          16MB             Improve sorting operations     Medium 5-10% complex query speed
```

Retrieves memory-specific tuning recommendations with estimated performance improvements.

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
