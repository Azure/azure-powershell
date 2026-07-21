### Example 1: Create a WAF managed rule set exception object
```powershell
$ruleScope = New-AzFrontDoorWafRuleScopeObject -RuleId 942100
$ruleGroupScope = New-AzFrontDoorWafRuleGroupScopeObject -RuleGroupName SQLI -RuleScope $ruleScope
$managedRuleSetScope = New-AzFrontDoorWafManagedRuleSetScopeObject -RuleSetType DefaultRuleSet -RuleSetVersion 1.0 -RuleGroupScope $ruleGroupScope
New-AzFrontDoorWafManagedRuleSetExceptionObject -MatchVariable RequestHeaderNames -SelectorMatchOperator Equals -Selector User-Agent -ValueMatchOperator Equals -MatchValue curl -Scope $managedRuleSetScope
```

```output
MatchVariable      Selector   ValueMatchOperator MatchValue Scope
-------------      --------   ------------------ ---------- -----
RequestHeaderNames User-Agent Equals             {curl}     {DefaultRuleSet}
```

Create a WAF managed rule set exception object for requests with a `User-Agent` header value of `curl`.
