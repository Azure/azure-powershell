---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 13901193-8C68-4969-ADCD-2E82EA714354
online version: 
schema: 2.0.0
---

# Add-AzureRmVirtualNetworkPeering

## SYNOPSIS
Creates a peering between two virtual networks.

## SYNTAX

```
Add-AzureRmVirtualNetworkPeering -Name <String> -VirtualNetwork <PSVirtualNetwork>
 -RemoteVirtualNetworkId <String> [-BlockVirtualNetworkAccess] [-AllowForwardedTraffic] [-AllowGatewayTransit]
 [-UseRemoteGateways] [-InformationAction <ActionPreference>] [-InformationVariable <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmVirtualNetworkPeering** cmdlet creates a peering between two virtual networks.

## EXAMPLES

### Example 1: Create a peering between two virtual networks
```
PS C:\>$vnet1 = Get-AzureRmVirtualNetwork -ResourceGroupName "MyResourceGroup" -Name "vnet1"
PS C:\> $vnet2 = Get-AzureRmVirtualNetwork -ResourceGroupName "MyResourceGroup" -Name "vnet2"
PS C:\> Add-AzureRmVirtualNetworkPeering -Name "LinkToVNet2" -VirtualNetwork "MyVirtualNetwork" -RemoteVirtualNetworkId $vnet2.id
PS C:\> Add-AzureRmVirtualNetworkPeering -Name "LinkToVNet1" -VirtualNetwork "MyVirtualNetwork" -RemoteVirtualNetworkId $vnet1.id
```

The first command gets a virtual network object named vnet1, and then stores it in the $vnet1 variable.

The second command gets a virtual network object named vnet2, and then stores it in the $vnet2 variable.

The third command adds a virtual network peering link from vnet1 to vnet2.
This link is named LinkToVnet2.

The fourth command adds a link from vnet2 to vnet1 named LinkToVnet1.

Note that vnet1 and vnet2 are assumed to already exist in this example.
Also note that a link must be created from vnet1 to vnet2 and vice versa in order for peering to work.

## PARAMETERS

### -Name
Specifies the name of the virtual network peering.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetwork
Specifies the parent virtual network.

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

### -RemoteVirtualNetworkId
Specifies the ID of the remote virtual network.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BlockVirtualNetworkAccess
Indicates that this cmdlet blocks the virtual machines in the linked virtual network space to access all the virtual machines in local virtual network space.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowForwardedTraffic
Indicates that this cmdlet allows the forwarded traffic from the virtual machines in the remote virtual network.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowGatewayTransit
Flag to allow gatewayLinks be used in remote virtual network's link to this virtual network

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: AlloowGatewayTransit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseRemoteGateways
Indicates that this cmdlet allows remote gateways on this virtual network.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)

[Get-AzureRmVirtualNetworkPeering](./Get-AzureRmVirtualNetworkPeering.md)

[Remove-AzureRmVirtualNetworkPeering](./Remove-AzureRmVirtualNetworkPeering.md)

[Set-AzureRmVirtualNetworkPeering](./Set-AzureRmVirtualNetworkPeering.md)


