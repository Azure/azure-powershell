---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorrulesengineactionobject
schema: 2.0.0
---

# New-AzFrontDoorRulesEngineActionObject

## SYNOPSIS
Create an in-memory object for RulesEngineAction.

## SYNTAX

### ByFieldsWithForwardingParameterSet (Default)
```
New-AzFrontDoorRulesEngineActionObject [-BackendPoolName <String>] [-CacheDuration <TimeSpan>]
 [-CustomForwardingPath <String>] [-DynamicCompression <String>] [-EnableCaching <Boolean>]
 [-ForwardingProtocol <String>] [-FrontDoorName <String>] [-QueryParameter <String>]
 [-QueryParameterStripDirective <String>] [-RequestHeaderAction <IHeaderAction[]>]
 [-ResourceGroupName <String>] [-ResponseHeaderAction <IHeaderAction[]>]
 [-RouteConfigurationOverride <IRouteConfiguration>] [<CommonParameters>]
```

### ByFieldsWithRedirectParameterSet
```
New-AzFrontDoorRulesEngineActionObject [-CustomFragment <String>] [-CustomHost <String>]
 [-CustomPath <String>] [-CustomQueryString <String>] [-RedirectProtocol <String>] [-RedirectType <String>]
 [-RequestHeaderAction <IHeaderAction[]>] [-ResponseHeaderAction <IHeaderAction[]>]
 [-RouteConfigurationOverride <IRouteConfiguration>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RulesEngineAction.

## EXAMPLES

### Example 1: Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.
```powershell
$headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
```

Create a rules engine action that append response header value and show how to view the properties of the rules engine action created.

### Example 2: Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RequestHeaderAction $headerActions -ForwardingProtocol HttpsOnly -BackendPoolName mybackendpool -ResourceGroupName Jessicl-Test-RG -FrontDoorName jessicl-test-myappfrontend -QueryParameterStripDirective StripNone -DynamicCompression Disabled -EnableCaching $true
```

Create a rules engine action that forwards the requests to a specific backend pool and show how to view the properties of the rules engine action created.

### Example 3: Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.
```powershell
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -RedirectType Moved -RedirectProtocol MatchRequest -CustomHost www.contoso.com
```

Create a rules engine action that redirects the requests to another host and show how to view the properties of the rules engine action created.

## PARAMETERS

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
Parameter Sets: ByFieldsWithForwardingParameterSet
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

### -RequestHeaderAction
A list of header actions to apply from the request from AFD to the origin.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name that the RoutingRule will be created in.

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

### -ResponseHeaderAction
A list of header actions to apply from the response from AFD to the client.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteConfigurationOverride
Override the route configuration.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineAction

## NOTES

## RELATED LINKS

