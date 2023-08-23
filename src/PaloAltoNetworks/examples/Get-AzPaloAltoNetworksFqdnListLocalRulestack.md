### Example 1: List FqdnListLocalRulestackResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksFqdnListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panfllr Succeeded         azps_test_group_pan
```

List FqdnListLocalRulestackResource by LocalRulestackName.

### Example 2: Get a FqdnListLocalRulestackResource by name.
```powershell
Get-AzPaloAltoNetworksFqdnListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-panfllr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panfllr Succeeded         azps_test_group_pan
```

Get a FqdnListLocalRulestackResource by name.