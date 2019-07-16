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

### Create (Default)
```
New-AzVnetGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IVirtualNetworkGatewayConnection>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzVnetGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ConnectionType <VirtualNetworkGatewayConnectionType> -VnetGateway1 <IVirtualNetworkGateway>
 [-AuthorizationKey <String>] [-BgpSettingAsn <Int64>] [-BgpSettingBgpPeeringAddress <String>]
 [-BgpSettingPeerWeight <Int32>] [-ConnectionProtocol <VirtualNetworkGatewayConnectionProtocol>]
 [-ConnectionStatus <VirtualNetworkGatewayConnectionStatus>] [-EnableBgp] [-Etag <String>]
 [-ExpressRouteGatewayBypass] [-GatewayIPAddress <String>] [-IPsecPolicy <IIpsecPolicy[]>] [-Id <String>]
 [-LocalNetworkAddressPrefix <String[]>] [-LocalNetworkGateway2Etag <String>]
 [-LocalNetworkGateway2Id <String>] [-LocalNetworkGateway2Location <String>]
 [-LocalNetworkGateway2PropertiesResourceGuid <String>] [-LocalNetworkGateway2Tag <Hashtable>]
 [-Location <String>] [-PeerId <String>] [-ResourceGuid <String>] [-RoutingWeight <Int32>]
 [-SharedKey <String>] [-Tag <Hashtable>] [-UsePolicyBasedTrafficSelectors]
 [-VnetGateway2 <IVirtualNetworkGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVnetGatewayConnection -InputObject <INetworkIdentity>
 -ConnectionType <VirtualNetworkGatewayConnectionType> -VnetGateway1 <IVirtualNetworkGateway>
 [-AuthorizationKey <String>] [-BgpSettingAsn <Int64>] [-BgpSettingBgpPeeringAddress <String>]
 [-BgpSettingPeerWeight <Int32>] [-ConnectionProtocol <VirtualNetworkGatewayConnectionProtocol>]
 [-ConnectionStatus <VirtualNetworkGatewayConnectionStatus>] [-EnableBgp] [-Etag <String>]
 [-ExpressRouteGatewayBypass] [-GatewayIPAddress <String>] [-IPsecPolicy <IIpsecPolicy[]>] [-Id <String>]
 [-LocalNetworkAddressPrefix <String[]>] [-LocalNetworkGateway2Etag <String>]
 [-LocalNetworkGateway2Id <String>] [-LocalNetworkGateway2Location <String>]
 [-LocalNetworkGateway2PropertiesResourceGuid <String>] [-LocalNetworkGateway2Tag <Hashtable>]
 [-Location <String>] [-PeerId <String>] [-ResourceGuid <String>] [-RoutingWeight <Int32>]
 [-SharedKey <String>] [-Tag <Hashtable>] [-UsePolicyBasedTrafficSelectors]
 [-VnetGateway2 <IVirtualNetworkGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVnetGatewayConnection -InputObject <INetworkIdentity> [-Parameter <IVirtualNetworkGatewayConnection>]
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpSettingAsn
The BGP speaker's ASN.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpSettingBgpPeeringAddress
The BGP peering address and BGP identifier of this BGP speaker.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpSettingPeerWeight
The weight added to routes learned from this BGP speaker.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionProtocol
Connection protocol used for this connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionStatus
Virtual Network Gateway connection status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ExpressRouteGatewayBypass
Bypass ExpressRoute Gateway for data forwarding

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayIPAddress
IP address of local network gateway.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: IpsecPolicies

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkAddressPrefix
A list of address blocks reserved for this virtual network in CIDR notation.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2PropertiesResourceGuid
The resource GUID property of the LocalNetworkGateway resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalNetworkGateway2Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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

### -Parameter
A common class for general resource information
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnection
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PeerId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases: LocalNetworkGateway2, Peer

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: VirtualNetworkGateway2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnection

## ALIASES

### New-AzVirtualNetworkGatewayConnection

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### IPSECPOLICY <IIpsecPolicy[]>: The IPSec Policies to be considered by this connection.
  - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### PARAMETER <IVirtualNetworkGatewayConnection>: A common class for general resource information
  - `ConnectionType <VirtualNetworkGatewayConnectionType>`: Gateway connection type.
  - `VirtualNetworkGateway1 <IVirtualNetworkGateway>`: The reference to virtual network gateway resource.
    - `[Active <Boolean?>]`: ActiveActive flag
    - `[BgpSettingAsn <Int64?>]`: The BGP speaker's ASN.
    - `[BgpSettingBgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
    - `[BgpSettingPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
    - `[CustomRouteAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
    - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
    - `[GatewayDefaultSiteId <String>]`: Resource ID.
    - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
    - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[PublicIPAddressId <String>]`: Resource ID.
      - `[SubnetId <String>]`: Resource ID.
    - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
    - `[SkuCapacity <Int32?>]`: The capacity.
    - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
    - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
    - `[VpnClientAddressPoolAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[VpnClientConfigurationRadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
    - `[VpnClientConfigurationRadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
    - `[VpnClientConfigurationVpnClientIpsecPolicy <IIpsecPolicy[]>]`: VpnClientIpsecPolicies for virtual network gateway P2S client.
    - `[VpnClientConfigurationVpnClientProtocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
    - `[VpnClientConfigurationVpnClientRevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
    - `[VpnClientConfigurationVpnClientRootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
      - `PublicCertData <String>`: The certificate public data.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.
  - `[AuthorizationKey <String>]`: The authorizationKey.
  - `[BgpSettingAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpSettingBgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[BgpSettingPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[ConnectionProtocol <VirtualNetworkGatewayConnectionProtocol?>]`: Connection protocol used for this connection
  - `[ConnectionStatus <VirtualNetworkGatewayConnectionStatus?>]`: Virtual Network Gateway connection status.
  - `[EnableBgp <Boolean?>]`: EnableBgp flag
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[ExpressRouteGatewayBypass <Boolean?>]`: Bypass ExpressRoute Gateway for data forwarding
  - `[GatewayIPAddress <String>]`: IP address of local network gateway.
  - `[IpsecPolicy <IIpsecPolicy[]>]`: The IPSec Policies to be considered by this connection.
    - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
    - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
    - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
    - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
    - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
    - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
    - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
    - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.
  - `[LocalNetworkAddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[LocalNetworkGateway2Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[LocalNetworkGateway2Id <String>]`: Resource ID.
  - `[LocalNetworkGateway2Location <String>]`: Resource location.
  - `[LocalNetworkGateway2PropertiesResourceGuid <String>]`: The resource GUID property of the LocalNetworkGateway resource.
  - `[LocalNetworkGateway2Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[PeerId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGatewayConnection resource.
  - `[RoutingWeight <Int32?>]`: The routing weight.
  - `[SharedKey <String>]`: The IPSec shared key.
  - `[UsePolicyBasedTrafficSelector <Boolean?>]`: Enable policy-based traffic selectors.
  - `[VirtualNetworkGateway2 <IVirtualNetworkGateway>]`: The reference to virtual network gateway resource.

#### VNETGATEWAY1 <IVirtualNetworkGateway>: The reference to virtual network gateway resource.
  - `[Active <Boolean?>]`: ActiveActive flag
  - `[BgpSettingAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpSettingBgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[BgpSettingPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[CustomRouteAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[GatewayDefaultSiteId <String>]`: Resource ID.
  - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
  - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
  - `[SkuCapacity <Int32?>]`: The capacity.
  - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
  - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
  - `[VpnClientAddressPoolAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[VpnClientConfigurationRadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
  - `[VpnClientConfigurationRadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
  - `[VpnClientConfigurationVpnClientIpsecPolicy <IIpsecPolicy[]>]`: VpnClientIpsecPolicies for virtual network gateway P2S client.
    - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
    - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
    - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
    - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
    - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
    - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
    - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
    - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.
  - `[VpnClientConfigurationVpnClientProtocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
  - `[VpnClientConfigurationVpnClientRevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
  - `[VpnClientConfigurationVpnClientRootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
    - `PublicCertData <String>`: The certificate public data.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.

#### VNETGATEWAY2 <IVirtualNetworkGateway>: The reference to virtual network gateway resource.
  - `[Active <Boolean?>]`: ActiveActive flag
  - `[BgpSettingAsn <Int64?>]`: The BGP speaker's ASN.
  - `[BgpSettingBgpPeeringAddress <String>]`: The BGP peering address and BGP identifier of this BGP speaker.
  - `[BgpSettingPeerWeight <Int32?>]`: The weight added to routes learned from this BGP speaker.
  - `[CustomRouteAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[EnableBgp <Boolean?>]`: Whether BGP is enabled for this virtual network gateway or not.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[GatewayDefaultSiteId <String>]`: Resource ID.
  - `[GatewayType <VirtualNetworkGatewayType?>]`: The type of this virtual network gateway. Possible values are: 'Vpn' and 'ExpressRoute'.
  - `[IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]`: IP configurations for virtual network gateway.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: The resource GUID property of the VirtualNetworkGateway resource.
  - `[SkuCapacity <Int32?>]`: The capacity.
  - `[SkuName <VirtualNetworkGatewaySkuName?>]`: Gateway SKU name.
  - `[SkuTier <VirtualNetworkGatewaySkuTier?>]`: Gateway SKU tier.
  - `[VpnClientAddressPoolAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[VpnClientConfigurationRadiusServerAddress <String>]`: The radius server address property of the VirtualNetworkGateway resource for vpn client connection.
  - `[VpnClientConfigurationRadiusServerSecret <String>]`: The radius secret property of the VirtualNetworkGateway resource for vpn client connection.
  - `[VpnClientConfigurationVpnClientIpsecPolicy <IIpsecPolicy[]>]`: VpnClientIpsecPolicies for virtual network gateway P2S client.
    - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
    - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
    - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
    - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
    - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
    - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
    - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
    - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.
  - `[VpnClientConfigurationVpnClientProtocol <VpnClientProtocol[]>]`: VpnClientProtocols for Virtual network gateway.
  - `[VpnClientConfigurationVpnClientRevokedCertificate <IVpnClientRevokedCertificate[]>]`: VpnClientRevokedCertificate for Virtual network gateway.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.
  - `[VpnClientConfigurationVpnClientRootCertificate <IVpnClientRootCertificate[]>]`: VpnClientRootCertificate for virtual network gateway.
    - `PublicCertData <String>`: The certificate public data.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[VpnType <VpnType?>]`: The type of this virtual network gateway. Possible values are: 'PolicyBased' and 'RouteBased'.

## RELATED LINKS

