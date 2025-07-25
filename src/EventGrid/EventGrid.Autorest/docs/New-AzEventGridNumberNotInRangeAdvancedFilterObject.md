---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridnumbernotinrangeadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridNumberNotInRangeAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for NumberNotInRangeAdvancedFilter.

## SYNTAX

```
New-AzEventGridNumberNotInRangeAdvancedFilterObject [-Key <String>] [-Value <Double[][]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NumberNotInRangeAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for NumberNotInRangeAdvancedFilter.
```powershell
$valuesObj = @(11.11, 22.22, 33.33, 44.44)
New-AzEventGridNumberNotInRangeAdvancedFilterObject -Key "testKey" -Value @(,$valuesObj)
```

```output
Key     OperatorType
---     ------------
testKey NumberNotInRange
```

Create an in-memory object for NumberNotInRangeAdvancedFilter.

## PARAMETERS

### -Key
The field/property in the event based on which you want to filter.

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

### -Value
The set of filter values.

```yaml
Type: System.Double[][]
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.NumberNotInRangeAdvancedFilter

## NOTES

## RELATED LINKS

