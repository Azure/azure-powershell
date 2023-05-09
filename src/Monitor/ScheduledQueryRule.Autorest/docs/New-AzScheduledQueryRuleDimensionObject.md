---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzScheduledQueryRuleDimensionObject
schema: 2.0.0
---

# New-AzScheduledQueryRuleDimensionObject

## SYNOPSIS
Create an in-memory object for Dimension.

## SYNTAX

```
New-AzScheduledQueryRuleDimensionObject -Name <String> -Operator <DimensionOperator> -Value <String[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Dimension.

## EXAMPLES

### Example 1: Create dimension object
```powershell
New-AzScheduledQueryRuleDimensionObject -Name Computer -Operator Include -Value *
```

Create dimension object

## PARAMETERS

### -Name
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
Operator for dimension values.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Support.DimensionOperator
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
List of dimension values.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.Dimension

## NOTES

ALIASES

## RELATED LINKS

