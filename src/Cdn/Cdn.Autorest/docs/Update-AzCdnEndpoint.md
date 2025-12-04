---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azcdnendpoint
schema: 2.0.0
---

# Update-AzCdnEndpoint

## SYNOPSIS
Update an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the update Origin operation.
To update origin groups, use the update Origin group operation.
To update custom domains, use the update Custom Domain operation.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <String>]
 [-OriginHostHeader <String>] [-OriginPath <String>] [-ProbePath <String>]
 [-QueryStringCachingBehavior <String>] [-Tag <Hashtable>] [-UrlSigningKey <IUrlSigningKey[]>]
 [-WebApplicationFirewallPolicyLinkId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCdnEndpoint -InputObject <ICdnIdentity> [-ContentTypesToCompress <String[]>]
 [-DefaultOriginGroupId <String>] [-DeliveryPolicyDescription <String>]
 [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>] [-IsCompressionEnabled] [-IsHttpAllowed]
 [-IsHttpsAllowed] [-OptimizationType <String>] [-OriginHostHeader <String>] [-OriginPath <String>]
 [-ProbePath <String>] [-QueryStringCachingBehavior <String>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProfile
```
Update-AzCdnEndpoint -Name <String> -ProfileInputObject <ICdnIdentity>
 -EndpointUpdateProperty <IEndpointUpdateParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProfileExpanded
```
Update-AzCdnEndpoint -Name <String> -ProfileInputObject <ICdnIdentity> [-ContentTypesToCompress <String[]>]
 [-DefaultOriginGroupId <String>] [-DeliveryPolicyDescription <String>]
 [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>] [-IsCompressionEnabled] [-IsHttpAllowed]
 [-IsHttpsAllowed] [-OptimizationType <String>] [-OriginHostHeader <String>] [-OriginPath <String>]
 [-ProbePath <String>] [-QueryStringCachingBehavior <String>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the update Origin operation.
To update origin groups, use the update Origin group operation.
To update custom domains, use the update Custom Domain operation.

## EXAMPLES

### Example 1: Update an AzureCDN Endpoint under the AzureCDN profile
```powershell
$tags = @{
    Tag1 = 11
    Tag2 = 22
}
Update-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 -Tag $tags -DefaultOriginGroupId $originGroup.Id
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile

### Example 2: Update an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2 = 22
}
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Update-AzCdnEndpoint -Tag $tags -DefaultOriginGroupId $originGroup.Id
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile via identity

### Example 3: Update an AzureCDN Endpoint under the AzureCDN profile, enabled content compression
```powershell
Update-AzCdnEndpoint -Name cdntestcert -ProfileName classicCDNtest -ResourceGroupName yaoshitest -IsCompressionEnabled:$true
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile, enabled content compression

## PARAMETERS

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

### -ContentTypesToCompress
List of content types on which compression applies.
The value should be a valid MIME type.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultOriginGroupId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DeliveryPolicyDescription
User-friendly description of the policy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryPolicyRule
A list of the delivery rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointUpdateProperty
Properties required to create or update an endpoint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEndpointUpdateParameters
Parameter Sets: UpdateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GeoFilter
List of rules defining the user's geo access within a CDN endpoint.
Each geo filter defines an access rule to a specified path or content, e.g.
block APAC for path /pictures/

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IGeoFilter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsCompressionEnabled
Indicates whether content compression is enabled on CDN.
Default value is false.
If compression is enabled, content will be served as compressed if user requests for a compressed version.
Content won't be compressed on CDN when requested content is smaller than 1 byte or larger than 1 MB.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsHttpAllowed
Indicates whether HTTP traffic is allowed on the endpoint.
Default value is true.
At least one protocol (HTTP or HTTPS) must be allowed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsHttpsAllowed
Indicates whether HTTPS traffic is allowed on the endpoint.
Default value is true.
At least one protocol (HTTP or HTTPS) must be allowed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityProfile, UpdateViaIdentityProfileExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: EndpointName

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

### -OptimizationType
Specifies what scenario the customer wants this CDN endpoint to optimize for, e.g.
Download, Media services.
With this information, CDN can apply scenario driven optimization.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginHostHeader
The host header value sent to the origin with each request.
This property at Endpoint is only allowed when endpoint uses single origin and can be overridden by the same property specified at origin.If you leave this blank, the request hostname determines this value.
Azure CDN origins, such as Web Apps, Blob Storage, and Cloud Services require this host header value to match the origin hostname by default.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginPath
A directory path on the origin that CDN can use to retrieve content from, e.g.
contoso.cloudapp.net/originpath.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbePath
Path to a file hosted on the origin which helps accelerate delivery of the dynamic content and calculate the most optimal routes for the CDN.
This is relative to the origin path.
This property is only relevant when using a single origin.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityProfile, UpdateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryStringCachingBehavior
Defines how CDN caches requests that include query strings.
You can ignore any query strings when caching, bypass caching to prevent requests that contain query strings from being cached, or cache every request with a unique URL.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Endpoint tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UrlSigningKey
List of keys used to validate the signed URL hashes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningKey[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApplicationFirewallPolicyLinkId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProfileExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEndpointUpdateParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEndpoint

## NOTES

## RELATED LINKS

