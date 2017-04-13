---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 0F141A92-4994-45B3-AE94-09865BC691C4
online version: 
schema: 2.0.0
---

# New-AzureRmVirtualNetworkGatewayConnection

## SYNOPSIS
Creates a Virtual Network Gateway Connection

## SYNTAX

### SetByResource (Default)
```
New-AzureRmVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -Location <String>
 [-AuthorizationKey <String>] -VirtualNetworkGateway1 <PSVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <PSVirtualNetworkGateway>] [-LocalNetworkGateway2 <PSLocalNetworkGateway>]
 -ConnectionType <String> [-RoutingWeight <Int32>] [-SharedKey <String>] [-Peer <PSPeering>]
 [-EnableBgp <String>] [-Tag <Hashtable>] [-Force] [-UsePolicyBasedTrafficSelectors]
 [-IpsecPolicies <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy]>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceId
```
New-AzureRmVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -Location <String>
 [-AuthorizationKey <String>] -VirtualNetworkGateway1 <PSVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <PSVirtualNetworkGateway>] [-LocalNetworkGateway2 <PSLocalNetworkGateway>]
 -ConnectionType <String> [-RoutingWeight <Int32>] [-SharedKey <String>] [-PeerId <String>]
 [-EnableBgp <String>] [-Tag <Hashtable>] [-Force] [-UsePolicyBasedTrafficSelectors]
 [-IpsecPolicies <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy]>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Virtual Network Gateway Connection is the object representing the IPsec tunnel (Site-to-Site or Vnet-to-Vnet) connected to your Virtual Network Gateway in Azure.

The **New-AzureRmVirtualNetworkGatewayConnection** cmdlet creates the object of your connection based on Name, Resource Group Name, and Location of the connection as well as the objects of the two gateways this connection will be connecting. Also included are the Connection Type and Shared Key.

## EXAMPLES

### 1: Create a Site-to-Site Virtual Network Gateway Connection
```
New-AzureRmVirtualNetworkGatewayConnection -Name "localToVpn" -ResourceGroupName "myRG" -Location "West US" -VirtualNetworkGateway1 $gw -LocalNetworkGateway2 $local -ConnectionType IPsec -SharedKey "abc123"
```
Creates the object of the Virtual Network Gateway Connection with the name "localToVpn" within the resource group "myRG" in location "West US" belonging to the virtual network gateway in the variable "gw" and connecting to the local network gateway in the variable "local." The connection type is "IPsec" because this is a Site-to-Site connection, and the shared key should be more complex than "abc123" but should match what is definied in the local gateway.

### 2: Create a Vnet-to-Vnet Virtual Network Gateway Connection
```
New-AzureRmVirtualNetworkGatewayConnection -Name "connectionAB" -ResourceGroupName "myRG" -Location "West US" -VirtualNetworkGateway1 $gwA -VirtualNetworkGateway2 $gwB -ConnectionType Vnet2Vnet -SharedKey "abc123"

New-AzureRmVirtualNetworkGatewayConnection -Name "connectionBA" -ResourceGroupName "myRG" -Location "West US" -VirtualNetworkGateway1 $gwB -VirtualNetworkGateway2 $gwA -ConnectionType Vnet2Vnet -SharedKey "abc123"
```
Creates the object of the Virtual Network Gateway Connection with the name "connectionAB" within the resource group "myRG" in location "West US" belonging to the virtual network gateway in the variable "gwA" and connecting to the virtual network gateway in the variable "gwB."
The connection type is "Vnet2Vnet" because this is a Vnet-to-Vnet connection, and the shared key should be more complex than "abc123" but should match what is definied in the both connections.

Since the Connection object belongs to the first Virtual Network Gateway (gwA, here), another Virutal Network Gateway Connection must be created beloning to the second Gateway (gwB, here) and attaching to the first Gateway (gwA). This is show in the second command, where the connection is named "connectionBA."

## PARAMETERS

### -AuthorizationKey
```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ConnectionType
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

### -EnableBgp
```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
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

### -IpsecPolicies
A list of IPSec policies.```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LocalNetworkGateway2
```yaml
Type: PSLocalNetworkGateway
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
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

### -Name
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

### -Peer
```yaml
Type: PSPeering
Parameter Sets: SetByResource
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeerId
```yaml
Type: String
Parameter Sets: SetByResourceId
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
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

### -RoutingWeight
```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SharedKey
```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UsePolicyBasedTrafficSelectors
Whether to enable policy-based traffic selectors for a S2S connection```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGateway1
```yaml
Type: PSVirtualNetworkGateway
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGateway2
```yaml
Type: PSVirtualNetworkGateway
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmVirtualNetworkGatewayConnection](./Get-AzureRmVirtualNetworkGatewayConnection.md)

[Remove-AzureRmVirtualNetworkGatewayConnection](./Remove-AzureRmVirtualNetworkGatewayConnection.md)

[Set-AzureRmVirtualNetworkGatewayConnection](./Set-AzureRmVirtualNetworkGatewayConnection.md)


