### Example 1: List LocalRulesResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksLocalRule -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
RuleName   RuleState Priority ResourceGroupName
--------   --------- -------- -----------------
azps-ruler ENABLED   1        azps_test_group_pan
```

List LocalRulesResource by LocalRulestackName.

### Example 2: Get a LocalRulesResource by priority.
```powershell
Get-AzPaloAltoNetworksLocalRule -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Priority 1
```

```output
RuleName   RuleState Priority ResourceGroupName
--------   --------- -------- -----------------
azps-ruler ENABLED   1        azps_test_group_pan
```

Get a LocalRulesResource by priority.