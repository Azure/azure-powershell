---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/update-azmediaservicesliveevent
schema: 2.0.0
---

# Update-AzMediaServicesLiveEvent

## SYNOPSIS
Updates settings on an existing live event.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMediaServicesLiveEvent -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-CrossSiteAccessPolicyClientAccessPolicy <String>]
 [-CrossSiteAccessPolicyCrossDomainPolicy <String>] [-Description <String>]
 [-EncodingKeyFrameInterval <TimeSpan>] [-EncodingPresetName <String>] [-EncodingStretchMode <StretchMode>]
 [-EncodingType <LiveEventEncodingType>] [-HostnamePrefix <String>] [-InputAccessControlIPAllow <IIPRange[]>]
 [-InputAccessToken <String>] [-InputEndpoint <ILiveEventEndpoint[]>]
 [-InputKeyFrameIntervalDuration <String>] [-InputStreamingProtocol <LiveEventInputProtocol>]
 [-PreviewAccessControlIPAllow <IIPRange[]>] [-PreviewAlternativeMediaId <String>]
 [-PreviewEndpoint <ILiveEventEndpoint[]>] [-PreviewLocator <String>] [-PreviewStreamingPolicyName <String>]
 [-StreamOption <StreamOptionsFlag[]>] [-Tag <Hashtable>] [-Transcription <ILiveEventTranscription[]>]
 [-UseStaticHostname] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMediaServicesLiveEvent -InputObject <IMediaServicesIdentity> -Location <String>
 [-CrossSiteAccessPolicyClientAccessPolicy <String>] [-CrossSiteAccessPolicyCrossDomainPolicy <String>]
 [-Description <String>] [-EncodingKeyFrameInterval <TimeSpan>] [-EncodingPresetName <String>]
 [-EncodingStretchMode <StretchMode>] [-EncodingType <LiveEventEncodingType>] [-HostnamePrefix <String>]
 [-InputAccessControlIPAllow <IIPRange[]>] [-InputAccessToken <String>]
 [-InputEndpoint <ILiveEventEndpoint[]>] [-InputKeyFrameIntervalDuration <String>]
 [-InputStreamingProtocol <LiveEventInputProtocol>] [-PreviewAccessControlIPAllow <IIPRange[]>]
 [-PreviewAlternativeMediaId <String>] [-PreviewEndpoint <ILiveEventEndpoint[]>] [-PreviewLocator <String>]
 [-PreviewStreamingPolicyName <String>] [-StreamOption <StreamOptionsFlag[]>] [-Tag <Hashtable>]
 [-Transcription <ILiveEventTranscription[]>] [-UseStaticHostname] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates settings on an existing live event.

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -CrossSiteAccessPolicyClientAccessPolicy
The content of clientaccesspolicy.xml used by Silverlight.

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

### -CrossSiteAccessPolicyCrossDomainPolicy
The content of crossdomain.xml used by Silverlight.

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

### -Description
A description for the live event.

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

### -EncodingKeyFrameInterval
Use an ISO 8601 time value between 0.5 to 20 seconds to specify the output fragment length for the video and audio tracks of an encoding live event.
For example, use PT2S to indicate 2 seconds.
For the video track it also defines the key frame interval, or the length of a GoP (group of pictures).
If this value is not set for an encoding live event, the fragment duration defaults to 2 seconds.
The value cannot be set for pass-through live events.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncodingPresetName
The optional encoding preset name, used when encodingType is not None.
This value is specified at creation time and cannot be updated.
If the encodingType is set to Standard, then the default preset name is ‘Default720p’.
Else if the encodingType is set to Premium1080p, the default preset is ‘Default1080p’.

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

### -EncodingStretchMode
Specifies how the input video will be resized to fit the desired output resolution(s).
Default is None

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.StretchMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncodingType
Live event type.
When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output.
When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers.
See https://go.microsoft.com/fwlink/linkid=2095101 for more information.
This property cannot be modified after the live event is created.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.LiveEventEncodingType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostnamePrefix
When useStaticHostname is set to true, the hostnamePrefix specifies the first part of the hostname assigned to the live event preview and ingest endpoints.
The final hostname would be a combination of this prefix, the media service account name and a short code for the Azure Media Services data center.

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

### -InputAccessControlIPAllow
The IP allow list.
To construct, see NOTES section for INPUTACCESSCONTROLIPALLOW properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IIPRange[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputAccessToken
A UUID in string form to uniquely identify the stream.
This can be specified at creation time but cannot be updated.
If omitted, the service will generate a unique value.

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

### -InputEndpoint
The input endpoints for the live event.
To construct, see NOTES section for INPUTENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEventEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputKeyFrameIntervalDuration
ISO 8601 time duration of the key frame interval duration of the input.
This value sets the EXT-X-TARGETDURATION property in the HLS output.
For example, use PT2S to indicate 2 seconds.
Leave the value empty for encoding live events.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputStreamingProtocol
The input protocol for the live event.
This is specified at creation time and cannot be updated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.LiveEventInputProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
The name of the live event, maximum length is 32.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: LiveEventName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PreviewAccessControlIPAllow
The IP allow list.
To construct, see NOTES section for PREVIEWACCESSCONTROLIPALLOW properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IIPRange[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreviewAlternativeMediaId
An alternative media identifier associated with the streaming locator created for the preview.
This value is specified at creation time and cannot be updated.
The identifier can be used in the CustomLicenseAcquisitionUrlTemplate or the CustomKeyAcquisitionUrlTemplate of the StreamingPolicy specified in the StreamingPolicyName field.

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

### -PreviewEndpoint
The endpoints for preview.
Do not share the preview URL with the live event audience.
To construct, see NOTES section for PREVIEWENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEventEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreviewLocator
The identifier of the preview locator in Guid format.
Specifying this at creation time allows the caller to know the preview locator url before the event is created.
If omitted, the service will generate a random identifier.
This value cannot be updated once the live event is created.

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

### -PreviewStreamingPolicyName
The name of streaming policy used for the live event preview.
This value is specified at creation time and cannot be updated.

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

### -ResourceGroupName
The name of the resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamOption
The options to use for the LiveEvent.
This value is specified at creation time and cannot be updated.
The valid values for the array entry values are 'Default' and 'LowLatency'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.StreamOptionsFlag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Transcription
Live transcription settings for the live event.
See https://go.microsoft.com/fwlink/linkid=2133742 for more information about the live transcription feature.
To construct, see NOTES section for TRANSCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEventTranscription[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseStaticHostname
Specifies whether a static hostname would be assigned to the live event preview and ingest endpoints.
This value can only be updated if the live event is in Standby state

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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEvent

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTACCESSCONTROLIPALLOW <IIPRange[]>: The IP allow list.
  - `[Address <String>]`: The IP address.
  - `[Name <String>]`: The friendly name for the IP address range.
  - `[SubnetPrefixLength <Int32?>]`: The subnet mask prefix length (see CIDR notation).

INPUTENDPOINT <ILiveEventEndpoint[]>: The input endpoints for the live event.
  - `[Protocol <String>]`: The endpoint protocol.
  - `[Url <String>]`: The endpoint URL.

INPUTOBJECT <IMediaServicesIdentity>: Identity Parameter
  - `[AccountName <String>]`: The Media Services account name.
  - `[AssetName <String>]`: The Asset name.
  - `[ContentKeyPolicyName <String>]`: The Content Key Policy name.
  - `[FilterName <String>]`: The Account Filter name
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The Job name.
  - `[LiveEventName <String>]`: The name of the live event, maximum length is 32.
  - `[LiveOutputName <String>]`: The name of the live output.
  - `[LocationName <String>]`: The name of the location
  - `[Name <String>]`: 
  - `[OperationId <String>]`: Operation Id.
  - `[ResourceGroupName <String>]`: The name of the resource group within the Azure subscription.
  - `[StreamingEndpointName <String>]`: The name of the streaming endpoint, maximum length is 24.
  - `[StreamingLocatorName <String>]`: The Streaming Locator name.
  - `[StreamingPolicyName <String>]`: The Streaming Policy name.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription.
  - `[TrackName <String>]`: The Asset Track name.
  - `[TransformName <String>]`: The Transform name.

PREVIEWACCESSCONTROLIPALLOW <IIPRange[]>: The IP allow list.
  - `[Address <String>]`: The IP address.
  - `[Name <String>]`: The friendly name for the IP address range.
  - `[SubnetPrefixLength <Int32?>]`: The subnet mask prefix length (see CIDR notation).

PREVIEWENDPOINT <ILiveEventEndpoint[]>: The endpoints for preview. Do not share the preview URL with the live event audience.
  - `[Protocol <String>]`: The endpoint protocol.
  - `[Url <String>]`: The endpoint URL.

TRANSCRIPTION <ILiveEventTranscription[]>: Live transcription settings for the live event. See https://go.microsoft.com/fwlink/linkid=2133742 for more information about the live transcription feature.
  - `[InputTrackSelection <ILiveEventInputTrackSelection[]>]`: Provides a mechanism to select the audio track in the input live feed, to which speech-to-text transcription is applied. This property is reserved for future use, any value set on this property will be ignored.
    - `[Operation <String>]`: Comparing operation. This property is reserved for future use, any value set on this property will be ignored.
    - `[Property <String>]`: Property name to select. This property is reserved for future use, any value set on this property will be ignored.
    - `[Value <String>]`: Property value to select. This property is reserved for future use, any value set on this property will be ignored.
  - `[Language <String>]`: Specifies the language (locale) to be used for speech-to-text transcription – it should match the spoken language in the audio track. The value should be in BCP-47 format (e.g: 'en-US'). See https://go.microsoft.com/fwlink/?linkid=2133742 for more information about the live transcription feature and the list of supported languages.
  - `[OutputTranscriptionTrackName <String>]`: The output track name. This property is reserved for future use, any value set on this property will be ignored.

## RELATED LINKS

