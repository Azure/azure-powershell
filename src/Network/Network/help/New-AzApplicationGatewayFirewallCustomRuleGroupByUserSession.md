---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallcustomrulegroupbyusersession
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession

## SYNOPSIS
Creates a new GroupByUserSession for the application gateway firewall custom rule.

## SYNTAX

```
New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession
 -GroupByVariable <PSApplicationGatewayFirewallCustomRuleGroupByVariable[]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession** creates a new GroupByUserSession for the application gateway firewall custom rule.

## EXAMPLES

### Example 1
```powershell
New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession -GroupByVariable $groupbyVar
```

The command creates a new GroupByUserSession, with the GroupByVariables condition named groupbyVar

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByVariable
Define user session group by clause variables.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRuleGroupByVariable[]
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCustomRule

## NOTES

## RELATED LINKS
