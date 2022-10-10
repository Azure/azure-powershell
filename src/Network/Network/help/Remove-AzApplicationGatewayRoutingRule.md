---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azapplicationgatewayroutingrule
schema: 2.0.0
---

# Remove-AzApplicationGatewayRoutingRule

## SYNOPSIS
Removes a routing rule from an application gateway.

## SYNTAX

```
Remove-AzApplicationGatewayRoutingRule -Name <String> -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzApplicationGatewayRoutingRule** cmdlet removes a routing rule from an Azure application gateway.

## EXAMPLES

### Example 1: Remove a routing rule from an application gateway
```powershell
$AppGw = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
Remove-AzApplicationGatewayRoutingRule -ApplicationGateway $AppGw -Name "Rule02"
Set-AzApplicationGateway -ApplicationGateway $AppGw
```

The first command gets an application gateway and stores it in the $AppGw variable.
The second command removes the routing rule named Rule02 from the application gateway stored in $AppGw.
The last command updates the application gateway.

## PARAMETERS

### -ApplicationGateway
The applicationGateway

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGateway
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -Name
The name of the routing rule

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGateway

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayRoutingRule](./Add-AzApplicationGatewayRoutingRule.md)

[Get-AzApplicationGatewayRoutingRule](./Get-AzApplicationGatewayRoutingRule.md)

[New-AzApplicationGatewayRoutingRule](./New-AzApplicationGatewayRoutingRule.md)

[Set-AzApplicationGatewayRoutingRule](./Set-AzApplicationGatewayRoutingRule.md)