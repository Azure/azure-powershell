---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridnumbernotinfilterobject
schema: 2.0.0
---

# New-AzEventGridNumberNotInFilterObject

## SYNOPSIS
Create an in-memory object for NumberNotInFilter.

## SYNTAX

```
New-AzEventGridNumberNotInFilterObject [-Key <String>] [-Value <Double[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NumberNotInFilter.

## EXAMPLES

### Example 1: Create an in-memory object for NumberNotInFilter.
```powershell
New-AzEventGridNumberNotInFilterObject -Key "testKey" -Value 11.22,22.33
```

```output
Key     OperatorType
---     ------------
testKey NumberNotIn
```

Create an in-memory object for NumberNotInFilter.

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
Type: System.Double[]
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.NumberNotInFilter

## NOTES

## RELATED LINKS

