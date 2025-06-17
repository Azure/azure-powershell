### Example 1: Create the Route Policy Resource
```powershell
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixTestName"
    ConditionType = "Or"
    IPCommunityPropertyAddIpcommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipCommunities/ipCommunityName"
})

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGrou...
```

This command creates the Route Policy resource with IPCommunity.

### Example 2: Create the Route Policy Resource
```powershell
$statements = @(@{
    ActionType = "Permit"
    SequenceNumber = 12345
    ActionLocalPreference = 123
    ConditionIPExtendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
    ConditionIPPrefixId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/ipPrefixName"
    ConditionType = "Or"
    IPExtendedCommunityPropertyAddIpextendedCommunityId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/ipExtCommName"
})

New-AzNetworkFabricRoutePolicy -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -AddressFamilyType "IPv4" -DefaultAction "Permit" -Statement $statements
```

```output
AddressFamilyType AdministrativeState Annotation ConfigurationState DefaultAction Id
----------------- ------------------- ---------- ------------------ ------------- --
IPv4                                                                Permit        /subscriptions/<identity>/resourceGrou…
```

This command creates the Route Policy resource with IPExtendedCommunity.

