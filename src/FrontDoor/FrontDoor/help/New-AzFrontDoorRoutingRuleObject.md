---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorroutingruleobject
schema: 2.0.0
---

# New-AzFrontDoorRoutingRuleObject

## SYNOPSIS
Create an in-memory object for RoutingRule.

## SYNTAX

### ByFieldsWithForwardingParameterSet (Default)
```
New-AzFrontDoorRoutingRuleObject [-AcceptedProtocol <String[]>] [-EnabledState <String>]
 [-FrontendEndpointName <String[]>] [-Name <String>] [-ResourceGroupName <String>] [-FrontDoorName <String>]
 [-PatternsToMatch <String[]>] [-RouteConfiguration <IRouteConfiguration>] [-RuleEngineName <String>]
 [-WebApplicationFirewallPolicyLinkId <String>] [-Id <String>] [-BackendPoolName <String>]
 [-CacheDuration <TimeSpan>] [-DynamicCompression <String>] [-QueryParameter <String>]
 [-QueryParameterStripDirective <String>] [-CustomForwardingPath <String>] [-ForwardingProtocol <String>]
 [-EnableCaching <Boolean>] [<CommonParameters>]
```

### ByFieldsWithRedirectParameterSet
```
New-AzFrontDoorRoutingRuleObject [-AcceptedProtocol <String[]>] [-EnabledState <String>]
 [-FrontendEndpointName <String[]>] [-Name <String>] [-ResourceGroupName <String>] [-FrontDoorName <String>]
 [-PatternsToMatch <String[]>] [-RouteConfiguration <IRouteConfiguration>] [-RuleEngineName <String>]
 [-WebApplicationFirewallPolicyLinkId <String>] [-Id <String>] [-CustomFragment <String>]
 [-CustomHost <String>] [-CustomPath <String>] [-CustomQueryString <String>] [-RedirectProtocol <String>]
 [-RedirectType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RoutingRule.

## EXAMPLES

### Example 1: Create a PSRoutingRuleObject for Front Door creation with a forwarding rule
```powershell
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
```

```output
AcceptedProtocol                   : {Http, Https}
EnabledState                       : Enabled
FrontendEndpoint                   : {{
                                       "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/FrontendEndpoints/frontendEndpoint1"
                                     }}
Id                                 :
Name                               :
PatternsToMatch                    : {/*}
ResourceState                      :
RouteConfiguration                 : {
                                       "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration",
                                       "backendPool": {
                                         "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/BackendPools/backendPool1"
                                       },
                                       "forwardingProtocol": "MatchRequest"
                                     }
RuleEngineId                       :
Type                               :
WebApplicationFirewallPolicyLinkId :
```

Create a PSRoutingRuleObject for Front Door creation with a forwarding rule

### Example 2: Create a PSRoutingRuleObject for Front Door creation with a redirect rule
```powershell
$customHost = "www.contoso.com"
$customPath = "/images/contoso.png"
$queryString = "field1=value1&field2=value2"
$destinationFragment = "section-header-2"
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -CustomHost $customHost -CustomPath $customPath -CustomQueryString $queryString -CustomFragment $destinationFragment
```

```output
AcceptedProtocol                   : {Http, Https}
EnabledState                       : Enabled
FrontendEndpoint                   : {{
                                       "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/FrontendEndpoints/frontendEndpoint1"
                                     }}
Id                                 :
Name                               :
PatternsToMatch                    : {/*}
ResourceState                      :
RouteConfiguration                 : {
                                       "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorRedirectConfiguration",
                                       "redirectType": "Moved",
                                       "redirectProtocol": "MatchRequest",
                                       "customHost": "www.contoso.com",
                                       "customPath": "/images/contoso.png",
                                       "customFragment": "section-header-2",
                                       "customQueryString": "field1=value1\u0026field2=value2"
                                     }
RuleEngineId                       :
Type                               :
WebApplicationFirewallPolicyLinkId :
```

Create a PSRoutingRuleObject for Front Door creation

## PARAMETERS

### -AcceptedProtocol
Protocol schemes to match for this rule.

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

### -BackendPoolName
Resource ID.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CacheDuration
The duration for which the content needs to be cached.
Allowed format is in ISO 8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).
HTTP requires the value to be no more than a year.

```yaml
Type: System.TimeSpan
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomForwardingPath
A custom path used to rewrite resource paths matched by this rule.
Leave empty to use incoming path.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomFragment
Fragment to add to the redirect URL.
Fragment is the part of the URL that comes after #.
Do not include the #.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHost
Host to redirect.
Leave empty to use the incoming host as the destination host.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomPath
The full path to redirect.
Path cannot be empty and must start with /.
Leave empty to use the incoming path as destination path.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomQueryString
The set of query strings to be placed in the redirect URL.
Setting this value would replace any existing query string; leave empty to preserve the incoming query string.
Query string must be in \<key\>=\<value\> format.
The first ? and & will be added automatically so do not include them in the front, but do separate multiple query strings with &.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicCompression
Whether to use dynamic compression for cached content.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableCaching

```yaml
Type: System.Boolean
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledState
Whether to enable use of this rule.
Permitted values are 'Enabled' or 'Disabled'.

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

### -ForwardingProtocol
Protocol this rule will use when forwarding traffic to backends.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontDoorName
The name of the Front Door to which this routing rule belongs.

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

### -FrontendEndpointName
Frontend endpoints associated with this rule.

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

### -Id
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

### -Name
Resource name.

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
Aliases: PatternToMatch

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryParameter
query parameters to include or exclude (comma separated).

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryParameterStripDirective
Treatment of URL query terms when forming the cache key.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithForwardingParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectProtocol
The protocol of the destination to where the traffic is redirected.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectType
The redirect type the rule will use when redirecting traffic.

```yaml
Type: System.String
Parameter Sets: ByFieldsWithRedirectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name.

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

### -RouteConfiguration

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRouteConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleEngineName
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RulesEngineName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RoutingRule

## NOTES

## RELATED LINKS
