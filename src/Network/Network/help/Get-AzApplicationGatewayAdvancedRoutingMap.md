---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azapplicationgatewayadvancedroutingmap
schema: 2.0.0
---

# Get-AzApplicationGatewayAdvancedRoutingMap

## SYNOPSIS
Gets an advanced routing map from an application gateway.

## SYNTAX

```
Get-AzApplicationGatewayAdvancedRoutingMap [-Name <String>] -ApplicationGateway <PSApplicationGateway>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzApplicationGatewayAdvancedRoutingMap** cmdlet gets an advanced routing map from an application gateway. If **Name** is not specified, all advanced routing maps on the gateway are returned.

## EXAMPLES

### Example 1: Get a named advanced routing map
```powershell
$gateway = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$map = Get-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway $gateway -Name "Map01"
```

This command gets the advanced routing map named Map01 from the application gateway.

### Example 2: Get all advanced routing maps
```powershell
$gateway = Get-AzApplicationGateway -Name "ApplicationGateway01" -ResourceGroupName "ResourceGroup01"
$maps = Get-AzApplicationGatewayAdvancedRoutingMap -ApplicationGateway $gateway
```

This command gets every advanced routing map defined on the application gateway.

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
The name of the application gateway AdvancedRoutingMap

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

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayAdvancedRoutingMap

## NOTES

## RELATED LINKS
