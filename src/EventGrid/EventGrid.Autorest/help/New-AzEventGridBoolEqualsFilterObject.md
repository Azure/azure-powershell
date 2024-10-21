---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridboolequalsfilterobject
schema: 2.0.0
---

# New-AzEventGridBoolEqualsFilterObject

## SYNOPSIS
Create an in-memory object for BoolEqualsFilter.

## SYNTAX

```
New-AzEventGridBoolEqualsFilterObject [-Key <String>] [-Value <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BoolEqualsFilter.

## EXAMPLES

### Example 1: Create an in-memory object for BoolEqualsFilter.
```powershell
New-AzEventGridBoolEqualsFilterObject -Key "testKey" -Value:$true
```

```output
New-AzEventGridBoolEqualsFilterObject -Key "testKey" -Value:$true
```

Create an in-memory object for BoolEqualsFilter.

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
The boolean filter value.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.BoolEqualsFilter

## NOTES

## RELATED LINKS

