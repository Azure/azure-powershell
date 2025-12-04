### Example 1: Create LogScrubbingRule object for LogScrubbingSetting
```powershell
New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
```

```output
MatchVariable      Selector SelectorMatchOperator State
-------------      -------- --------------------- -----
RequestHeaderNames          EqualsAny             Enabled
```

This object is a parameter for LogscrubbingSetting