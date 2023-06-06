---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction.

## SYNTAX

```
New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name <DeliveryRuleAction>
 [-CacheConfigurationCacheBehavior <RuleCacheBehavior>] [-CacheConfigurationCacheDuration <String>]
 [-CacheConfigurationIsCompressionEnabled <RuleIsCompressionEnabled>]
 [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <RuleQueryStringCachingBehavior>] [-OriginGroupId <String>]
 [-OriginGroupOverrideForwardingProtocol <ForwardingProtocol>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction.

## EXAMPLES

### Example 1: Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction
```powershell
$originGroupId = "xxxx"
New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name RouteConfigurationOverride -OriginGroupOverrideForwardingProtocol HttpOnly -OriginGroupId $originGroupId
```

```output
Name
----
RouteConfigurationOverride
```

Create an in-memory object for DeliveryRuleRouteConfigurationOverrideAction

## PARAMETERS

### -CacheConfigurationCacheBehavior
Caching behavior for the requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.RuleCacheBehavior
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CacheConfigurationCacheDuration
The duration for which the content needs to be cached.
Allowed format is [d.]hh:mm:ss.

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

### -CacheConfigurationIsCompressionEnabled
Indicates whether content compression is enabled.
If compression is enabled, content will be served as compressed if user requests for a compressed version.
Content won't be compressed on AzureFrontDoor when requested content is smaller than 1 byte or larger than 1 MB.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.RuleIsCompressionEnabled
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.RuleQueryStringCachingBehavior
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the action for the delivery rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeliveryRuleAction
Parameter Sets: (All)
Aliases:

Required: True
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

### -OriginGroupOverrideForwardingProtocol
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleRouteConfigurationOverrideAction

## NOTES

ALIASES

## RELATED LINKS

