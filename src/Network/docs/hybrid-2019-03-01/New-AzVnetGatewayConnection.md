---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvnetgatewayconnection
schema: 2.0.0
---

# New-AzVnetGatewayConnection

## SYNOPSIS
Creates or updates a virtual network gateway connection in the specified resource group.

## SYNTAX

### CreateViaIdentity1 (Default)
```
New-AzVnetGatewayConnection -InputObject <INetworkIdentity>
 -VnetGatewayConnection <IVirtualNetworkGatewayConnection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzVnetGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ConnectionType <VirtualNetworkGatewayConnectionType> -VnetGateway1 <IVirtualNetworkGateway_Reference>
 [-AuthorizationKey <String>] [-EnableBgp] [-Etag <String>] [-IPsecPolicy <IIpsecPolicy[]>] [-Id <String>]
 [-LocalNetworkGateway2 <ILocalNetworkGateway_Reference>] [-Location <String>] [-PeerId <String>]
 [-ResourceGuid <String>] [-RoutingWeight <Int32>] [-SharedKey <String>] [-Tag <Hashtable>]
 [-UsePolicyBasedTrafficSelectors] [-VnetGateway2 <IVirtualNetworkGateway_Reference>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzVnetGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -VnetGatewayConnection <IVirtualNetworkGatewayConnection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzVnetGatewayConnection -InputObject <INetworkIdentity>
 -ConnectionType <VirtualNetworkGatewayConnectionType> -VnetGateway1 <IVirtualNetworkGateway_Reference>
 [-AuthorizationKey <String>] [-EnableBgp] [-Etag <String>] [-IPsecPolicy <IIpsecPolicy[]>] [-Id <String>]
 [-LocalNetworkGateway2 <ILocalNetworkGateway_Reference>] [-Location <String>] [-PeerId <String>]
 [-ResourceGuid <String>] [-RoutingWeight <Int32>] [-SharedKey <String>] [-Tag <Hashtable>]
 [-UsePolicyBasedTrafficSelectors] [-VnetGateway2 <IVirtualNetworkGateway_Reference>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a virtual network gateway connection in the specified resource group.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AuthorizationKey
The authorizationKey.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionType
Gateway connection type.
Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableBgp
EnableBgp flag

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentity1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IPsecPolicy
The IPSec Policies to be considered by this connection.
To construct, see NOTES section for IPSECPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: IpsecPolicies

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2
The reference to local network gateway resource.
To construct, see NOTES section for LOCALNETWORKGATEWAY2 properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILocalNetworkGateway_Reference
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the virtual network gateway connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, Create1
Aliases: VirtualNetworkGatewayConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeerId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, Create1
Aliases: Peer

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGuid
The resource GUID property of the VirtualNetworkGatewayConnection resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoutingWeight
The routing weight.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SharedKey
The IPSec shared key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, Create1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UsePolicyBasedTrafficSelectors
Enable policy-based traffic selectors.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetGateway1
The reference to virtual network gateway resource.
To construct, see NOTES section for VNETGATEWAY1 properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGateway_Reference
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: VirtualNetworkGateway1

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetGateway2
The reference to virtual network gateway resource.
To construct, see NOTES section for VNETGATEWAY2 properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGateway_Reference
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: VirtualNetworkGateway2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetGatewayConnection
A common class for general resource information
To construct, see NOTES section for VNETGATEWAYCONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnection
Parameter Sets: CreateViaIdentity1, Create1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnection

## ALIASES

### New-AzVirtualNetworkGatewayConnection

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### IPSECPOLICY <IIpsecPolicy[]>: The IPSec Policies to be considered by this connection.
  - `DhGroup <DhGroup>`: The DH Groups used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The DH Groups used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### LOCALNETWORKGATEWAY2 <ILocalNetworkGateway_Reference>: The reference to local network gateway resource.
  - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[BgpAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[BgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[GatewayIPAddress <String>]`: IP address of local network gateway.
  - `[ResourceGuid <String>]`: The resource GUID property of the LocalNetworkGateway resource.

#### VNETGATEWAY1 <IVirtualNetworkGateway_Reference>: The reference to virtual network gateway resource.
  - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[BgpAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[BgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[EnableActiveActive <Boolean?>]`: ActiveActive flag
  - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[GatewayDefaultSiteId <String>]`: Resource ID.
  - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
  - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
  - `[Protocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
  - `[RadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
  - `[RadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
  - `[RevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
  - `[RootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
    - `PublicCertData <String>`: The certificate public data.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[SkuCapacity <Int32?>]`: The capacity.
  - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
  - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
  - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.

#### VNETGATEWAY2 <IVirtualNetworkGateway_Reference>: The reference to virtual network gateway resource.
  - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[BgpAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[BgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[EnableActiveActive <Boolean?>]`: ActiveActive flag
  - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[GatewayDefaultSiteId <String>]`: Resource ID.
  - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
  - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
  - `[Protocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
  - `[RadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
  - `[RadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
  - `[RevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
  - `[RootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
    - `PublicCertData <String>`: The certificate public data.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[SkuCapacity <Int32?>]`: The capacity.
  - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
  - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
  - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.

#### VNETGATEWAYCONNECTION <IVirtualNetworkGatewayConnection>: A common class for general resource information
  - `ConnectionType <VirtualNetworkGatewayConnectionType>`: Gateway connection type. Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.
  - `VnetGateway1 <IVirtualNetworkGateway>`: The reference to virtual network gateway resource.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
    - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[BgpAsn <Int64?>]`: The BGP speaker's ASN.
    - `[BgpPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
    - `[BgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
    - `[EnableActiveActive <Boolean?>]`: ActiveActive flag
    - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
    - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
    - `[GatewayDefaultSiteId <String>]`: Resource ID.
    - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
    - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[PublicIPAddressId <String>]`: Resource ID.
      - `[SubnetId <String>]`: Resource ID.
    - `[Protocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
    - `[RadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
    - `[RadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
    - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
    - `[RevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
    - `[RootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
      - `PublicCertData <String>`: The certificate public data.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[SkuCapacity <Int32?>]`: The capacity.
    - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
    - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
    - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AuthorizationKey <String>]`: The authorizationKey.
  - `[EnableBgp <Boolean?>]`: EnableBgp flag
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[IpsecPolicy <IIpsecPolicy[]>]`: The IPSec Policies to be considered by this connection.
    - `DhGroup <DhGroup>`: The DH Groups used in IKE Phase 1 for initial SA.
    - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
    - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
    - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
    - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
    - `PfsGroup <PfsGroup>`: The DH Groups used in IKE Phase 2 for new child SA.
    - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
    - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.
  - `[LocalNetworkGateway2 <ILocalNetworkGateway>]`: The reference to local network gateway resource.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
    - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[BgpAsn <Int64?>]`: The BGP speaker's ASN.
    - `[BgpPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
    - `[BgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[GatewayIPAddress <String>]`: IP address of local network gateway.
    - `[ResourceGuid <String>]`: The resource GUID property of the LocalNetworkGateway resource.
  - `[PeerId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGatewayConnection resource.
  - `[RoutingWeight <Int32?>]`: The routing weight.
  - `[SharedKey <String>]`: The IPSec shared key.
  - `[UsePolicyBasedTrafficSelectors <Boolean?>]`: Enable policy-based traffic selectors.
  - `[VnetGateway2 <IVirtualNetworkGateway>]`: The reference to virtual network gateway resource.

## RELATED LINKS

