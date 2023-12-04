### Example 1: Create a FqdnListLocalRulestackResource.
```powershell
New-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName azps-panlr -Name azps-panfllr -ResourceGroupName azps_test_group_pan -FqdnList "www.google.com"
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panfllr Succeeded         azps_test_group_pan
```

Create a FqdnListLocalRulestackResource.