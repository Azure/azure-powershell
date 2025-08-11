---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudbgpserviceloadbalancerconfigurationobject
schema: 2.0.0
---

# New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject

## SYNOPSIS
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## SYNTAX

```
New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject [-BgpAdvertisement <IBgpAdvertisement[]>]
 [-BgpPeer <IServiceLoadBalancerBgpPeer[]>] [-FabricPeeringEnabled <String>]
 [-IPAddressPool <IIPAddressPool[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for BgpServiceLoadBalancerConfiguration.
```powershell

$ipAddressPools=New-AzNetworkCloudIpAddressPoolObject -Address @("198.51.102.0/24") -Name "pool1" -AutoAssign True -OnlyUseHostIP True 

$serviceLoadBalancerBgpPeer=New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name name -PeerAddress "203.0.113.254" -PeerAsn "64497" -BfdEnabled False -BgpMultiHop False -HoldTime "P300s" -KeepAliveTime "P300s" -MyAsn 64512 -Password REDACTED -PeerPort 1234

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBgpAdvertisement[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IServiceLoadBalancerBgpPeer[]
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressPool
The list of pools of IP addresses that can be allocated to load balancer services.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IIPAddressPool[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration

## NOTES

## RELATED LINKS

