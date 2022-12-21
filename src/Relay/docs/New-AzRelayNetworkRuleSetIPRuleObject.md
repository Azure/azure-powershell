---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.Relay/new-AzRelayNetworkRuleSetIPRuleObject
schema: 2.0.0
---

# New-AzRelayNetworkRuleSetIPRuleObject

## SYNOPSIS
Create an in-memory object for NwRuleSetIPRules.

## SYNTAX

```
New-AzRelayNetworkRuleSetIPRuleObject [-Action <NetworkRuleIPAction>] [-IPMask <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NwRuleSetIPRules.

## EXAMPLES

### Example 1: Create an in-memory object for NwRuleSetIPRules
```powershell
$rules = @()
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
```

This cmdlet creates an in-memory object for NwRuleSetIPRules as the value of the `IPRule` parameter in `New-AzRelayNamespaceNetworkRuleSet`.

## PARAMETERS

### -Action
The IP Filter Action.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.NetworkRuleIPAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPMask
IP Mask.

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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.NwRuleSetIPRules

## NOTES

ALIASES

## RELATED LINKS

