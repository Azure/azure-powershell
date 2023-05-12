---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnroute
schema: 2.0.0
---

# New-AzFrontDoorCdnRoute

## SYNOPSIS
Creates a new route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

## SYNTAX

```
New-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <AfdQueryStringCachingBehavior>]
 [-CompressionSettingContentTypesToCompress <String[]>] [-CompressionSettingIsCompressionEnabled]
 [-CustomDomain <IActivatedResourceReference[]>] [-EnabledState <EnabledState>]
 [-ForwardingProtocol <ForwardingProtocol>] [-HttpsRedirect <HttpsRedirect>]
 [-LinkToDefaultDomain <LinkToDefaultDomain>] [-OriginGroupId <String>] [-OriginPath <String>]
 [-PatternsToMatch <String[]>] [-RuleSet <IResourceReference[]>] [-SupportedProtocol <AfdEndpointProtocols[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

## EXAMPLES

### Example 1: Create an AzureFrontDoor route under the AzureFrontDoor profile
```powershell
$originGroup = Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
$ruleSet = Get-AzFrontDoorCdnRuleSet -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
$customdomain = Get-AzFrontDoorCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -CustomDomainName domain001

$ruleSetResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id
$customdomainResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $customdomain.Id

New-AzFrontDoorCdnRoute -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Name route001 -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResoure) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled" -CustomDomain @($customdomainResoure)
     
```

```output
Name     ResourceGroupName
----     -----------------
route001 testps-rg-da16jm
```

Create an AzureFrontDoor route under the AzureFrontDoor profile

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

### -CacheConfigurationQueryParameter
query parameters to include or exclude (comma separated).

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

### -CacheConfigurationQueryStringCachingBehavior
Defines how Frontdoor caches requests that include query strings.
You can ignore any query strings when caching, ignore specific query strings, cache every request with a unique URL, or cache specific query strings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdQueryStringCachingBehavior
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompressionSettingContentTypesToCompress
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

### -CompressionSettingIsCompressionEnabled
Indicates whether content compression is enabled on AzureFrontDoor.
Default value is false.
If compression is enabled, content will be served as compressed if user requests for a compressed version.
Content won't be compressed on AzureFrontDoor when requested content is smaller than 1 byte or larger than 1 MB.

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

### -CustomDomain
Domains referenced by this endpoint.
To construct, see NOTES section for CUSTOMDOMAIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IActivatedResourceReference[]
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

### -EnabledState
Whether to enable use of this rule.
Permitted values are 'Enabled' or 'Disabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointName
Name of the endpoint under the profile which is unique globally.

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

### -ForwardingProtocol
Protocol this rule will use when forwarding traffic to backends.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ForwardingProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsRedirect
Whether to automatically redirect HTTP traffic to HTTPS traffic.
Note that this is a easy way to set up this rule and it will be the first rule that gets executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HttpsRedirect
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkToDefaultDomain
whether this route will be linked to the default endpoint domain.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.LinkToDefaultDomain
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the routing rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RouteName

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

### -OriginGroupId
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

### -OriginPath
A directory path on the origin that AzureFrontDoor can use to retrieve content from, e.g.
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

### -PatternsToMatch
The route patterns of the rule.

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

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### -RuleSet
rule sets referenced by this endpoint.
To construct, see NOTES section for RULESET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

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

### -SupportedProtocol
List of supported protocols for this route.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdEndpointProtocols[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IRoute

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMDOMAIN <IActivatedResourceReference[]>`: Domains referenced by this endpoint.
  - `[Id <String>]`: Resource ID.

`RULESET <IResourceReference[]>`: rule sets referenced by this endpoint.
  - `[Id <String>]`: Resource ID.

## RELATED LINKS

