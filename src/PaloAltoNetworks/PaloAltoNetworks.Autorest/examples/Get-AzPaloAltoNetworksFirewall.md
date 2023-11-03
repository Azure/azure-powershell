### Example 1: List FirewallResource by subscription.
```powershell
Get-AzPaloAltoNetworksFirewall
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

List FirewallResource by subscription.

### Example 2: Get a FirewallResource by ResourceGroupName.
```powershell
Get-AzPaloAltoNetworksFirewall -ResourceGroupName azps_test_group_pan
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Get a FirewallResource by ResourceGroupName.

### Example 3: Get a FirewallResource by name.
```powershell
Get-AzPaloAltoNetworksFirewall -ResourceGroupName azps_test_group_pan -Name azps-firewall
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Get a FirewallResource by name.