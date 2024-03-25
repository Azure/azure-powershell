---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/new-azservicebusipruleconfig
schema: 2.0.0
---

# New-AzServiceBusIPRuleConfig

## SYNOPSIS
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzServiceBusNetworkRuleSet

## SYNTAX

```
New-AzServiceBusIPRuleConfig -IPMask <String> [-Action <NetworkRuleIPAction>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Constructs an INwRuleSetIPRules object that can be fed as input to Set-AzServiceBusNetworkRuleSet

## EXAMPLES

### Example 1: Constructs an INwRuleSetIPRules object
```powershell
New-AzServiceBusIPRuleConfig -IPMask 3.3.3.3 -Action Allow
```

```output
Action IPMask
------ ------
Allow  1.1.1.1
```

Please refer examples for Set-AzServiceBusNetworkRuleSet to know more.

## PARAMETERS

### -Action
The IP Filter Action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.NetworkRuleIPAction
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.INwRuleSetIPRules

## NOTES

## RELATED LINKS
