### Example 1
```powershell
$LogScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
New-AzFrontDoorWafLogScrubbingSettingObject -State Enabled -ScrubbingRule @($LogScrubbingRule)
```

Need to create a LogScrubbingRule object before using.