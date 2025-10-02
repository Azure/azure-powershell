### Example 1: Create managed rule exclusion object for WAF managed rule sets, groups, or rules.
```powershell
New-AzFrontDoorWafManagedRuleExclusionObject -Variable QueryStringArgNames -Operator Equals -Selector "ParameterName"
```

```output
MatchVariable       SelectorMatchOperator Selector
-------------       --------------------- --------
QueryStringArgNames Equals                ParameterName
```

Create managed rule exclusion object for WAF managed rule sets, groups, or rules.