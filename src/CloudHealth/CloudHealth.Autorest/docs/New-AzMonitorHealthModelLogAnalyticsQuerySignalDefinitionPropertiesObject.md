---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelloganalyticsquerysignaldefinitionpropertiesobject
schema: 2.0.0
---

# New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject

## SYNOPSIS
Create an in-memory object for LogAnalyticsQuerySignalDefinitionProperties.

## SYNTAX

```
New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject -EvaluationRule <IEvaluationRule>
 -QueryText <String> [-DataUnit <String>] [-DisplayName <String>] [-RefreshInterval <String>]
 [-Tag <ISignalDefinitionPropertiesTags>] [-TimeGrain <String>] [-ValueColumnName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LogAnalyticsQuerySignalDefinitionProperties.

## EXAMPLES

### Example 1: Build a Log Analytics query signal
```powershell
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 10
$rules = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject -QueryText 'AppExceptions | summarize Count = count()' -ValueColumnName Count -TimeGrain PT15M -EvaluationRule $rules -DisplayName 'Exception count'
```

Creates the property object for a signal definition backed by a Log Analytics query.
ValueColumnName selects the column holding the numeric value.

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
Query text in KQL syntax.

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
If not specified, the KQL query must define a time range.

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

### -ValueColumnName
Name of the column in the result set to evaluate against the thresholds.
Defaults to the first column in the result set if not specified.
The column must be numeric.

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties

## NOTES

## RELATED LINKS

