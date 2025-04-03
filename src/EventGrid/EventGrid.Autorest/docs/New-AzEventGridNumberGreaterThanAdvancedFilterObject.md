---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridnumbergreaterthanadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridNumberGreaterThanAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for NumberGreaterThanAdvancedFilter.

## SYNTAX

```
New-AzEventGridNumberGreaterThanAdvancedFilterObject [-Key <String>] [-Value <Double>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NumberGreaterThanAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for NumberGreaterThanAdvancedFilter.
```powershell
New-AzEventGridNumberGreaterThanAdvancedFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType      Value
---     ------------      -----
testKey NumberGreaterThan 11.22
```

Create an in-memory object for NumberGreaterThanAdvancedFilter.

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
The filter value.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.NumberGreaterThanAdvancedFilter

## NOTES

## RELATED LINKS

