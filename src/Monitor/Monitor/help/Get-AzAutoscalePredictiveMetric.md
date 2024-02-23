---
external help file: Az.Autoscale.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azautoscalepredictivemetric
schema: 2.0.0
---

# Get-AzAutoscalePredictiveMetric

## SYNOPSIS
get predictive autoscale metric future data

## SYNTAX

### GetViaIdentity (Default)
```
Get-AzAutoscalePredictiveMetric -InputObject <IAutoscaleIdentity> -Aggregation <String> -Interval <TimeSpan>
 -MetricName <String> -MetricNamespace <String> -Timespan <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzAutoscalePredictiveMetric -AutoscaleSettingName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Aggregation <String> -Interval <TimeSpan> -MetricName <String>
 -MetricNamespace <String> -Timespan <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
get predictive autoscale metric future data

## EXAMPLES

### Example 1: Get predictive metric for autoscale setting
```powershell
Get-AzAutoscalePredictiveMetric -AutoscaleSettingName test-autoscalesetting -ResourceGroupName test-group -Timespan "2021-10-14T22:00:00.000Z/2021-10-16T22:00:00.000Z" -Aggregation "Total" -Interval ([System.TimeSpan]::New(0,60,0)) -MetricName "PercentageCPU" -MetricNamespace "Microsoft.Compute/virtualMachineScaleSets"
```

Get predictive metric for autoscale setting

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.

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

### -AutoscaleSettingName
The autoscale setting name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
The interval (i.e.
timegrain) of the query.

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

### -MetricName
The names of the metrics (comma separated) to retrieve.
Special case: If a metricname itself has a comma in it then use %2 to indicate it.
Eg: 'Metric,Name1' should be **'Metric%2Name1'**

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
Metric namespace to query metric definitions for.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timespan
The timespan of the query.
It is a string with the following format 'startDateTime_ISO/endDateTime_ISO'.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IPredictiveResponse

## NOTES

## RELATED LINKS
