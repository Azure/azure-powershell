### Example 1: Create RuleGroupOverride Object for WAF policy creation
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log

New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2
```

```output
Exclusion ManagedRuleOverride                                                                              RuleGroupName
--------- -------------------                                                                              -------------
          {{…                                                                                              SQLI
```

Create a RuleGroupOverride Object