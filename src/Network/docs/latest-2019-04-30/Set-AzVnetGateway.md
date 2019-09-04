---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvnetgateway
schema: 2.0.0
---

# Set-AzVnetGateway

## SYNOPSIS
Creates or updates a virtual network gateway in the specified resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzVnetGateway -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AddressPrefix <String[]>] [-BgpAsn <Int64>] [-BgpPeeringAddress <String>] [-BgpPeerWeight <Int32>]
 [-CustomRouteAddressPrefix <String[]>] [-EnableActiveActive] [-EnableBgp] [-Etag <String>]
 [-GatewayDefaultSiteId <String>] [-GatewayType <VirtualNetworkGatewayType>] [-Id <String>]
 [-IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>] [-IPsecPolicy <IIpsecPolicy[]>]
 [-Location <String>] [-Protocol <VpnClientProtocol[]>] [-RadiusServerAddress <String>]
 [-RadiusServerSecret <String>] [-ResourceGuid <String>]
 [-RevokedCertificate <IVpnClientRevokedCertificate[]>] [-RootCertificate <IVpnClientRootCertificate[]>]
 [-SkuCapacity <Int32>] [-SkuName <VirtualNetworkGatewaySkuName>] [-SkuTier <VirtualNetworkGatewaySkuTier>]
 [-Tag <Hashtable>] [-VpnType <VpnType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzVnetGateway -Name <String> -ResourceGroupName <String> -VnetGateway <IVirtualNetworkGateway>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a virtual network gateway in the specified resource group.

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

### -AddressPrefix
A list of address blocks reserved for this virtual network in CIDR notation.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases: VpnClientAddressPool, VpnClientAddressPrefix

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpAsn
The BGP speaker's ASN.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases: Asn

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpPeeringAddress
The BGP peering address and BGP identifier of this BGP speaker.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BgpPeerWeight
The weight added to routes learned from this BGP speaker.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases: PeerWeight, BgpPeeringWeight

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomRouteAddressPrefix
A list of address blocks reserved for this virtual network in CIDR notation.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -EnableActiveActive
ActiveActive flag

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases: EnableActiveActiveFeature

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableBgp
Whether BGP is enabled for this virtual network gateway or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayDefaultSiteId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayType
The type of this virtual network gateway.
Possible values are: 'Vpn' and 'ExpressRoute'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPConfiguration
IP configurations for virtual network gateway.
To construct, see NOTES section for IPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPsecPolicy
VpnClientIpsecPolicies for virtual network gateway P2S client.
To construct, see NOTES section for IPSECPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: UpdateExpanded
Aliases: VpnClientIPsecPolicy

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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualNetworkGatewayName

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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
VpnClientProtocols for Virtual network gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]
Parameter Sets: UpdateExpanded
Aliases: VpnClientProtocol

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerAddress
The radius server address property of the VirtualNetworkGateway resource for vpn client connection.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: VpnClientRadiusServerAddress

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerSecret
The radius secret property of the VirtualNetworkGateway resource for vpn client connection.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: VpnClientRadiusServerSecret

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGuid
The resource GUID property of the VirtualNetworkGateway resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RevokedCertificate
VpnClientRevokedCertificate for Virtual network gateway.
To construct, see NOTES section for REVOKEDCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate[]
Parameter Sets: UpdateExpanded
Aliases: VpnClientRevokedCertificates, VpnClientRevokedCertificate

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RootCertificate
VpnClientRootCertificate for virtual network gateway.
To construct, see NOTES section for ROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate[]
Parameter Sets: UpdateExpanded
Aliases: VpnClientRootCertificates, VpnClientRootCertificate

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
The capacity.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
Gateway SKU name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
Gateway SKU tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetGateway
A common class for general resource information
To construct, see NOTES section for VNETGATEWAY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -VpnType
The type of this virtual network gateway.
Possible values are: 'PolicyBased' and 'RouteBased'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType
Parameter Sets: UpdateExpanded
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway

## ALIASES

### Set-AzVirtualNetworkGateway

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### IPCONFIGURATION <IVirtualNetworkGatewayIPConfiguration[]>: IP configurations for virtual network gateway.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[PublicIPAddressId <String>]`: Resource ID.
  - `[SubnetId <String>]`: Resource ID.

#### IPSECPOLICY <IIpsecPolicy[]>: VpnClientIpsecPolicies for virtual network gateway P2S client.
  - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### REVOKEDCERTIFICATE <IVpnClientRevokedCertificate[]>: VpnClientRevokedCertificate for Virtual network gateway.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.

#### ROOTCERTIFICATE <IVpnClientRootCertificate[]>: VpnClientRootCertificate for virtual network gateway.
  - `PublicCertData <String>`: The certificate public data.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

#### VNETGATEWAY <IVirtualNetworkGateway>: A common class for general resource information
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

