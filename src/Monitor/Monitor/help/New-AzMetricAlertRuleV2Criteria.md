---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/new-azmetricalertrulev2criteria
=======
online version: https://docs.microsoft.com/powershell/module/az.monitor/new-azmetricalertrulev2criteria
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# New-AzMetricAlertRuleV2Criteria

## SYNOPSIS
Creates a local criteria object that can be used to create a new metric alert

## SYNTAX

### StaticThresholdParameterSet (Default)
```
New-AzMetricAlertRuleV2Criteria -MetricName <String> [-MetricNamespace <String>]
<<<<<<< HEAD
 [-DimensionSelection <PSMetricDimension[]>] -TimeAggregation <String> -Operator <String> -Threshold <Double>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
=======
 [-SkipMetricValidation <Boolean>] [-DimensionSelection <PSMetricDimension[]>] -TimeAggregation <String>
 -Operator <String> -Threshold <Double> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

### DynamicThresholdParameterSet
```
<<<<<<< HEAD
New-AzMetricAlertRuleV2Criteria -MetricName <String> [-MetricNamespace <String>]
 [-DimensionSelection <PSMetricDimension[]>] -TimeAggregation <String> -Operator <String>
 -DynamicThreshold <String> [-Sensitivity <String>] [-FailingPeriod <Int32>] [-TotalPeriod <Int32>]
 [-IgnoreDataBefore <DateTime>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzMetricAlertRuleV2Criteria** cmdlet creates a local metric criteria object to be used as an input Add-AzMetricAlertRuleV2 cmdlet which creates a new metric alert rule.
=======
New-AzMetricAlertRuleV2Criteria [-DynamicThreshold] -MetricName <String> [-MetricNamespace <String>]
 [-SkipMetricValidation <Boolean>] [-DimensionSelection <PSMetricDimension[]>] -TimeAggregation <String>
 -Operator <String> [-ThresholdSensitivity <String>] [-ViolationCount <Int32>]
 [-ExaminedAggregatedPointCount <Int32>] [-IgnoreDataBefore <DateTime>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### WebtestParameterSet
```
New-AzMetricAlertRuleV2Criteria [-WebTest] -WebTestId <String> -ApplicationInsightsId <String>
 [-FailedLocationCount <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzMetricAlertRuleV2Criteria** cmdlet creates a local metric criteria object to be used as an input [Add-AzMetricAlertRuleV2](https://docs.microsoft.com/powershell/module/az.monitor/add-azmetricalertrulev2) cmdlet which creates a new metric alert rule.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## EXAMPLES

### Example 1: Create a simple metric alert criteria

```powershell
PS C:\> New-AzMetricAlertRuleV2Criteria -MetricName "Percentage CPU" -MetricNameSpace "Microsoft.Compute/virtualMachines" -TimeAggregation Average -Operator GreaterThan -Threshold 5

<<<<<<< HEAD
Name                 : metric1
MetricName           : Percentage CPU
MetricNamespace      : Microsoft.Compute/virtualMachines
OperatorProperty     : GreaterThan
TimeAggregation      : Average
Threshold            : 5
Dimensions           :
AdditionalProperties :
=======
CriterionType        : StaticThresholdCriterion
OperatorProperty     : GreaterThan
Threshold            : 5
AdditionalProperties :
Name                 : metric1
MetricName           : Percentage CPU
MetricNamespace      : Microsoft.Compute/virtualMachines
TimeAggregation      : Average
Dimensions           :
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

This command creates a simple metric alert criteria that can be used in a metric alert rule

<<<<<<< HEAD
### Example 2: Create a more complex metric alert criteria

```powershell
PS C:\>New-AzMetricAlertRuleV2DimensionSelection -DimensionName "availabilityResult/name" -ValuesToInclude "gdtest" | New-AzMetricAlertRuleV2Criteria -MetricName "availabilityResults/availabilityPercentage" -TimeAggregation Average -Operator GreaterThan -Threshold 2
Name                 : metric1
MetricName           : availabilityResults/availabilityPercentage
MetricNamespace      :
OperatorProperty     : GreaterThan
TimeAggregation      : Average
Threshold            : 2
Dimensions           : {availabilityResult/name}
AdditionalProperties :
=======
### Example 2: Create a dynamic metric alert criteria

```powershell
PS C:\>New-AzMetricAlertRuleV2Criteria -Dynamic -MetricName "Percentage CPU" -MetricNameSpace "Microsoft.Compute/virtualMachines" -TimeAggregation Average -Operator GreaterThan -ThresholdSensitivity Medium -ViolationCount 2 -ExaminedAggregatedPointCount 4
CriterionType        : DynamicThresholdCriterion
OperatorProperty     : GreaterThan
AlertSensitivity     : Medium
FailingPeriods       : Microsoft.Azure.Management.Monitor.Models.DynamicThresholdFailingPeriods
IgnoreDataBefore     :
AdditionalProperties :
Name                 : metric1
MetricName           : Percentage CPU
MetricNamespace      : Microsoft.Compute/virtualMachines
TimeAggregation      : Average
Dimensions           :
```

This command creates a Dynamic metric alert criteria that can be used in a metric alert rule

### Example 3: Create a more complex metric alert criteria

```powershell
PS C:\>New-AzMetricAlertRuleV2DimensionSelection -DimensionName "availabilityResult/name" -ValuesToInclude "gdtest" | New-AzMetricAlertRuleV2Criteria -MetricName "availabilityResults/availabilityPercentage" -TimeAggregation Average -Operator GreaterThan -Threshold 2
CriterionType        : StaticThresholdCriterion
OperatorProperty     : GreaterThan
Threshold            : 2
AdditionalProperties :
Name                 : metric1
MetricName           : availabilityResults/availabilityPercentage
MetricNamespace      :
TimeAggregation      : Average
Dimensions           : {availabilityResult/name}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

This set of commands creates a more complex metric alert criteria which includes dimension selection

<<<<<<< HEAD
## PARAMETERS

=======
### Example 4: Create a webtest availability criteria

```powershell
PS C:\>New-AzMetricAlertRuleV2Criteria -WebTest -WebTestId "/subscriptions/00000000-0000-0000-0000-0000000/resourceGroups/012345/providers/Microsoft.Insights/webtests/PingTest-appInsights" -ApplicationInsightsId "/subscriptions/00000000-0000-0000-0000-0000000/resourceGroups/012345/providers/Microsoft.Insights/components/appInsights" -FailedLocationCount 3
CriterionType        : WebtestLocationAvailabilityCriterion
WebTestId            : /subscriptions/00000000-0000-0000-0000-0000000/resourceGroups/012345/providers/Microsoft.Insights/webtests/PingTest-appInsights
ComponentId          : /subscriptions/00000000-0000-0000-0000-0000000/resourceGroups/012345/providers/Microsoft.Insights/components/appInsights
FailedLocationCount  : 3
AdditionalProperties :
```

This command creates a webtest availability criteria that can be used in a metric alert rule

## PARAMETERS

### -ApplicationInsightsId
The Application Insights resource Id.

```yaml
Type: System.String
Parameter Sets: WebtestParameterSet
Aliases: componentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DimensionSelection
List of dimension conditions

```yaml
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSMetricDimension[]
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DynamicThreshold
<<<<<<< HEAD
The Dynamic Threshold for rule condition

```yaml
Type: System.String
=======
Switch parameter for using Dynamic Threshold Type

```yaml
Type: System.Management.Automation.SwitchParameter
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: DynamicThresholdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -FailingPeriod
The Failing Period for rule condition
=======
### -ExaminedAggregatedPointCount
The Total number of examined points
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Int32
Parameter Sets: DynamicThresholdParameterSet
<<<<<<< HEAD
Aliases:
=======
Aliases: TotalPeriod, NumberOfExaminedAggregatedPoints

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailedLocationCount
The minimum number of failed locations to raise an alert.

```yaml
Type: System.Int32
Parameter Sets: WebtestParameterSet
Aliases: AlertLocationThreshold
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreDataBefore
The IgnoreDataBefore parameter

```yaml
Type: System.DateTime
Parameter Sets: DynamicThresholdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricName
The metric name for rule

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricNamespace
The Namespace of the metric

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operator
The rule condition operator

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -Sensitivity
The sensitivity for rule condition

```yaml
Type: System.String
Parameter Sets: DynamicThresholdParameterSet
=======
### -SkipMetricValidation
Allows creating an alert rule on a custom metric that isn't yet emitted, by causing the metric validation to be skipped

```yaml
Type: System.Boolean
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Threshold
The threshold for rule condition

```yaml
Type: System.Double
Parameter Sets: StaticThresholdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
=======
### -ThresholdSensitivity
The sensitivity for rule condition

```yaml
Type: System.String
Parameter Sets: DynamicThresholdParameterSet
Aliases: Sensitivity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
### -TimeAggregation
The aggregation operation used to roll up multiple metric values across the window interval

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: StaticThresholdParameterSet, DynamicThresholdParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -TotalPeriod
The Total Period for rule condition
=======
### -ViolationCount
The minimum number of violations required within the selected lookback time window required to raise an alert
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: System.Int32
Parameter Sets: DynamicThresholdParameterSet
<<<<<<< HEAD
=======
Aliases: FailingPeriod, NumberOfViolations

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebTest
Switch parameter for using availability criteria Type

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WebtestParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
=======
### -WebTestId
The Application Insights web test Id.

```yaml
Type: System.String
Parameter Sets: WebtestParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSMetricDimension[]

## OUTPUTS

<<<<<<< HEAD
### Microsoft.Azure.Commands.Insights.OutputClasses.PSMetricCriteria
=======
### Microsoft.Azure.Commands.Insights.OutputClasses.IPSMultiMetricCriteria
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## NOTES

## RELATED LINKS
