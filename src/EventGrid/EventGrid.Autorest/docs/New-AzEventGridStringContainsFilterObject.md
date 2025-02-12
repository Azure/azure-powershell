---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstringcontainsfilterobject
schema: 2.0.0
---

# New-AzEventGridStringContainsFilterObject

## SYNOPSIS
Create an in-memory object for StringContainsFilter.

## SYNTAX

```
New-AzEventGridStringContainsFilterObject [-Key <String>] [-Value <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StringContainsFilter.

## EXAMPLES

### Example 1: Create an in-memory object for StringContainsFilter.
```powershell
New-AzEventGridStringContainsFilterObject -Key "testKey" -Value "value1","value2"
```

```output
New-AzEventGridStringContainsFilterObject -Key "testKey" -Value "value1","value2"
```

Create an in-memory object for StringContainsFilter.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StringContainsFilter

## NOTES

## RELATED LINKS

