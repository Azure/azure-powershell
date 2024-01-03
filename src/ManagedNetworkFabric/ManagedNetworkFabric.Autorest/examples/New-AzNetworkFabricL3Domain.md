### Example 1: Create the L3 Isolation Domain Resource
```powershell
$connectedSubnetRoutePolicy = @{
    ExportRoutePolicy = @{
        ExportIpv4RoutePolicyId =
        ExportIpv6RoutePolicyId =
    }
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
Disabled            {…
```

This command creates the L3 Isolation Domain resource.

