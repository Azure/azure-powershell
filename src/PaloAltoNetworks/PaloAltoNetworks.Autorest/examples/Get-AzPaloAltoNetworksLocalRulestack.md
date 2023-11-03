### Example 1: List LocalRulestackResource by subscription.
```powershell
Get-AzPaloAltoNetworksLocalRulestack
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

List LocalRulestackResource by subscription.

### Example 2: List LocalRulestackResource by resource group.
```powershell
Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName azps_test_group_pan
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

List LocalRulestackResource by resource group.

### Example 3: Get a LocalRulestackResource by name.
```powershell
Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName azps_test_group_pan -Name azps-panlr
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Get a LocalRulestackResource by name.