### Example 1: Reset counters.
```powershell
Reset-AzPaloAltoNetworksLocalRuleCounter -LocalRulestackName azps-panlr -ResourceGroupName azps_test_group_pan -Priority 1
```

```output
FirewallName Priority RuleListName RuleName                RuleStackName
------------ -------- ------------ --------                -------------
             1        azps-ruler   cloud-ngfw-default-rule azps-panlr
```

Reset counters.