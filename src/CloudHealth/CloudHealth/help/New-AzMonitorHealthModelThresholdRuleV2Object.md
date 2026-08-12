---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelthresholdrulev2object
schema: 2.0.0
---

# New-AzMonitorHealthModelThresholdRuleV2Object

## SYNOPSIS
Create an in-memory object for ThresholdRuleV2.

## SYNTAX

```
New-AzMonitorHealthModelThresholdRuleV2Object -Operator <String> [-LookBackWindow <String>]
 [-Sensitivity <String>] [-Threshold <Double>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ThresholdRuleV2.

## EXAMPLES

### Example 1: Build a static threshold rule
```powershell
# Build a static threshold rule for use in an evaluation rule
New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
```

Creates a threshold rule using the GreaterThan operator and a threshold of 90.

## PARAMETERS

### -LookBackWindow
ISO 8601 duration for the historical look-back window used by dynamic threshold computation.
Only applicable when operator is Dynamic.

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

### -Operator
Operator how to compare the signal value with the threshold.

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

### -Sensitivity
Sensitivity level for dynamic threshold detection.
Only applicable when operator is Dynamic.

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

### -Threshold
Threshold value.

```yaml
Type: System.Double
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ThresholdRuleV2

## NOTES

## RELATED LINKS

