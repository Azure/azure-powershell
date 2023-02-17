---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaFilterTrackPropertyConditionObject
schema: 2.0.0
---

# New-AzMediaFilterTrackPropertyConditionObject

## SYNOPSIS
Create an in-memory object for FilterTrackPropertyCondition.

## SYNTAX

```
New-AzMediaFilterTrackPropertyConditionObject -Operation <FilterTrackPropertyCompareOperation>
 -Property <FilterTrackPropertyType> -Value <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FilterTrackPropertyCondition.

## EXAMPLES

### Example 1: Create an in-memory object for FilterTrackPropertyCondition.
```powershell
New-AzMediaFilterTrackPropertyConditionObject -Operation 'Equal' -Property 'Type' -Value "Audio"
```

```output
Operation Property Value
--------- -------- -----
Equal     Type     Audio
```

Create an in-memory object for FilterTrackPropertyCondition.

## PARAMETERS

### -Operation
The track property condition operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Support.FilterTrackPropertyCompareOperation
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The track property type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Support.FilterTrackPropertyType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The track property value.

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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.FilterTrackPropertyCondition

## NOTES

ALIASES

## RELATED LINKS

