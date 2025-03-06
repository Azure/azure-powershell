### Example 1
```powershell
New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
```

This obejct is a parameter for LogscrubbingSetting