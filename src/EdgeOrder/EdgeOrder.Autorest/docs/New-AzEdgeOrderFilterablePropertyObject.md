---
external help file:
Module Name: Az.EdgeOrder
online version: https://learn.microsoft.com/powershell/module/Az.EdgeOrder/new-AzEdgeOrderFilterablePropertyObject
schema: 2.0.0
---

# New-AzEdgeOrderFilterablePropertyObject

## SYNOPSIS
Create an in-memory object for FilterableProperty.

## SYNTAX

```
New-AzEdgeOrderFilterablePropertyObject -SupportedValue <String[]> -Type <SupportedFilterTypes>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FilterableProperty.

## EXAMPLES

### Example 1: Filterable property object 
```powershell
$filterableProperty = New-AzEdgeOrderFilterablePropertyObject -Type "ShipToCountries" -SupportedValue @("US")
$filterableProperty | Format-List
```

```output
SupportedValue : {US}
Type           : ShipToCountries
```

ShipToCountries is mandatory filterable type, SupportedValue can be list of 2 letter valid ISO country codes.

## PARAMETERS

### -SupportedValue
Values to be filtered.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of product filter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Support.SupportedFilterTypes
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.FilterableProperty

## NOTES

## RELATED LINKS

