### Example 1: Create the Network Fabric Resource
```powershell
$managementNetworkConfiguration = @{
    InfrastructureVpnConfigurationPeeringOption = "OptionB"
    WorkloadVpnConfigurationPeeringOption = "OptionB"
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
}

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                                                  /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the Network Fabric resource with Option B Properties.

### Example 2: Create the Network Fabric Resource
```powershell
$managementNetworkConfiguration = @{
    InfrastructureVpnConfigurationPeeringOption = "OptionA"
    WorkloadVpnConfigurationPeeringOption = "OptionA"
    InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond = 300
    InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier = 3
    InfrastructureVpnConfigurationOptionAPropertiesMtu = 1500
    InfrastructureVpnConfigurationOptionAPropertiesPeerAsn = 28
    InfrastructureVpnConfigurationOptionAPropertiesVlanId = 501
    InfrastructureVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix = "10.0.0.14/30"
    InfrastructureVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix = "10.0.0.14/30"
    WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond = 300
    WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier = 3
    WorkloadVpnConfigurationOptionAPropertiesMtu = 1500
    WorkloadVpnConfigurationOptionAPropertiesPeerAsn = 28
    WorkloadVpnConfigurationOptionAPropertiesVlanId = 501
    WorkloadVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix = "10.0.0.14/30"
    WorkloadVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix = "10.0.0.14/30"
}

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                                                  /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the Network Fabric resource with Option A Properties.

