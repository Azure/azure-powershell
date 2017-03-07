---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkGatewayAdvertisedRoute

## SYNOPSIS
Retrieves a list of routes a virtual network gateway is advertising to the specified peer

## SYNTAX

```
Get-AzureRmVirtualNetworkGatewayAdvertisedRoute -VirtualNetworkGatewayName <String> -ResourceGroupName <String>
 -Peer <String> [<CommonParameters>]
```

## DESCRIPTION
Enumerates routes being advertised to the peer with the specified IP. This command is only valid for virtual network gateways with BGP connections configured.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVirtualNetworkGatewayAdvertisedRoutes -ResourceGroupName "resourceGroup" -VirtualNetworkGatewayName "gatewayName" -Peer 10.1.0.254
```

Gets a list of routes being advertised to the peer with IP 10.1.0.254 by the Azure virtual network gateway named "gatewayName" in resource group "resourceGroup"

### Example 2
```
PS C:\> $bgpPeerStatus = Get-AzureRmVirtualNetworkGatewayBgpPeerStatus -ResourceGroupName "resourceGroup" -VirtualNetworkGatewayName "gatewayName"
PS C:\> Get-AzureRmVirtualNetworkGatewayAdvertisedRoutes -ResourceGroupName "resourceGroup" -VirtualNetworkGatewayName "gatewayName" -Peer $bgpPeerStatus[0].Neighbor
```

Gets a list of routes being advertised to the first peer returned for the Azure virtual network gateway named "gatewayName" in resource group "resourceGroup"

## PARAMETERS

### -Peer
BGP peer's IP address

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Virtual network gateway resource group's name

```yaml
Type: String
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
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayRoute

## NOTES
The specified peer IP should be the IP the Azure gateway is configured to establish a BGP session with. Because Azure gateways establish BGP sessions using their private IP in the virtual network, the peer IP should be a private IP reachable from the gateway's Azure virtual network. It should not be a VPN device's public IP. 

## RELATED LINKS

