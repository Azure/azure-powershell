### Example 1: Create managed rule exclusion object for WAF managed rule sets, groups, or rules.
```powershell
New-AzFrontDoorWafManagedRuleExclusionObject -Variable QueryStringArgNames -Operator Equals -Selector "ParameterName"
```

```output
Operator Selector      Variable
-------- --------      --------
Equals   ParameterName QueryStringArgNames
```

Create managed rule exclusion object for WAF managed rule sets, groups, or rules.