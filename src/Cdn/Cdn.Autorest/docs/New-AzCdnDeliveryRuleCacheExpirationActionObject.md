---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.Cdn/new-AzCdnDeliveryRuleCacheExpirationActionObject
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.DeliveryRuleCacheExpirationAction

## NOTES

ALIASES

## RELATED LINKS

