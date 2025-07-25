### Example 1: Create the L3 Isolation Domain Resource
```powershell
$connectedSubnetRoutePolicy = @{
    ExportRoutePolicy = @(@{
        ExportIpv4RoutePolicyId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
        ExportIpv6RoutePolicyId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    })
}
$aggregateRouteConfiguration = @{
    Ipv4Route = @(@{
        Prefix = "10.0.0.1/28"
    })
    Ipv6Route = @(@{
        Prefix = "2fff::/64"
    })
}

New-AzNetworkFabricL3Domain -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AggregateRouteConfiguration $aggregateRouteConfiguration -RedistributeConnectedSubnet "True" -RedistributeStaticRoute "True" -ConnectedSubnetRoutePolicy $connectedSubnetRoutePolicy
```

```output
AdministrativeState AggregateRouteConfiguration
------------------- ---------------------------
Disabled            
```

This command creates the L3 Isolation Domain resource.

