---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaFilterTrackSelectionObject
schema: 2.0.0
---

# New-AzMediaFilterTrackSelectionObject

## SYNOPSIS
Create an in-memory object for FilterTrackSelection.

## SYNTAX

```
New-AzMediaFilterTrackSelectionObject -TrackSelection <IFilterTrackPropertyCondition[]> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FilterTrackSelection.

## EXAMPLES

### Example 1: Create an in-memory object for ContentKeyPolicyOption.
```powershell
$filterTrackProperty = New-AzMediaFilterTrackPropertyConditionObject -Operation 'Equal' -Property 'Type' -Value "Audio"
New-AzMediaFilterTrackSelectionObject -TrackSelection $filterTrackProperty
```

```output
TrackSelection
--------------
{{…
```

Create an in-memory object for ContentKeyPolicyOption.

## PARAMETERS

### -TrackSelection
The track selections.
To construct, see NOTES section for TRACKSELECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.IFilterTrackPropertyCondition[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.FilterTrackSelection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRACKSELECTION <IFilterTrackPropertyCondition[]>`: The track selections.
  - `Operation <FilterTrackPropertyCompareOperation>`: The track property condition operation.
  - `Property <FilterTrackPropertyType>`: The track property type.
  - `Value <String>`: The track property value.

## RELATED LINKS

