### Example 1: Create the External Network Resource
```powershell
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$routeTarget = @{
    ExportIpv4RouteTarget = @("65046:10039")
    ExportIpv6RouteTarget = @("65046:10039")
    ImportIpv4RouteTarget = @("65046:10039")
    ImportIpv6RouteTarget = @("65046:10039")
}
$optionBProperty = @{
    RouteTarget = $routeTarget
}

$optionAPropertyBfdConfiguration = @{
    IntervalInMilliSecond = 300
    Multiplier = 3
}

New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionB" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionBProperty $optionBProperty
```

```output
AdministrativeState Annotation ConfigurationState ExportRoutePolicy
------------------- ---------- ------------------ -----------------
Enabled                                           
```

This command creates the External Network resource with Option B Properties.

### Example 2: Create the External Network Resource
```powershell
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionA" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionAPropertyBfdConfiguration $optionAPropertyBfdConfiguration -OptionAPropertyEgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/egressAclName" -OptionAPropertyIngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/ingressAclName" -OptionAPropertyMtu 1500 -OptionAPropertyPeerAsn 65123 -OptionAPropertyPrimaryIpv4Prefix "172.31.0.0/30" -OptionAPropertySecondaryIpv4Prefix "172.31.0.0/30" -OptionAPropertyVlanId 501
```

```output
AdministrativeState Annotation ConfigurationState ExportRoutePolicy
------------------- ---------- ------------------ -----------------
Enabled                                           
```

This command creates the External Network resource with Option A Properties.

