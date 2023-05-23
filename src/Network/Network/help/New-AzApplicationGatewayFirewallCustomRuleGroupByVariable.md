---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallcustomrulegroupbyvariable
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallCustomRuleGroupByVariable

## SYNOPSIS
Creates a new GroupByVariable for the application gateway firewall custom rule GroupByUserSession.

## SYNTAX

```
New-AzApplicationGatewayFirewallCustomRuleGroupByVariable -VariableName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallCustomRuleGroupByVariable** creates a new GroupByVariable for the application gateway firewall custom rule GroupByUserSession.

## EXAMPLES

### Example 1
```powershell
New-AzApplicationGatewayFirewallCustomRuleGroupByVariable -VariableName ClientAddr
```

The command creates a new GroupByVariable, with the VariableName ClientAddr

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

### -VariableName
User Session clause variable.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: ClientAddr, Geo, None

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
