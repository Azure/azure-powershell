---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: DE2441FC-9504-4F3F-AEAF-37EDCD9B7275
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/resize-azurermvirtualnetworkgateway
schema: 2.0.0
---

# Resize-AzureRmVirtualNetworkGateway

## SYNOPSIS
Resizes an existing virtual network gateway.

## SYNTAX

```
Resize-AzureRmVirtualNetworkGateway -VirtualNetworkGateway <PSVirtualNetworkGateway> -GatewaySku <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Resize-AzureRmVirtualNetworkGateway** cmdlet enables you to change the stock-keeping unit (SKU) for a virtual network gateway.
SKUs determine the capabilities of a gateway, including such things as throughput and the maximum number of IP tunnels that are allowed.
Azure supports Basic, Standard, High-Performance, VpnGw1, VpnGw2 and VpnGw3 SKUs (sometimes referred to as Small, Medium, and Large SKUs).
For detailed information about the capabilities of each SKU type, see https://azure.microsoft.com/en-us/documentation/articles/vpn-gateway-about-vpngateways/.

Keep in mind that SKUs differ in pricing as well as capabilities.
For more information, see https://azure.microsoft.com/en-us/pricing/details/vpn-gateway/.

## EXAMPLES

### Example 1: Change the size of a virtual network gateway
```
PS C:\>$Gateway = Get-AzureRmVirtualNetworkGateway -Name "ContosoVirtualGateway"
PS C:\> Resize-AzureRmVirtualNetworkGateway -VirtualNetworkGateway $Gateway -GatewaySku "Basic"
```

This example changes the size of a virtual network gateway named ContosoVirtualGateway.

The first command creates an object reference to ContosoVirtualGateway; this object reference is stored in a variable named $Gateway.

The second command then uses the **Resize-AzureRmVirtualNetworkGateway** cmdlet to set the *GatewaySku* property to Basic.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GatewaySku
Specifies the new type of gateway SKU.
The acceptable values for this parameter are:

- Basic
- Standard
- High Performance
- VpnGw1
- VpnGw2
- VpnGw3

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: Basic, Standard, HighPerformance, UltraPerformance, VpnGw1, VpnGw2, VpnGw3

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGateway
Specifies an object reference to the virtual network gateway to be resized.
You can create this object reference by using the Get-AzureRmVirtualNetworkGateway and specifying the name of the gateway.

```yaml
Type: PSVirtualNetworkGateway
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

###  
This cmdlet accepts pipelined instances of the **Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway** object.

## OUTPUTS

###  
This cmdlet modifies existing instances of the **Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway** object.

## NOTES
You cannot resize from Basic/Standard/HighPerformance SKUs to the new VpnGw1/VpnGw2/VpnGw3 SKUs. See https://docs.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-about-vpngateways for instructions.

## RELATED LINKS

[Get-AzureRmVpnClientPackage](./Get-AzureRmVpnClientPackage.md)

[Get-AzureRmVirtualNetworkGateway](./Get-AzureRmVirtualNetworkGateway.md)

[Set-AzureRmVirtualNetworkGatewayVpnClientConfig](./Set-AzureRmVirtualNetworkGatewayVpnClientConfig.md)


