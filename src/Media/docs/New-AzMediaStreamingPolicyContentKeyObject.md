---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaStreamingPolicyContentKeyObject
schema: 2.0.0
---

# New-AzMediaStreamingPolicyContentKeyObject

## SYNOPSIS
Create an in-memory object for StreamingPolicyContentKey.

## SYNTAX

```
New-AzMediaStreamingPolicyContentKeyObject [-Label <String>] [-PolicyName <String>]
 [-Track <ITrackSelection[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StreamingPolicyContentKey.

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

### -Label
Label can be used to specify Content Key when creating a Streaming Locator.

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

### -PolicyName
Policy used by Content Key.

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

### -Track
Tracks which use this content key.
To construct, see NOTES section for TRACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.ITrackSelection[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.StreamingPolicyContentKey

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRACK <ITrackSelection[]>`: Tracks which use this content key.
  - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
    - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
    - `Property <TrackPropertyType>`: Track property type
    - `[Value <String>]`: Track property value

## RELATED LINKS

