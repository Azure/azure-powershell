---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 93D8A341-540A-43F1-8C62-28323EAA58E0
online version: 
schema: 2.0.0
---

# Set-AzureRmVirtualNetwork

## SYNOPSIS
Sets the goal state for a virtual network.

## SYNTAX

```
Set-AzureRmVirtualNetwork -VirtualNetwork <PSVirtualNetwork> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmVirtualNetwork** cmdlet sets the goal state for an Azure virtual network.

## EXAMPLES

### 1: Creates a virtual network and removes one of its subnets
```
New-AzureRmResourceGroup -Name TestResourceGroup -Location centralus
    $frontendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"

$backendSubnet = New-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet -AddressPrefix "10.0.2.0/24"

$virtualNetwork = New-AzureRmVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName 
    TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet

Remove-AzureRmVirtualNetworkSubnetConfig -Name backendSubnet -VirtualNetwork $virtualNetwork

$virtualNetwork | Set-AzureRmVirtualNetwork
```

This example creates a virtual network with two subnets. Then it removes one subnet from 
    the in-memory representation of the virtual network. The Set-AzureRmVirtualNetwork cmdlet 
    is then used to write the modified virtual network state on the service side.

## PARAMETERS

### -VirtualNetwork
Specifies a **VirtualNetwork** object that represents the goal state.

```yaml
Type: PSVirtualNetwork
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

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)

[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)

[New-AzureRmVirtualNetwork](./New-AzureRmVirtualNetwork.md)

[Remove-AzureRmVirtualNetwork](./Remove-AzureRmVirtualNetwork.md)


