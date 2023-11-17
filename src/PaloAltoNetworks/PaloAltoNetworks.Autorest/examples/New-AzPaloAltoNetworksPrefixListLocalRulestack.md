### Example 1: Create a PrefixListResource.
```powershell
New-AzPaloAltoNetworksPrefixListLocalRulestack -Name azps-panpflr -LocalRulestackName azps-panlr -ResourceGroupName azps_test_group_pan -PrefixList "10.10.10.0/24" -Description "creating prefix list"
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panpflr Succeeded         azps_test_group_pan
```

Create a PrefixListResource.