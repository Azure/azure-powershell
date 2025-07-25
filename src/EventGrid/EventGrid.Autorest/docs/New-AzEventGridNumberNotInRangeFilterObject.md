---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridnumbernotinrangefilterobject
schema: 2.0.0
---

# New-AzEventGridNumberNotInRangeFilterObject

## SYNOPSIS
Create an in-memory object for NumberNotInRangeFilter.

## SYNTAX

```
New-AzEventGridNumberNotInRangeFilterObject [-Key <String>] [-Value <Double[][]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NumberNotInRangeFilter.

## EXAMPLES

### Example 1: Create an in-memory object for NumberNotInRangeFilter.
```powershell
$valuesObj = @(11.11, 22.22, 33.33, 44.44)
New-AzEventGridNumberNotInRangeFilterObject -Key "testKey" -Value @(,$valuesObj)
```

```output
Key     OperatorType
---     ------------
testKey NumberNotInRange
```

Create an in-memory object for NumberNotInRangeFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.NumberNotInRangeFilter

## NOTES

## RELATED LINKS

