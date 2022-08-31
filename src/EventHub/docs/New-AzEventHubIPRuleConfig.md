---
external help file:
Module Name: Az.EventHub
online version: https://docs.microsoft.com/powershell/module/az.eventhub/new-azeventhubipruleconfig
schema: 2.0.0
---

# New-AzEventHubIPRuleConfig

## SYNOPSIS
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

## SYNTAX

```
New-AzEventHubIPRuleConfig -Action <NetworkRuleIPAction> -IPMask <String> [<CommonParameters>]
```

## DESCRIPTION
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzEventHubNetworkRuleSet

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

### -Action
The IP Filter Action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.NetworkRuleIPAction
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.INwRuleSetIPRules

## NOTES

ALIASES

## RELATED LINKS

