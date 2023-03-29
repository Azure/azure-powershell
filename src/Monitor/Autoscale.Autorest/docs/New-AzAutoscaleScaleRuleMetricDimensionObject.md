---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzAutoscaleScaleRuleMetricDimensionObject
schema: 2.0.0
---

# New-AzAutoscaleScaleRuleMetricDimensionObject

## SYNOPSIS
Create an in-memory object for ScaleRuleMetricDimension.

## SYNTAX

```
New-AzAutoscaleScaleRuleMetricDimensionObject -DimensionName <String>
 -Operator <ScaleRuleMetricDimensionOperationType> -Value <String[]> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScaleRuleMetricDimension.

## EXAMPLES

### Example 1: Create scale rule metric dimension object
```powershell
New-AzAutoscaleScaleRuleMetricDimensionObject -DimensionName VMName -Operator 'Equals' -Value test-vm
```

Create scale rule metric dimension object

## PARAMETERS

### -DimensionName
Name of the dimension.

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

### -Operator
the dimension operator.
Only 'Equals' and 'NotEquals' are supported.
'Equals' being equal to any of the values.
'NotEquals' being not equal to all of the values.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ScaleRuleMetricDimensionOperationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
list of dimension values.
For example: ["App1","App2"].

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.ScaleRuleMetricDimension

## NOTES

ALIASES

## RELATED LINKS

