### Example 1: Create the Network Fabric Controller Resource
```powershell
$infra = @(@{
    ExpressRouteCircuitId = "/subscriptions/b256be71-d296-4e0e-99a1-408d9edc8718/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/example-expressRouteCircuit"
    ExpressRouteAuthorizationKey = "00000000-0000-0000-0000-000000000000"
})
$workLoad = @(@{
    ExpressRouteCircuitId = "/subscriptions/b256be71-d296-4e0e-99a1-408d9edc8718/resourceGroups/example-rg/providers/Microsoft.Network/expressRouteCircuits/example-expressRouteCircuit"
    ExpressRouteAuthorizationKey = "00000000-0000-0000-0000-000000000000"
})

New-AzNetworkFabricController -Name $name -ResourceGroupName $resourceGroupName -Location $location -Ipv4AddressSpace "30.0.0.0/19" -IsWorkloadManagementNetworkEnabled "True"  -NfcSku "Basic" -WorkloadExpressRouteConnection $workLoad -InfrastructureExpressRouteConnection $infra
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFa…
```

This command creates the Network Fabric Controller resource.
