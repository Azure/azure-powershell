---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 0F141A92-4994-45B3-AE94-09865BC691C4
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewayconnection
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayConnection

## SYNOPSIS
Creates the Site-to-Site VPN connection between the virtual network gateway and the on-prem VPN device.

## SYNTAX

### SetByResource (Default)
```
New-AzVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -Location <String>
 [-AuthorizationKey <String>] -VirtualNetworkGateway1 <PSVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <PSVirtualNetworkGateway>] [-LocalNetworkGateway2 <PSLocalNetworkGateway>]
 -ConnectionType <String> [-RoutingWeight <Int32>] [-DpdTimeoutInSeconds <Int32>] [-ConnectionMode <String>]
 [-SharedKey <String>] [-Peer <PSPeering>] [-EnableBgp <Boolean>] [-UseLocalAzureIpAddress] [-Tag <Hashtable>]
 [-Force] [-UsePolicyBasedTrafficSelectors <Boolean>] [-IpsecPolicies <PSIpsecPolicy[]>]
 [-TrafficSelectorPolicy <PSTrafficSelectorPolicy[]>] [-ConnectionProtocol <String>]
 [-IngressNatRule <PSResourceId[]>] [-EgressNatRule <PSResourceId[]>]
 [-GatewayCustomBgpIpAddress <PSGatewayCustomBgpIpConfiguration[]>] [-AsJob] [-ExpressRouteGatewayBypass]
 [-EnablePrivateLinkFastPath] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceId
```
New-AzVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -Location <String>
 [-AuthorizationKey <String>] -VirtualNetworkGateway1 <PSVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <PSVirtualNetworkGateway>] [-LocalNetworkGateway2 <PSLocalNetworkGateway>]
 -ConnectionType <String> [-RoutingWeight <Int32>] [-DpdTimeoutInSeconds <Int32>] [-ConnectionMode <String>]
 [-SharedKey <String>] [-PeerId <String>] [-EnableBgp <Boolean>] [-UseLocalAzureIpAddress] [-Tag <Hashtable>]
 [-Force] [-UsePolicyBasedTrafficSelectors <Boolean>] [-IpsecPolicies <PSIpsecPolicy[]>]
 [-TrafficSelectorPolicy <PSTrafficSelectorPolicy[]>] [-ConnectionProtocol <String>]
 [-IngressNatRule <PSResourceId[]>] [-EgressNatRule <PSResourceId[]>]
 [-GatewayCustomBgpIpAddress <PSGatewayCustomBgpIpConfiguration[]>] [-AsJob] [-ExpressRouteGatewayBypass]
 [-EnablePrivateLinkFastPath] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates the Site-to-Site VPN connection between the virtual network gateway and the on-prem VPN device.

## EXAMPLES

### Example 1
```powershell
$vnetgw1 = Get-AzVirtualNetworkGateway -ResourceGroupName "Rg1" -Name "gw1"
$vnetgw2 = Get-AzVirtualNetworkGateway -ResourceGroupName "Rg1" -Name "gw2"
New-AzVirtualNetworkGatewayConnection -Name conn-client-1 -ResourceGroupName "Rg1" -VirtualNetworkGateway1 $vnetgw1 -VirtualNetworkGateway2 $vnetgw2 -Location "eastus" -ConnectionType Vnet2Vnet -SharedKey 'a1b2c3d4e5'
```

### Example 2 Add/Update IngressNatRule/EgressNatRule to an existing virtual network gateway connection
```powershell
$vnetgw1 = Get-AzVirtualNetworkGateway -ResourceGroupName "Rg1" -Name "vnetgw1"
$vnetgw2 = Get-AzVirtualNetworkGateway -ResourceGroupName "Rg1" -Name "vnetgw2"
$ingressnatrule = Get-AzVirtualNetworkGatewayNatRule -ResourceGroupName "Rg1" -Name "natRule1" -ParentResourceName vnetgw1
$egressnatrule = Get-AzVirtualNetworkGatewayNatRule -ResourceGroupName "Rg1" -Name "natRule2" -ParentResourceName vnetgw1
New-AzVirtualNetworkGatewayConnection -Name conn-client-1 -ResourceGroupName $RG1 -VirtualNetworkGateway1 $vnetgw1 -VirtualNetworkGateway2 $vnetgw2 -Location "eastus" -ConnectionType Vnet2Vnet -SharedKey 'a1b2c3d4e5' `
-IngressNatRule $ingressnatrule -EgressNatRule $egressnatrule
```

The first command gets a virtual network gateway natRule named natRule1 that's type is IngressSnat.
The second command gets a virtual network gateway natRule named natRule2 that's type is EgressSnat.
The third command creates this new virtual Network gateway connection with Ingress and Egress NatRules.

### Example 3 Add GatewayCustomBgpIpAddress to virtual network gateway connection
```powershell
$LocalnetGateway = Get-AzLocalNetworkGateway -ResourceGroupName "PS_testing" -name "testLng"
$gateway = Get-AzVirtualNetworkGateway -ResourceGroupName PS_testing -ResourceName testGw
$address = New-AzGatewayCustomBgpIpConfigurationObject -IpConfigurationId "/subscriptions/83704d68-d560-4c67-b1c7-12404db89dc3/resourceGroups/PS_testing/providers/Microsoft.Network/virtualNetworkGateways/testGw/ipConfigurations/default" -CustomBgpIpAddress "169.254.21.1"

New-AzVirtualNetworkGatewayConnection -ResourceGroupName "PS_testing" -name "Conn" -location "eastus" -VirtualNetworkGateway1 $gateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey abc -GatewayCustomBgpIpAddress $address -EnableBgp $true
```

The two command gets a local network gateway and virtual network gateway.
The thrid command creates a AzGatewayCustomBgpIpConfigurationObject.
The third command creates this new virtual Network gateway connection with GatewayCustomBgpIpAddress.

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

### -AuthorizationKey
AuthorizationKey.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ConnectionMode
Virtual Network Gateway Connection Mode.

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

### -ConnectionProtocol
Gateway connection protocol:IKEv1/IKEv2

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: IKEv1, IKEv2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionType
Gateway connection type:IPsec/Vnet2Vnet/ExpressRoute/VPNClient

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: IPsec, Vnet2Vnet, ExpressRoute, VPNClient

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -DpdTimeoutInSeconds
Dead Peer Detection Timeout of the connection in seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EgressNatRule
The list of egress  NAT rules that are associated with this Connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableBgp
Whether to establish a BGP session over a S2S VPN tunnel

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnablePrivateLinkFastPath
Bypass the ExpressRoute gateway when accessing private-links.
ExpressRoute FastPath (ExpressRouteGatewayBypass) must be enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpressRouteGatewayBypass
Whether to use accelerated virtual network access by bypassing gateway

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -GatewayCustomBgpIpAddress
The GatewayCustomBgpIpAddress of Virtual network gateway used in this connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSGatewayCustomBgpIpConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IngressNatRule
The list of ingress NAT rules that are associated with this Connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpsecPolicies
A list of IPSec policies.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LocalNetworkGateway2
local network gateway.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSLocalNetworkGateway
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
location.

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

### -Name
The resource name.

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

### -Peer
Peer

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPeering
Parameter Sets: SetByResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeerId
PeerId

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -RoutingWeight
RoutingWeight.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SharedKey
The Ipsec share key.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TrafficSelectorPolicy
A list of traffic selector policies.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSTrafficSelectorPolicy[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UseLocalAzureIpAddress
Whether to use PrivateIP for this S2S VPN tunnel

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UsePolicyBasedTrafficSelectors
Whether to use policy-based traffic selectors for a S2S connection

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGateway1
First virtual network gateway.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGateway2
Second virtual network gateway.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway

### Microsoft.Azure.Commands.Network.Models.PSLocalNetworkGateway

### System.Int32

### Microsoft.Azure.Commands.Network.Models.PSPeering

### System.Boolean

### System.Management.Automation.SwitchParameter

### System.Collections.Hashtable

### Microsoft.Azure.Commands.Network.Models.PSIpsecPolicy[]

### Microsoft.Azure.Commands.Network.Models.PSTrafficSelectorPolicy[]

### Microsoft.Azure.Commands.Network.Models.PSGatewayCustomBgpIpConfiguration[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayConnection

## NOTES

## RELATED LINKS

[Get-AzVirtualNetworkGatewayConnection](./Get-AzVirtualNetworkGatewayConnection.md)

[Remove-AzVirtualNetworkGatewayConnection](./Remove-AzVirtualNetworkGatewayConnection.md)

[Set-AzVirtualNetworkGatewayConnection](./Set-AzVirtualNetworkGatewayConnection.md)