---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/new-azmediaservicesstreamingpolicy
schema: 2.0.0
---

# New-AzMediaServicesStreamingPolicy

## SYNOPSIS
Create a Streaming Policy in the Media Services account

## SYNTAX

```
New-AzMediaServicesStreamingPolicy -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CommonEncryptionCbcClearTrack <ITrackSelection[]>]
 [-CommonEncryptionCbcsContentKeysDefaultKeyLabel <String>]
 [-CommonEncryptionCbcsContentKeysDefaultKeyPolicyName <String>]
 [-CommonEncryptionCbcsContentKeysKeyToTrackMapping <IStreamingPolicyContentKey[]>]
 [-CommonEncryptionCbcsDrmPlayReadyCustomAttribute <String>]
 [-CommonEncryptionCbcsDrmPlayReadyCustomLicenseAcquisitionUrlTemplate <String>]
 [-CommonEncryptionCbcsDrmWidevineCustomLicenseAcquisitionUrlTemplate <String>]
 [-CommonEncryptionCbcsEnabledProtocolsDash] [-CommonEncryptionCbcsEnabledProtocolsDownload]
 [-CommonEncryptionCbcsEnabledProtocolsHl] [-CommonEncryptionCbcsEnabledProtocolsSmoothStreaming]
 [-CommonEncryptionCencClearTrack <ITrackSelection[]>]
 [-CommonEncryptionCencContentKeysDefaultKeyLabel <String>]
 [-CommonEncryptionCencContentKeysDefaultKeyPolicyName <String>]
 [-CommonEncryptionCencContentKeysKeyToTrackMapping <IStreamingPolicyContentKey[]>]
 [-CommonEncryptionCencDrmPlayReadyCustomAttribute <String>]
 [-CommonEncryptionCencDrmPlayReadyCustomLicenseAcquisitionUrlTemplate <String>]
 [-CommonEncryptionCencDrmWidevineCustomLicenseAcquisitionUrlTemplate <String>]
 [-CommonEncryptionCencEnabledProtocolsDash] [-CommonEncryptionCencEnabledProtocolsDownload]
 [-CommonEncryptionCencEnabledProtocolsHl] [-CommonEncryptionCencEnabledProtocolsSmoothStreaming]
 [-DefaultContentKeyPolicyName <String>] [-EnvelopeEncryptionClearTrack <ITrackSelection[]>]
 [-EnvelopeEncryptionContentKeysDefaultKeyLabel <String>]
 [-EnvelopeEncryptionContentKeysDefaultKeyPolicyName <String>]
 [-EnvelopeEncryptionContentKeysKeyToTrackMapping <IStreamingPolicyContentKey[]>]
 [-EnvelopeEncryptionCustomKeyAcquisitionUrlTemplate <String>] [-EnvelopeEncryptionEnabledProtocolsDash]
 [-EnvelopeEncryptionEnabledProtocolsDownload] [-EnvelopeEncryptionEnabledProtocolsHl]
 [-EnvelopeEncryptionEnabledProtocolsSmoothStreaming] [-FairPlayAllowPersistentLicense]
 [-FairPlayCustomLicenseAcquisitionUrlTemplate <String>] [-NoEncryptionEnabledProtocolsDash]
 [-NoEncryptionEnabledProtocolsDownload] [-NoEncryptionEnabledProtocolsHl]
 [-NoEncryptionEnabledProtocolsSmoothStreaming] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Streaming Policy in the Media Services account

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

### -AccountName
The Media Services account name.

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

### -CommonEncryptionCbcClearTrack
Representing which tracks should not be encrypted
To construct, see NOTES section for COMMONENCRYPTIONCBCCLEARTRACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ITrackSelection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCbcsContentKeysDefaultKeyLabel
Label can be used to specify Content Key when creating a Streaming Locator

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

### -CommonEncryptionCbcsContentKeysDefaultKeyPolicyName
Policy used by Default Key

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

### -CommonEncryptionCbcsContentKeysKeyToTrackMapping
Representing tracks needs separate content key
To construct, see NOTES section for COMMONENCRYPTIONCBCSCONTENTKEYSKEYTOTRACKMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IStreamingPolicyContentKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCbcsDrmPlayReadyCustomAttribute
Custom attributes for PlayReady

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

### -CommonEncryptionCbcsDrmPlayReadyCustomLicenseAcquisitionUrlTemplate
Template for the URL of the custom service delivering licenses to end user players.
Not required when using Azure Media Services for issuing licenses.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -CommonEncryptionCbcsDrmWidevineCustomLicenseAcquisitionUrlTemplate
Template for the URL of the custom service delivering licenses to end user players.
Not required when using Azure Media Services for issuing licenses.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -CommonEncryptionCbcsEnabledProtocolsDash
Enable DASH protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCbcsEnabledProtocolsDownload
Enable Download protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCbcsEnabledProtocolsHl
Enable HLS protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCbcsEnabledProtocolsSmoothStreaming
Enable SmoothStreaming protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencClearTrack
Representing which tracks should not be encrypted
To construct, see NOTES section for COMMONENCRYPTIONCENCCLEARTRACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ITrackSelection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencContentKeysDefaultKeyLabel
Label can be used to specify Content Key when creating a Streaming Locator

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

### -CommonEncryptionCencContentKeysDefaultKeyPolicyName
Policy used by Default Key

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

### -CommonEncryptionCencContentKeysKeyToTrackMapping
Representing tracks needs separate content key
To construct, see NOTES section for COMMONENCRYPTIONCENCCONTENTKEYSKEYTOTRACKMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IStreamingPolicyContentKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencDrmPlayReadyCustomAttribute
Custom attributes for PlayReady

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

### -CommonEncryptionCencDrmPlayReadyCustomLicenseAcquisitionUrlTemplate
Template for the URL of the custom service delivering licenses to end user players.
Not required when using Azure Media Services for issuing licenses.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -CommonEncryptionCencDrmWidevineCustomLicenseAcquisitionUrlTemplate
Template for the URL of the custom service delivering licenses to end user players.
Not required when using Azure Media Services for issuing licenses.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -CommonEncryptionCencEnabledProtocolsDash
Enable DASH protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencEnabledProtocolsDownload
Enable Download protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencEnabledProtocolsHl
Enable HLS protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommonEncryptionCencEnabledProtocolsSmoothStreaming
Enable SmoothStreaming protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultContentKeyPolicyName
Default ContentKey used by current Streaming Policy

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionClearTrack
Representing which tracks should not be encrypted
To construct, see NOTES section for ENVELOPEENCRYPTIONCLEARTRACK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ITrackSelection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionContentKeysDefaultKeyLabel
Label can be used to specify Content Key when creating a Streaming Locator

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

### -EnvelopeEncryptionContentKeysDefaultKeyPolicyName
Policy used by Default Key

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

### -EnvelopeEncryptionContentKeysKeyToTrackMapping
Representing tracks needs separate content key
To construct, see NOTES section for ENVELOPEENCRYPTIONCONTENTKEYSKEYTOTRACKMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IStreamingPolicyContentKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionCustomKeyAcquisitionUrlTemplate
Template for the URL of the custom service delivering keys to end user players.
Not required when using Azure Media Services for issuing keys.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -EnvelopeEncryptionEnabledProtocolsDash
Enable DASH protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionEnabledProtocolsDownload
Enable Download protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionEnabledProtocolsHl
Enable HLS protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvelopeEncryptionEnabledProtocolsSmoothStreaming
Enable SmoothStreaming protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FairPlayAllowPersistentLicense
All license to be persistent or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FairPlayCustomLicenseAcquisitionUrlTemplate
Template for the URL of the custom service delivering licenses to end user players.
Not required when using Azure Media Services for issuing licenses.
The template supports replaceable tokens that the service will update at runtime with the value specific to the request.
The currently supported token values are {AlternativeMediaId}, which is replaced with the value of StreamingLocatorId.AlternativeMediaId, and {ContentKeyId}, which is replaced with the value of identifier of the key being requested.

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

### -Name
The Streaming Policy name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: StreamingPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEncryptionEnabledProtocolsDash
Enable DASH protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEncryptionEnabledProtocolsDownload
Enable Download protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEncryptionEnabledProtocolsHl
Enable HLS protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoEncryptionEnabledProtocolsSmoothStreaming
Enable SmoothStreaming protocol or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the Azure subscription.

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

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IStreamingPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


COMMONENCRYPTIONCBCCLEARTRACK <ITrackSelection[]>: Representing which tracks should not be encrypted
  - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
    - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
    - `Property <TrackPropertyType>`: Track property type
    - `[Value <String>]`: Track property value

COMMONENCRYPTIONCBCSCONTENTKEYSKEYTOTRACKMAPPING <IStreamingPolicyContentKey[]>: Representing tracks needs separate content key
  - `[Label <String>]`: Label can be used to specify Content Key when creating a Streaming Locator
  - `[PolicyName <String>]`: Policy used by Content Key
  - `[Track <ITrackSelection[]>]`: Tracks which use this content key
    - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
      - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
      - `Property <TrackPropertyType>`: Track property type
      - `[Value <String>]`: Track property value

COMMONENCRYPTIONCENCCLEARTRACK <ITrackSelection[]>: Representing which tracks should not be encrypted
  - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
    - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
    - `Property <TrackPropertyType>`: Track property type
    - `[Value <String>]`: Track property value

COMMONENCRYPTIONCENCCONTENTKEYSKEYTOTRACKMAPPING <IStreamingPolicyContentKey[]>: Representing tracks needs separate content key
  - `[Label <String>]`: Label can be used to specify Content Key when creating a Streaming Locator
  - `[PolicyName <String>]`: Policy used by Content Key
  - `[Track <ITrackSelection[]>]`: Tracks which use this content key
    - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
      - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
      - `Property <TrackPropertyType>`: Track property type
      - `[Value <String>]`: Track property value

ENVELOPEENCRYPTIONCLEARTRACK <ITrackSelection[]>: Representing which tracks should not be encrypted
  - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
    - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
    - `Property <TrackPropertyType>`: Track property type
    - `[Value <String>]`: Track property value

ENVELOPEENCRYPTIONCONTENTKEYSKEYTOTRACKMAPPING <IStreamingPolicyContentKey[]>: Representing tracks needs separate content key
  - `[Label <String>]`: Label can be used to specify Content Key when creating a Streaming Locator
  - `[PolicyName <String>]`: Policy used by Content Key
  - `[Track <ITrackSelection[]>]`: Tracks which use this content key
    - `[TrackSelections <ITrackPropertyCondition[]>]`: TrackSelections is a track property condition list which can specify track(s)
      - `Operation <TrackPropertyCompareOperation>`: Track property condition operation
      - `Property <TrackPropertyType>`: Track property type
      - `[Value <String>]`: Track property value

## RELATED LINKS

