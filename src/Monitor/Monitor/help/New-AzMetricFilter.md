---
external help file: Az.Metric.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azmetricfilter
schema: 2.0.0
---

# New-AzMetricFilter

## SYNOPSIS
Creates a metric dimension filter that can be used to query metrics.

## SYNTAX

```
New-AzMetricFilter [-Dimension <String>] [-Operator <String>] [-Value <String[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Creates a metric dimension filter that can be used to query metrics.

## EXAMPLES

### Example 1: Create a metric dimension filter
```powershell
New-AzMetricFilter -Dimension City -Operator eq -Value "Seattle","New York"
```

```output
City eq 'Seattle' or City eq 'New York'
```

This command creates metric dimension filter of the format "City eq 'Seattle' or City eq 'New York'".

## PARAMETERS

### -Dimension
The dimension name

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
The operator

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

### -Value
The list of values for the dimension

```yaml
Type: System.String[]
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

### System.String

## NOTES

## RELATED LINKS
