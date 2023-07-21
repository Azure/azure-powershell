### Example 1: Create an in-memory object for NetworkProfile.
```powershell
$publicIP = New-AzPaloAltoNetworksIPAddressObject -ResourceId /subscriptions/{subId}/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/publicIPAddresses/azps-network-publicipaddresses

New-AzPaloAltoNetworksProfileObject -EnableEgressNat DISABLED -PublicIP $publicIP -NetworkType VNET -VnetConfigurationIPOfTrustSubnetForUdrAddress 10.1.1.0/24 -VnetConfigurationTrustSubnetResourceId /subscriptions/{subId}/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/default -VnetConfigurationUnTrustSubnetResourceId /subscriptions/{subId}/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/default2 -VnetResourceId /subscriptions/{subId}/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network
```

```output
EnableEgressNat NetworkType
--------------- -----------
DISABLED        VNET
```

Create an in-memory object for NetworkProfile.