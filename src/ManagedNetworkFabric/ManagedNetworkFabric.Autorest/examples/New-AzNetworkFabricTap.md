### Example 1: Create the Network Tap Resource
```powershell
$destinations = @(@{
    DestinationId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/l3DomainName/internalNetworks/internalNetworkName"
    DestinationTapRuleId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkTapRules/NetworkTapRuleName"
    DestinationType = "IsolationDomain"
    IsolationDomainPropertyEncapsulation = "GRE"
    IsolationDomainPropertyNeighborGroupId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/neighborGroups/NeighborGroupName"
    Name = "destinationName"
})

New-AzNetworkFabricTap -Name $name -ResourceGroupName $resourceGroupName -Destination $destinations -Location $location -NetworkPacketBrokerId $npbId -PollingType "Push"
```

```output
AdministrativeState Annotation ConfigurationState Destination
------------------- ---------- ------------------ -----------
Disabled                       Succeeded          
```

This command creates the Network Tap resource.

