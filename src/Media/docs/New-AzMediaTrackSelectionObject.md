---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaTrackSelectionObject
schema: 2.0.0
---

# New-AzMediaTrackSelectionObject

## SYNOPSIS
Create an in-memory object for TrackSelection.

## SYNTAX

```
New-AzMediaTrackSelectionObject [-TrackSelections <ITrackPropertyCondition[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TrackSelection.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -TrackSelections
TrackSelections is a track property condition list which can specify track(s).
To construct, see NOTES section for TRACKSELECTIONS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.ITrackPropertyCondition[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.TrackSelection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRACKSELECTIONS <ITrackPropertyCondition[]>`: TrackSelections is a track property condition list which can specify track(s).
  - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
  - `Property <TrackPropertyType>`: Track property type
  - `[Value <String>]`: Track property value

## RELATED LINKS

