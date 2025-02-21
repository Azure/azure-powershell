---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstringnotendswithadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridStringNotEndsWithAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for StringNotEndsWithAdvancedFilter.

## SYNTAX

```
New-AzEventGridStringNotEndsWithAdvancedFilterObject [-Key <String>] [-Value <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StringNotEndsWithAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for StringNotEndsWithAdvancedFilter.
```powershell
New-AzEventGridStringNotEndsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotEndsWith
```

Create an in-memory object for StringNotEndsWithAdvancedFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StringNotEndsWithAdvancedFilter

## NOTES

## RELATED LINKS

