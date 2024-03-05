---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for AdvancedFilter.

## SYNTAX

```
New-AzEventGridAdvancedFilterObject -OperatorType <String> [-Key <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for AdvancedFilter.
```powershell
New-AzEventGridAdvancedFilterObject -OperatorType NumberIn -Key "TestKey"
```

```output
Key     OperatorType
---     ------------
TestKey NumberIn
```

Create an in-memory object for AdvancedFilter.

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

### -OperatorType
The operator type used for filtering, e.g., NumberIn, StringContains, BoolEquals and others.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.AdvancedFilter

## NOTES

## RELATED LINKS

