---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstringnotbeginswithadvancedfilterobject
schema: 2.0.0
---

# New-AzEventGridStringNotBeginsWithAdvancedFilterObject

## SYNOPSIS
Create an in-memory object for StringNotBeginsWithAdvancedFilter.

## SYNTAX

```
New-AzEventGridStringNotBeginsWithAdvancedFilterObject [-Value <String[]>] [-Key <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StringNotBeginsWithAdvancedFilter.

## EXAMPLES

### Example 1: Create an in-memory object for StringNotBeginsWithAdvancedFilter.
```powershell
New-AzEventGridStringNotBeginsWithAdvancedFilterObject -Key "testKey" -Value "value1","value2"
```

```output
Key     OperatorType
---     ------------
testKey StringNotBeginsWith
```

Create an in-memory object for StringNotBeginsWithAdvancedFilter.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StringNotBeginsWithAdvancedFilter

## NOTES

## RELATED LINKS
