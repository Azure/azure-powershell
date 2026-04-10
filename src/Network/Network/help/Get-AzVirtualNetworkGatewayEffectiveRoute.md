---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkgatewayeffectiveroute
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayEffectiveRoute

## SYNOPSIS
Gets the effective routes of an Azure virtual network gateway.

## SYNTAX

```
Get-AzVirtualNetworkGatewayEffectiveRoute -VirtualNetworkGatewayName <String> -ResourceGroupName <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the effective routes configured on an Azure virtual network gateway. This includes routes for tunnels to remote gateways as well as routes for the local virtual network.

## EXAMPLES

### Example 1: Get effective routes for a virtual network gateway
```powershell
Get-AzVirtualNetworkGatewayEffectiveRoute -ResourceGroupName resourceGroup -VirtualNetworkGatewayName gatewayName
```

```output
LocalAddress   : 52.170.0.1
AddressPrefixes: {10.1.0.0/24}
NextHopIpAddress: 52.170.0.2
NextHopType    : Tunnel

LocalAddress   : 52.170.0.1
AddressPrefixes: {10.0.0.0/24}
NextHopIpAddress:
NextHopType    : VirtualNetwork
```

For the Azure virtual network gateway named gatewayName in resource group resourceGroup, retrieves the effective routes.
In this example, the gateway has a tunnel route to a remote gateway subnet (10.1.0.0/24) via a remote public IP, and a local virtual network route (10.0.0.0/24).

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -ResourceGroupName
Virtual network gateway resource group's name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
Virtual network gateway name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayEffectiveRoute

## NOTES

## RELATED LINKS

[Get-AzVirtualNetworkGatewayLearnedRoute](./Get-AzVirtualNetworkGatewayLearnedRoute.md)

[Get-AzVirtualNetworkGatewayAdvertisedRoute](./Get-AzVirtualNetworkGatewayAdvertisedRoute.md)

[Get-AzVirtualNetworkGatewayBGPPeerStatus](./Get-AzVirtualNetworkGatewayBGPPeerStatus.md)
