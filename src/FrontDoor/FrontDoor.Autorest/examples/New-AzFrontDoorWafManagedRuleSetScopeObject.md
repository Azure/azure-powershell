### Example 1: Create a WAF managed rule set scope object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
$ruleGroupScope = New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType DefaultRuleSet -RuleSetVersion 1.0 -RuleGroupScope $ruleGroupScope
```

```output
RuleGroupScope RuleSetType    RuleSetVersion
-------------- -----------    --------------
{SQLI}         DefaultRuleSet 1.0
```

Create a WAF managed rule set scope object for the `DefaultRuleSet` rule set.
