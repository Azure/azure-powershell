---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubipruleconfig
schema: 2.0.0
---

# New-AzEventHubIPRuleConfig

## SYNOPSIS
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

## SYNTAX

```
New-AzEventHubIPRuleConfig -IPMask <String> [-Action <NetworkRuleIPAction>] [<CommonParameters>]
```

## DESCRIPTION
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

## EXAMPLES

### Example 1: Constructs an INwRuleSetIPRules object 
```powershell
New-AzEventHubIPRuleConfig -IPMask 3.3.3.3 -Action Allow
```

```output
Action IPMask
------ ------
Allow  1.1.1.1
```

Please refer examples for Set-AzEventHubNetworkRuleSet to know more.

## PARAMETERS

### -Action
The IP Filter Action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.NetworkRuleIPAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPMask
IP Mask

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.INwRuleSetIPRules

## NOTES

ALIASES

## RELATED LINKS

