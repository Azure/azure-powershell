### Example 1: Create a FirewallResource.
```powershell
$publicIP = New-AzPaloAltoNetworksIPAddressObject -ResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/publicIPAddresses/azps-network-publicipaddresses"

$networkProfile = New-AzPaloAltoNetworksProfileObject -EnableEgressNat DISABLED -PublicIP $publicIP -NetworkType VNET -VnetConfigurationIPOfTrustSubnetForUdrAddress 10.1.1.0/24 -VnetConfigurationTrustSubnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/subnet1" -VnetConfigurationUnTrustSubnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/subnet2" -VnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network"

New-AzPaloAltoNetworksFirewall -Name azps-firewall -ResourceGroupName azps_test_group_pan -Location eastus -MarketplaceDetailOfferId "pan_swfw_cloud_ngfw" -MarketplaceDetailPublisherId "paloaltonetworks" -NetworkProfile $networkProfile -PlanDataBillingCycle "MONTHLY" -PlanDataPlanId "cloud-ngfw-payg-test" -AssociatedRulestackResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/azps-panlr" -DnsSettingDnsServer $publicIP -DnsSettingEnableDnsProxy DISABLED -DnsSettingEnabledDnsType CUSTOM -AssociatedRulestackLocation eastus
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Create a FirewallResource.