### Example 1: Create the Internal Network Resource
```powershell
$connectedIPv4Subnet = @(@{
    Prefix = "20.10.10.2/28"
})
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
New-AzNetworkFabricInternalNetwork -Name $name -L3IsolationDomainName $l3domainName -ResourceGroupName $resourceGroupName -VlanId "701" -BgpConfigurationPeerAsn 65047 -BgpConfigurationAllowAs 2 -BgpConfigurationAllowAsOverride "Enable" -BgpConfigurationDefaultRouteOriginate "True" -BgpConfigurationIpv4ListenRangePrefix @("20.10.10.2/28") -BgpConfigurationIpv4NeighborAddress @(@{Address = "20.10.10.2"}) -ConnectedIPv4Subnet $connectedIPv4Subnet -EgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -ExportRoutePolicy $exportRoutePolicy -Extension "NoExtension" -ImportRoutePolicy $importRoutePolicy -IngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -IsMonitoringEnabled "True" -Mtu 1500 -StaticRouteConfiguration @{Ipv4Route = @(@{NextHop = @("10.0.0.1"); Prefix = "10.1.0.0/24"})}
```

```output
AdministrativeState Annotation BgpConfiguration
------------------- ---------- ----------------
Enabled                        
```

This command creates the Internal Network resource.

