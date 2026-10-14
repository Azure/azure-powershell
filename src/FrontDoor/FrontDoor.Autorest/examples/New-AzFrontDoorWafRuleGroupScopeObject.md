### Example 1: Create a WAF managed rule group scope object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
```

```output
RuleGroupName RuleScope
------------- ---------
SQLI          {942100}
```

Create a WAF managed rule group scope object for the `SQLI` rule group and rule `942100`.
