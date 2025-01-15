---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridisnotnulladvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridIsNotNullAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for IsNotNullAdvancedFilter.

## SYNTAX

```
New-AzEventGridIsNotNullAdvancedFilterObject [-Key <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IsNotNullAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for IsNotNullAdvancedFilter.
```powershell
New-AzEventGridIsNotNullAdvancedFilterObject -Key "testkey"
```

```output
Key     OperatorType
---     ------------
testkey IsNotNull
```

Create an in-memory object for IsNotNullAdvancedFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IsNotNullAdvancedFilter

## NOTES

## RELATED LINKS

