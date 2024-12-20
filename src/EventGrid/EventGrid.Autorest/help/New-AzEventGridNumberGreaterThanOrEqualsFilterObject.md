---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridnumbergreaterthanorequalsfilterobject
schema: 2.0.0
---

# New-AzEventGridNumberGreaterThanOrEqualsFilterObject

## SYNOPSIS
Create an in-memory object for NumberGreaterThanOrEqualsFilter.

## SYNTAX

```
New-AzEventGridNumberGreaterThanOrEqualsFilterObject [-Key <String>] [-Value <Double>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NumberGreaterThanOrEqualsFilter.

## EXAMPLES

### Example 1: Create an in-memory object for NumberGreaterThanOrEqualsFilter.
```powershell
New-AzEventGridNumberGreaterThanOrEqualsFilterObject -Key "testKey" -Value 11.22
```

```output
Key     OperatorType              Value
---     ------------              -----
testKey NumberGreaterThanOrEquals 11.22
```

Create an in-memory object for NumberGreaterThanOrEqualsFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.NumberGreaterThanOrEqualsFilter

## NOTES

## RELATED LINKS

