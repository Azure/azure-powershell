---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstringinadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridStringInAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for StringInAdvancedFilter.

## SYNTAX

```
New-AzEventGridStringInAdvancedFilterObject [-Key <String>] [-Value <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StringInAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for StringInAdvancedFilter.
```powershell
New-AzEventGridStringInAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringIn
```

Create an in-memory object for StringInAdvancedFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StringInAdvancedFilter

## NOTES

## RELATED LINKS

