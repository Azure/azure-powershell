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
