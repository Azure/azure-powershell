### Example 1: List PrefixListResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksPrefixListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panpflr Succeeded         azps_test_group_pan
```

List PrefixListResource by LocalRulestackName.

### Example 2: Get a PrefixListResource by name.
```powershell
Get-AzPaloAltoNetworksPrefixListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-panpflr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panpflr Succeeded         azps_test_group_pan
```

Get a PrefixListResource by name.