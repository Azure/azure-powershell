---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorroutingruleobject
schema: 2.0.0
---

# New-AzFrontDoorRoutingRuleObject

## SYNOPSIS
Create an in-memory object for RoutingRule.

## SYNTAX

### ForwardingConfiguration (Default)
```
New-AzFrontDoorRoutingRuleObject [-AcceptedProtocol <String[]>] [-BackendPoolName <String>]
 [-CacheDuration <TimeSpan>] [-CustomForwardingPath <String>] [-CustomFragment <String>]
 [-CustomHost <String>] [-CustomPath <String>] [-CustomQueryString <String>] [-DynamicCompression <String>]
 [-EnabledState <String>] [-ForwardingProtocol <String>] [-FrontDoorName <String>]
 [-FrontendEndpointName <String[]>] [-Id <String>] [-Name <String>] [-PatternsToMatch <String[]>]
 [-QueryParameter <String>] [-QueryParameterStripDirective <String>] [-RedirectProtocol <String>]
 [-RedirectType <String>] [-ResourceGroupName <String>] [-RouteConfiguration <IRouteConfiguration>]
 [-RuleEngineName <String>] [-WebApplicationFirewallPolicyLinkId <String>] [<CommonParameters>]
```

### FieldsWithRedirectParameterSet
```
New-AzFrontDoorRoutingRuleObject [-AcceptedProtocol <String[]>] [-BackendPoolName <String>]
 [-CacheDuration <TimeSpan>] [-CustomForwardingPath <String>] [-CustomFragment <String>]
 [-CustomHost <String>] [-CustomPath <String>] [-CustomQueryString <String>] [-DynamicCompression <String>]
 [-EnabledState <String>] [-ForwardingProtocol <String>] [-FrontDoorName <String>]
 [-FrontendEndpointName <String[]>] [-Id <String>] [-Name <String>] [-PatternsToMatch <String[]>]
 [-QueryParameter <String>] [-QueryParameterStripDirective <String>] [-RedirectProtocol <String>]
 [-RedirectType <String>] [-ResourceGroupName <String>] [-RouteConfiguration <IRouteConfiguration>]
 [-RuleEngineName <String>] [-WebApplicationFirewallPolicyLinkId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RoutingRule.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Aliases:

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RoutingRule

## NOTES

## RELATED LINKS

