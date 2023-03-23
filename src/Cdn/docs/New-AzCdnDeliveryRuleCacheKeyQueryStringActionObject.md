---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnDeliveryRuleCacheKeyQueryStringActionObject
schema: 2.0.0
---

# New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject

## SYNOPSIS
Create an in-memory object for DeliveryRuleCacheKeyQueryStringAction.

## SYNTAX

```
New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject -Name <DeliveryRuleAction>
 -ParameterQueryStringBehavior <QueryStringBehavior> [-ParameterQueryParameter <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryRuleCacheKeyQueryStringAction.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN DeliveryRuleCacheKeyQueryStringAction
```powershell
New-AzCdnDeliveryRuleCacheKeyQueryStringActionObject -Name CacheKeyQueryString -ParameterQueryStringBehavior IncludeAll
```

```output
Name
----
CacheKeyQueryString
```

Create an in-memory object for AzureCDN DeliveryRuleCacheKeyQueryStringAction

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

### -ParameterQueryParameter
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

### -ParameterQueryStringBehavior
Caching behavior for the requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.QueryStringBehavior
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.DeliveryRuleCacheKeyQueryStringAction

## NOTES

ALIASES

## RELATED LINKS

