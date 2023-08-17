---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzAutoscaleScaleRuleObject
schema: 2.0.0
---

# New-AzAutoscaleScaleRuleObject

## SYNOPSIS
Create an in-memory object for ScaleRule.

## SYNTAX

```
New-AzAutoscaleScaleRuleObject -MetricTriggerMetricName <String> -MetricTriggerMetricResourceUri <String>
 -MetricTriggerOperator <ComparisonOperationType> -MetricTriggerStatistic <MetricStatisticType>
 -MetricTriggerThreshold <Double> -MetricTriggerTimeAggregation <TimeAggregationType>
 -MetricTriggerTimeGrain <TimeSpan> -MetricTriggerTimeWindow <TimeSpan> -ScaleActionCooldown <TimeSpan>
 -ScaleActionDirection <ScaleDirection> -ScaleActionType <ScaleType>
 [-MetricTriggerDimension <IScaleRuleMetricDimension[]>] [-MetricTriggerDividePerInstance <Boolean>]
 [-MetricTriggerMetricNamespace <String>] [-MetricTriggerMetricResourceLocation <String>]
 [-ScaleActionValue <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScaleRule.

## EXAMPLES

### Example 1: Create scale rule object
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
New-AzAutoscaleScaleRuleObject -MetricTriggerMetricName "Percentage CPU" -MetricTriggerMetricResourceUri "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss" -MetricTriggerTimeGrain ([System.TimeSpan]::New(0,1,0)) -MetricTriggerStatistic "Average" -MetricTriggerTimeWindow ([System.TimeSpan]::New(0,5,0)) -MetricTriggerTimeAggregation "Average" -MetricTriggerOperator "GreaterThan" -MetricTriggerThreshold 10 -MetricTriggerDividePerInstance $false -ScaleActionDirection "Increase" -ScaleActionType "ChangeCount" -ScaleActionValue 1 -ScaleActionCooldown ([System.TimeSpan]::New(0,5,0))
```

Create scale rule object

## PARAMETERS

### -MetricTriggerDimension
List of dimension conditions.
For example: [{"DimensionName":"AppName","Operator":"Equals","Values":["App1"]},{"DimensionName":"Deployment","Operator":"Equals","Values":["default"]}].
To construct, see NOTES section for METRICTRIGGERDIMENSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IScaleRuleMetricDimension[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerDividePerInstance
a value indicating whether metric should divide per instance.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerMetricName
the name of the metric that defines what the rule monitors.

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

### -MetricTriggerMetricNamespace
the namespace of the metric that defines what the rule monitors.

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

### -MetricTriggerMetricResourceLocation
the location of the resource the rule monitors.

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

### -MetricTriggerMetricResourceUri
the resource identifier of the resource the rule monitors.

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

### -MetricTriggerOperator
the operator that is used to compare the metric data and the threshold.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ComparisonOperationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerStatistic
the metric statistic type.
How the metrics from multiple instances are combined.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.MetricStatisticType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerThreshold
the threshold of the metric that triggers the scale action.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerTimeAggregation
time aggregation type.
How the data that is collected should be combined over time.
The default value is Average.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.TimeAggregationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerTimeGrain
the granularity of metrics the rule monitors.
Must be one of the predefined values returned from metric definitions for the metric.
Must be between 12 hours and 1 minute.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricTriggerTimeWindow
the range of time in which instance data is collected.
This value must be greater than the delay in metric collection, which can vary from resource-to-resource.
Must be between 12 hours and 5 minutes.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleActionCooldown
the amount of time to wait since the last scaling action before this action occurs.
It must be between 1 week and 1 minute in ISO 8601 format.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleActionDirection
the scale direction.
Whether the scaling action increases or decreases the number of instances.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ScaleDirection
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleActionType
the type of action that should occur when the scale rule fires.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ScaleType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleActionValue
the number of instances that are involved in the scaling action.
This value must be 1 or greater.
The default value is 1.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.ScaleRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`METRICTRIGGERDIMENSION <IScaleRuleMetricDimension[]>`: List of dimension conditions. For example: [{"DimensionName":"AppName","Operator":"Equals","Values":["App1"]},{"DimensionName":"Deployment","Operator":"Equals","Values":["default"]}].
  - `DimensionName <String>`: Name of the dimension.
  - `Operator <ScaleRuleMetricDimensionOperationType>`: the dimension operator. Only 'Equals' and 'NotEquals' are supported. 'Equals' being equal to any of the values. 'NotEquals' being not equal to all of the values
  - `Value <String[]>`: list of dimension values. For example: ["App1","App2"].

## RELATED LINKS

