---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 06DAD751-3A43-4EF6-94C5-AA7AC1A67FC8
online version: 
schema: 2.0.0
---

# Set-AzureRmVirtualNetworkPeering

## SYNOPSIS
Configures a virtual network peering.

## SYNTAX

```
Set-AzureRmVirtualNetworkPeering -VirtualNetworkPeering <PSVirtualNetworkPeering> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmVirtualNetworkPeering** cmdlet configures a virtual network peering.

## EXAMPLES

### Example 1: Change forwarded traffic configuration of a virtual network peering
```
PS C:\>$LinkToVNet2 = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName "VirtualNetwork17" -ResourceGroupName "ResourceGroup001" -Name "LinkToVNet2"
PS C:\> $LinkToVNet2.AllowForwardedTraffic = $True
PS C:\> Set-AzureRmVirtualNetworkPeering -VirtualNetworkPeering $LinkToVNet2
```

This example changes the forwarded traffic configuration to $True from the default value $False on a previously established VNet peering link.

The first command gets the link named LinkToVNet2 in ResourceGroup001 in the virtual network named VirtualNetwork17 by using the Get-AzureRmVirtualNetworkPeering cmdlet.
The command stores the result in the $LinkToVNet2 variable.

The second command changes the **AllowForwardedTraffic** property to $True.

The final command updates the settings for the LinkToVNet2 virtual network peering to the value in $LinkToVNet2.

### Example 2: Change virtual network access of a virtual network peering
```
PS C:\>$LinkToVNet2 = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName "VirtualNetwork17" -ResourceGroupName "ResourceGroup001" -Name "LinkToVNet2"
PS C:\> $LinkToVNet2.AllowVirtualNetworkAccess = $False
PS C:\> Set-AzureRmVirtualNetworkPeering -VirtualNetworkPeering $LinkToVNet2
```

This example changes the virtual network access property configuration to $False from the default value $True on a previously established VNet peering link.

The first command gets the link named LinkToVNet2 in ResourceGroup001 in the virtual network named VirtualNetwork17 by using **Get-AzureRmVirtualNetworkPeering**.
The command stores the result in the $LinkToVNet2 variable.

The second command changes the **AllowVirtualNetworkAccess** property to $False.

The final command updates the settings for the LinkToVNet2 virtual network peering to the value in $LinkToVNet2.

### Example 3: Change gateway transit property configuration of a virtual network peering
```
PS C:\>$LinkToVNet2 = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName "VirtualNetwork17" -ResourceGroupName "001ResourceGroup" -Name "LinkToVNet2"
PS C:\> $LinkToVNet2.AllowGatewayTransit = $True
PS C:\> Set-AzureRmVirtualNetworkPeering -VirtualNetworkPeering $LinkToVNet2
```

This changes the gateway transit property configuration to $True from the default value $False on a previously established VNet peering link.

The first command gets the link named LinkToVNet2 in ResourceGroup001 in the virtual network named VirtualNetwork17 by using **Get-AzureRmVirtualNetworkPeering**.
The command stores the result in the $LinkToVNet2 variable.

The second command changes the **AllowGatewayTransit** property to $True.

The final command updates the settings for the LinkToVNet2 virtual network peering to the value in $LinkToVNet2.

### Example 4: Use remote gateways in virtual network peering
```
PS C:\>$LinkToVNet2 = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName "VirtualNetwork17" -ResourceGroupName "ResourceGroup001" -Name "LinkToVNet2"
PS C:\> $LinkToVNet2.UseRemoteGateways = $True
PS C:\> Set-AzureRmVirtualNetworkPeering -VirtualNetworkPeering $LinkToVNet2
```

This changes the remote gateway configuration to $True from the default value $False on a previously established VNet peering link.

The first command gets the link named LinkToVNet2 in ResourceGroup001 in the virtual network named VirtualNetwork17 by using **Get-AzureRmVirtualNetworkPeering**.
The command stores the result in the $LinkToVNet2 variable.

The second command changes the **UseRemoteGateways** property to $True.

The final command updates the settings for the LinkToVNet2 virtual network peering to the value in $LinkToVNet2.

By changing this property to $True, your peer's VNet gateway can be used.
However, the peer VNet must have a gateway configured and **AllowGatewayTransit** must have a value of $True.

This property cannot be used if a gateway has already been configured.

## PARAMETERS

### -VirtualNetworkPeering
Specifies the virtual network peering.

```yaml
Type: PSVirtualNetworkPeering
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

### PSVirtualNetworkPeering
Parameter 'VirtualNetworkPeering' accepts value of type 'PSVirtualNetworkPeering' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkPeering

## NOTES

## RELATED LINKS

[Add-AzureRmVirtualNetworkPeering](./Add-AzureRmVirtualNetworkPeering.md)

[Get-AzureRmVirtualNetworkPeering](./Get-AzureRmVirtualNetworkPeering.md)

[Remove-AzureRmVirtualNetworkPeering](./Remove-AzureRmVirtualNetworkPeering.md)


