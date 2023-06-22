---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azcdnendpoint
schema: 2.0.0
---

# Update-AzCdnEndpoint

## SYNOPSIS
Updates an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update custom domains, use the Update Custom Domain operation.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <OptimizationType>]
 [-OriginHostHeader <String>] [-OriginPath <String>] [-ProbePath <String>]
 [-QueryStringCachingBehavior <QueryStringCachingBehavior>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzCdnEndpoint -InputObject <ICdnIdentity> [-ContentTypesToCompress <String[]>]
 [-DefaultOriginGroupId <String>] [-DeliveryPolicyDescription <String>]
 [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>] [-IsCompressionEnabled] [-IsHttpAllowed]
 [-IsHttpsAllowed] [-OptimizationType <OptimizationType>] [-OriginHostHeader <String>] [-OriginPath <String>]
 [-ProbePath <String>] [-QueryStringCachingBehavior <QueryStringCachingBehavior>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update custom domains, use the Update Custom Domain operation.

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryPolicyRule
A list of the delivery rules.
To construct, see NOTES section for DELIVERYPOLICYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoFilter
List of rules defining the user's geo access within a CDN endpoint.
Each geo filter defines an access rule to a specified path or content, e.g.
block APAC for path /pictures/
To construct, see NOTES section for GEOFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IGeoFilter[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded1
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.OptimizationType
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.QueryStringCachingBehavior
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UrlSigningKey
List of keys used to validate the signed URL hashes.
To construct, see NOTES section for URLSIGNINGKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IUrlSigningKey[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IEndpoint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DELIVERYPOLICYRULE <IDeliveryRule[]>`: A list of the delivery rules.
  - `Action <IDeliveryRuleAction1[]>`: A list of actions that are executed when all the conditions of a rule are satisfied.
    - `Name <DeliveryRuleAction>`: The name of the action for the delivery rule.
  - `Order <Int32>`: The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition and actions listed in it will always be applied.
  - `[Condition <IDeliveryRuleCondition[]>]`: A list of conditions that must be matched for the actions to be executed
    - `Name <MatchVariable>`: The name of the condition for the delivery rule.
  - `[Name <String>]`: Name of the rule

`GEOFILTER <IGeoFilter[]>`: List of rules defining the user's geo access within a CDN endpoint. Each geo filter defines an access rule to a specified path or content, e.g. block APAC for path /pictures/
  - `Action <GeoFilterActions>`: Action of the geo filter, i.e. allow or block access.
  - `CountryCode <String[]>`: Two letter country or region codes defining user country or region access in a geo filter, e.g. AU, MX, US.
  - `RelativePath <String>`: Relative path applicable to geo filter. (e.g. '/mypictures', '/mypicture/kitty.jpg', and etc.)

`INPUTOBJECT <ICdnIdentity>`: Identity Parameter
  - `[CustomDomainName <String>]`: Name of the domain under the profile which is unique globally.
  - `[EndpointName <String>]`: Name of the endpoint under the profile which is unique globally.
  - `[Id <String>]`: Resource identity path
  - `[OriginGroupName <String>]`: Name of the origin group which is unique within the endpoint.
  - `[OriginName <String>]`: Name of the origin which is unique within the profile.
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

`URLSIGNINGKEY <IUrlSigningKey[]>`: List of keys used to validate the signed URL hashes.
  - `KeyId <String>`: Defines the customer defined key Id. This id will exist in the incoming request to indicate the key used to form the hash.
  - `KeySourceParameterResourceGroupName <String>`: Resource group of the user's Key Vault containing the secret
  - `KeySourceParameterSecretName <String>`: The name of secret in Key Vault.
  - `KeySourceParameterSecretVersion <String>`: The version(GUID) of secret in Key Vault.
  - `KeySourceParameterSubscriptionId <String>`: Subscription Id of the user's Key Vault containing the secret
  - `KeySourceParameterVaultName <String>`: The name of the user's Key Vault containing the secret

## RELATED LINKS

