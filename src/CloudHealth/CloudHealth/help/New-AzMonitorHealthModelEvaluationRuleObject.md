---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelevaluationruleobject
schema: 2.0.0
---

# New-AzMonitorHealthModelEvaluationRuleObject

## SYNOPSIS
Create an in-memory object for EvaluationRule.

## SYNTAX

```
New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule <IThresholdRuleV2>
 [-DegradedRule <IThresholdRuleV2>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EvaluationRule.

## EXAMPLES

### Example 1: Combine degraded and unhealthy thresholds
```powershell
$degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
```

Creates the evaluation rules for a signal definition. Only the unhealthy rule is required.

## PARAMETERS

### -DegradedRule
Degraded rule with static threshold.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IThresholdRuleV2
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnhealthyRule
Unhealthy rule with static threshold.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IThresholdRuleV2
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.EvaluationRule

## NOTES

## RELATED LINKS

