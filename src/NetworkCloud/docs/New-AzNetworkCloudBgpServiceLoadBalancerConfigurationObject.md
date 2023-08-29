---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject
schema: 2.0.0
---

# New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject

## SYNOPSIS
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## SYNTAX

```
New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject [-BgpAdvertisement <IBgpAdvertisement[]>]
 [-BgpPeer <IServiceLoadBalancerBgpPeer[]>] [-FabricPeeringEnabled <FabricPeeringEnabled>]
 [-IPAddressPool <IIPAddressPool[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for BgpServiceLoadBalancerConfiguration.
```powershell

$ipAddressPools=New-AzNetworkCloudIpAddressPoolObject -Address @("198.51.102.0/24") -Name "pool1" -AutoAssign True -OnlyUseHostIP True 

$serviceLoadBalancerBgpPeer=New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name name -PeerAddress "203.0.113.254" -PeerAsn "64497" -BfdEnabled False -BgpMultiHop False -HoldTime "P300s" -KeepAliveTime "P300s" -MyAsn 64512 -Password passsword -PeerPort 1234

$bgpAdvertisement=New-AzNetworkCloudBgpAdvertisementObject -IPAddressPool  @("pool1","pool2") -AdvertiseToFabric "True" -Community  @("communityString") -Peer @("peer1") 

$object=New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject -BgpAdvertisement @($bgpAdvertisement) -BgpPeer $serviceLoadBalancerBgpPeer -FabricPeeringEnabled True -IPAddressPool @($ipAddressPools)

Write-Host ($object | Format-List | Out-String)
```

```output
Category : azure-resource-management
Endpoint : {{
             "domainName": "domainName",
             "port": 1234
           }}
```

Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## PARAMETERS

### -BgpAdvertisement
The association of IP address pools to the communities and peers, allowing for announcement of IPs.
To construct, see NOTES section for BGPADVERTISEMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IBgpAdvertisement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpPeer
The list of additional BgpPeer entities that the Kubernetes cluster will peer with.
All peering must be explicitly defined.
To construct, see NOTES section for BGPPEER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IServiceLoadBalancerBgpPeer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricPeeringEnabled
The indicator to specify if the load balancer peers with the network fabric.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.FabricPeeringEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressPool
The list of pools of IP addresses that can be allocated to Load Balancer services.
To construct, see NOTES section for IPADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IIPAddressPool[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.BgpServiceLoadBalancerConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BGPADVERTISEMENT <IBgpAdvertisement[]>`: The association of IP address pools to the communities and peers, allowing for announcement of IPs.
  - `IPAddressPool <String[]>`: The names of the IP address pools associated with this announcement.
  - `[AdvertiseToFabric <AdvertiseToFabric?>]`: The indicator of if this advertisement is also made to the network fabric associated with the Network Cloud Cluster. This field is ignored if fabricPeeringEnabled is set to False.
  - `[Community <String[]>]`: The names of the BGP communities to be associated with the announcement, utilizing a BGP community string in 1234:1234 format.
  - `[Peer <String[]>]`: The names of the BGP peers to limit this advertisement to. If no values are specified, all BGP peers will receive this advertisement.

`BGPPEER <IServiceLoadBalancerBgpPeer[]>`: The list of additional BgpPeer entities that the Kubernetes cluster will peer with. All peering must be explicitly defined.
  - `Name <String>`: The name used to identify this BGP peer for association with a BGP advertisement.
  - `PeerAddress <String>`: The IPv4 or IPv6 address used to connect this BGP session.
  - `PeerAsn <Int64>`: The autonomous system number expected from the remote end of the BGP session.
  - `[BfdEnabled <BfdEnabled?>]`: The indicator of BFD enablement for this BgpPeer.
  - `[BgpMultiHop <BgpMultiHop?>]`: The indicator to enable multi-hop peering support.
  - `[HoldTime <String>]`: The requested BGP hold time value. This field uses ISO 8601 duration format, for example P1H.
  - `[KeepAliveTime <String>]`: The requested BGP keepalive time value. This field uses ISO 8601 duration format, for example P1H.
  - `[MyAsn <Int64?>]`: The autonomous system number used for the local end of the BGP session.
  - `[Password <String>]`: The authentication password for routers enforcing TCP MD5 authenticated sessions.
  - `[PeerPort <Int64?>]`: The port used to connect this BGP session.

`IPADDRESSPOOL <IIPAddressPool[]>`: The list of pools of IP addresses that can be allocated to Load Balancer services.
  - `Address <String[]>`: The list of IP address ranges. Each range can be a either a subnet in CIDR format or an explicit start-end range of IP addresses.
  - `Name <String>`: The name used to identify this IP address pool for association with a BGP advertisement.
  - `[AutoAssign <BfdEnabled?>]`: The indicator to determine if automatic allocation from the pool should occur.
  - `[OnlyUseHostIP <BfdEnabled?>]`: The indicator to prevent the use of IP addresses ending with .0 and .255 for this pool. Enabling this option will only use IP addresses between .1 and .254 inclusive.

## RELATED LINKS

