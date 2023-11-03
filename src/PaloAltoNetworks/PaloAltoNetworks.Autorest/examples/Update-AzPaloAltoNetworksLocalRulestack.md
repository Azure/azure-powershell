### Example 1: Update a LocalRulestackResource.
```powershell
Update-AzPaloAltoNetworksLocalRulestack -Name azps-panlr -ResourceGroupName azps_test_group_pan -Tag @{"abc"="123"}
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Update a LocalRulestackResource.