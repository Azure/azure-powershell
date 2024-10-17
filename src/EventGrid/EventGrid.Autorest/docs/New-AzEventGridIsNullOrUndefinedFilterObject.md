---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridisnullorundefinedfilterobject
schema: 2.0.0
---

# New-AzEventGridIsNullOrUndefinedFilterObject

## SYNOPSIS
Create an in-memory object for IsNullOrUndefinedFilter.

## SYNTAX

```
New-AzEventGridIsNullOrUndefinedFilterObject [-Key <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IsNullOrUndefinedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for IsNullOrUndefinedFilter.
```powershell
New-AzEventGridIsNullOrUndefinedFilterObject -Key "testKey"
```

```output
Key     OperatorType
---     ------------
testKey IsNullOrUndefined
```

Create an in-memory object for IsNullOrUndefinedFilter.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IsNullOrUndefinedFilter

## NOTES

## RELATED LINKS

