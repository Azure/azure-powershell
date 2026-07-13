### Example 1: Create the Network To Network Interconnect Resource
```powershell
$layer2Configuration = @{
    Interface = @("/subscriptions//resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-interface")
    Mtu = 1500
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = $global:config.nni.importIpv4RoutePolicyId
    ImportIpv6RoutePolicyId = $global:config.nni.importIpv6RoutePolicyId
}
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = $global:config.nni.exportIpv4RoutePolicyId
    ExportIpv6RoutePolicyId = $global:config.nni.exportIpv6RoutePolicyId
}

New-AzNetworkFabricNni -Name $name -NetworkFabricName $nfName -ResourceGroupName $resourceGroupName -UseOptionB "True" -IsManagementType "True" -Layer2Configuration $layer2Configuration -NniType "CE" -OptionBLayer3ConfigurationPeerAsn 28 -OptionBLayer3ConfigurationPrimaryIpv4Prefix "172.31.0.0/31" -OptionBLayer3ConfigurationSecondaryIpv4Prefix "172.31.0.20/31" -OptionBLayer3ConfigurationVlanId 501 -ExportRoutePolicy $ExportRoutePolicy -ImportRoutePolicy $importRoutePolicy
```

```output
AdministrativeState ConfigurationState EgressAclId ExportRoutePolicy Id
------------------- ------------------ ----------- ----------------- --
Disabled            Succeeded                                        /subscriptions/<identity>/resourceGroups/nfa-tool-t…
```

This command creates the Network To Network Interconnect resource.
