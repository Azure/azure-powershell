---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azapplicationgatewayroutingrule
schema: 2.0.0
---

# Get-AzApplicationGatewayRoutingRule

## SYNOPSIS
Gets the routing rule of an application gateway.

## SYNTAX

```
Get-AzApplicationGatewayRoutingRule [-Name <String>] -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayRoutingRule** cmdlet gets the routing rule of an application gateway.

## EXAMPLES

### Example 1: Get a specific routing rule
```powershell
$AppGW = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$Rule = Get-AzApplicationGatewayRoutingRule -Name "Rule01" -ApplicationGateway $AppGW
```

The first command gets the Application Gateway named ApplicationGateway01 and stores the result in the variable named $AppGW.
The second command gets the routing rule named Rule01 from the Application Gateway stored in the variable named $AppGW.

### Example 2: Get a list of routing rules
```powershell
$AppGW = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$Rules = Get-AzApplicationGatewayRoutingRule -ApplicationGateway $AppGW
```

The first command gets the Application Gateway named ApplicationGateway01 and stores the result in the variable named $AppGW.
The second command gets a list of routing rules from the Application Gateway stored in the variable named $AppGW.

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

Required: False
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayRoutingRule

## NOTES

## RELATED LINKS

[Add-AzApplicationGatewayRoutingRule](./Add-AzApplicationGatewayRoutingRule.md)

[New-AzApplicationGatewayRoutingRule](./New-AzApplicationGatewayRoutingRule.md)

[Remove-AzApplicationGatewayRoutingRule](./Remove-AzApplicationGatewayRoutingRule.md)

[Set-AzApplicationGatewayRoutingRule](./Set-AzApplicationGatewayRoutingRule.md)