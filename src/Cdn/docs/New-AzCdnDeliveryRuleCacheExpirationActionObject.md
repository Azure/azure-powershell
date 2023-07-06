---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnDeliveryRuleCacheExpirationActionObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleCacheExpirationActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleCacheExpirationAction.

## SYNTAX

```
New-AzCdnDeliveryRuleCacheExpirationActionObject -Name <DeliveryRuleAction>
 -ParameterCacheBehavior <CacheBehavior> [-ParameterCacheDuration <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleCacheExpirationAction.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleCacheExpirationAction
```powershell
New-AzCdnDeliveryRuleCacheExpirationActionObject -Name CacheExpiration -ParameterCacheBehavior SetIfMissing -ParameterCacheDuration 0.01:30:00
```

```output
Name
----
CacheExpiration
```

Create an in-memory object for AzureCDN DeliveryRuleCacheExpirationAction

## PARAMETERS

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

### -ParameterCacheBehavior
Caching behavior for the requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.CacheBehavior
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterCacheDuration
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.DeliveryRuleCacheExpirationAction

## NOTES

ALIASES

## RELATED LINKS

