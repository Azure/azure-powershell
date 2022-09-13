---
external help file:
Module Name: Az.Subscription
online version: https://docs.microsoft.com/powershell/module/az.Subscription/new-AzSubscriptionPutTenantPolicyRequestPropertiesObject
schema: 2.0.0
---

# New-AzSubscriptionPutTenantPolicyRequestPropertiesObject

## SYNOPSIS
Create an in-memory object for PutTenantPolicyRequestProperties.

## SYNTAX

```
New-AzSubscriptionPutTenantPolicyRequestPropertiesObject [-BlockSubscriptionsIntoTenant <Boolean>]
 [-BlockSubscriptionsLeavingTenant <Boolean>] [-ExemptedPrincipal <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PutTenantPolicyRequestProperties.

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

### -BlockSubscriptionsIntoTenant
Blocks the entering of subscriptions into user's tenant.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlockSubscriptionsLeavingTenant
Blocks the leaving of subscriptions from user's tenant.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExemptedPrincipal
List of user objectIds that are exempted from the set subscription tenant policies for the user's tenant.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.PutTenantPolicyRequestProperties

## NOTES

ALIASES

## RELATED LINKS

