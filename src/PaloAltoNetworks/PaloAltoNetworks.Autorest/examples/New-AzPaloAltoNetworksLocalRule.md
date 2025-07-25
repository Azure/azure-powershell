### Example 1: Create a LocalRulesResource.
```powershell
New-AzPaloAltoNetworksLocalRule -Priority 1 -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -RuleName azps-ruler -Description testing
```

```output
RuleName   RuleState Priority ResourceGroupName
--------   --------- -------- -----------------
azps-ruler ENABLED   1        azps_test_group_pan
```

Create a LocalRulesResource.