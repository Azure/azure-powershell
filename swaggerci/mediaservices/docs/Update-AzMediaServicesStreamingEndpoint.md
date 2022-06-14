---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/update-azmediaservicesstreamingendpoint
schema: 2.0.0
---

# Update-AzMediaServicesStreamingEndpoint

## SYNOPSIS
Updates a existing streaming endpoint.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMediaServicesStreamingEndpoint -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>]
 [-AkamaiSignatureHeaderAuthenticationKeyList <IAkamaiSignatureHeaderAuthenticationKey[]>]
 [-AvailabilitySetName <String>] [-CdnEnabled] [-CdnProfile <String>] [-CdnProvider <String>]
 [-CrossSiteAccessPolicyClientAccessPolicy <String>] [-CrossSiteAccessPolicyCrossDomainPolicy <String>]
 [-CustomHostName <String[]>] [-Description <String>] [-IPAllow <IIPRange[]>] [-MaxCacheAge <Int64>]
 [-ScaleUnit <Int32>] [-SkuCapacity <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMediaServicesStreamingEndpoint -InputObject <IMediaServicesIdentity> -Location <String>
 [-AkamaiSignatureHeaderAuthenticationKeyList <IAkamaiSignatureHeaderAuthenticationKey[]>]
 [-AvailabilitySetName <String>] [-CdnEnabled] [-CdnProfile <String>] [-CdnProvider <String>]
 [-CrossSiteAccessPolicyClientAccessPolicy <String>] [-CrossSiteAccessPolicyCrossDomainPolicy <String>]
 [-CustomHostName <String[]>] [-Description <String>] [-IPAllow <IIPRange[]>] [-MaxCacheAge <Int64>]
 [-ScaleUnit <Int32>] [-SkuCapacity <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a existing streaming endpoint.

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

### -AkamaiSignatureHeaderAuthenticationKeyList
authentication key list
To construct, see NOTES section for AKAMAISIGNATUREHEADERAUTHENTICATIONKEYLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IAkamaiSignatureHeaderAuthenticationKey[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -AvailabilitySetName
This feature is deprecated, do not set a value for this property.

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

### -CdnEnabled
The CDN enabled flag.

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

### -CdnProfile
The CDN profile name.

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

### -CdnProvider
The CDN provider name.

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

### -CustomHostName
The custom host names of the streaming endpoint

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
The streaming endpoint description.

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

### -IPAllow
The IP allow list.
To construct, see NOTES section for IPALLOW properties and create a hash table.

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

### -MaxCacheAge
Max cache age

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the streaming endpoint, maximum length is 24.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: StreamingEndpointName

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

### -ScaleUnit
The number of scale units.
Use the Scale operation to adjust this value.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The streaming endpoint sku capacity.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IStreamingEndpoint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AKAMAISIGNATUREHEADERAUTHENTICATIONKEYLIST <IAkamaiSignatureHeaderAuthenticationKey[]>: authentication key list
  - `[Base64Key <String>]`: authentication key
  - `[Expiration <DateTime?>]`: The expiration time of the authentication key.
  - `[Identifier <String>]`: identifier of the key

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

IPALLOW <IIPRange[]>: The IP allow list.
  - `[Address <String>]`: The IP address.
  - `[Name <String>]`: The friendly name for the IP address range.
  - `[SubnetPrefixLength <Int32?>]`: The subnet mask prefix length (see CIDR notation).

## RELATED LINKS

