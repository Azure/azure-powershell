---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelresourcemetricsignaldefinitionpropertiesobject
schema: 2.0.0
---

# New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject

## SYNOPSIS
Create an in-memory object for ResourceMetricSignalDefinitionProperties.

## SYNTAX

```
New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -AggregationType <String>
 -EvaluationRule <IEvaluationRule> -MetricName <String> -MetricNamespace <String> -TimeGrain <String>
 [-DataUnit <String>] [-DimensionFilter <String>] [-DisplayName <String>] [-RefreshInterval <String>]
 [-Tag <ISignalDefinitionPropertiesTags>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ResourceMetricSignalDefinitionProperties.

## EXAMPLES

### Example 1: Build an Azure resource metric signal
```powershell
# Build a signal definition property object backed by an Azure Monitor metric
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
$rules = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'CPU Utilization'
```

Creates the property object for a signal definition backed by an Azure Monitor metric.

## PARAMETERS

### -AggregationType
Type of aggregation to apply to the metric.

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

### -DataUnit
Unit of the signal result (e.g.
Bytes, MilliSeconds, Percent, Count)).

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

### -DimensionFilter
Optional: Dimension filter to apply to the dimension.
Must only be set if also Dimension is set.

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

### -DisplayName
Display name.

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

### -EvaluationRule
Evaluation rules for the signal definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEvaluationRule
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricName
Name of the metric.

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

### -MetricNamespace
Metric namespace.

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

### -RefreshInterval
Interval in which the signal is being evaluated.
Defaults to PT1M (1 minute).

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

### -Tag
Optional set of tags (key-value pairs).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinitionPropertiesTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeGrain
Time range of signal.
ISO duration format like PT10M.

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ResourceMetricSignalDefinitionProperties

## NOTES

## RELATED LINKS

