---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaLiveEventTranscriptionObject
schema: 2.0.0
---

# New-AzMediaLiveEventTranscriptionObject

## SYNOPSIS
Create an in-memory object for LiveEventTranscription.

## SYNTAX

```
New-AzMediaLiveEventTranscriptionObject [-InputTrackSelection <ILiveEventInputTrackSelection[]>]
 [-Language <String>] [-OutputTranscriptionTrackName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LiveEventTranscription.

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

### -InputTrackSelection
Provides a mechanism to select the audio track in the input live feed, to which speech-to-text transcription is applied.
This property is reserved for future use, any value set on this property will be ignored.
To construct, see NOTES section for INPUTTRACKSELECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.ILiveEventInputTrackSelection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Language
Specifies the language (locale) to be used for speech-to-text transcription – it should match the spoken language in the audio track.
The value should be in BCP-47 format (e.g: 'en-US').
See https://go.microsoft.com/fwlink/?linkid=2133742 for more information about the live transcription feature and the list of supported languages.

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

### -OutputTranscriptionTrackName
The output track name.
This property is reserved for future use, any value set on this property will be ignored.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.LiveEventTranscription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTTRACKSELECTION <ILiveEventInputTrackSelection[]>`: Provides a mechanism to select the audio track in the input live feed, to which speech-to-text transcription is applied. This property is reserved for future use, any value set on this property will be ignored.
  - `[Operation <String>]`: Comparing operation. This property is reserved for future use, any value set on this property will be ignored.
  - `[Property <String>]`: Property name to select. This property is reserved for future use, any value set on this property will be ignored.
  - `[Value <String>]`: Property value to select. This property is reserved for future use, any value set on this property will be ignored.

## RELATED LINKS

