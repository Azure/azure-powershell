---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelprometheusmetricssignaldefinitionpropertiesobject
schema: 2.0.0
---

# New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject

## SYNOPSIS
Create an in-memory object for PrometheusMetricsSignalDefinitionProperties.

## SYNTAX

```
New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject -EvaluationRule <IEvaluationRule>
 -QueryText <String> [-DataUnit <String>] [-DisplayName <String>] [-RefreshInterval <String>]
 [-Tag <ISignalDefinitionPropertiesTags>] [-TimeGrain <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusMetricsSignalDefinitionProperties.

## EXAMPLES

### Example 1: Build a Prometheus metrics signal
```powershell
# Build a signal definition property object backed by a Prometheus query
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 0.05
$rules = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject -QueryText 'rate(http_requests_failed_total[5m])' -TimeGrain PT5M -EvaluationRule $rules -DisplayName 'Failed request rate'
```

Creates the property object for a signal definition backed by a Prometheus query.

## PARAMETERS

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

### -QueryText
Query text in PromQL syntax.

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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties

## NOTES

## RELATED LINKS

