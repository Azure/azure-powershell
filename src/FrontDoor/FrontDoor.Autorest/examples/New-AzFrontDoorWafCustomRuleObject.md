### Example 1: Create CustomRule Object for WAF policy creation
```powershell
New-AzFrontDoorWafCustomRuleObject -Name "Rule1" -RuleType MatchRule -MatchCondition $matchCondition1 -Action Block -Priority 2
```

```output
Action                     : Block
EnabledState               : Enabled
GroupByCustomRule          :
MatchCondition             : {{
                               "selector": "Rules-Engine-Route-Forward",
                               "negateCondition": false,
                               "transforms": [ "LowerCase", "UpperCase" ]
                             }}
Name                       : Rule1
Priority                   : 2
RateLimitDurationInMinutes : 1
RateLimitThreshold         :
RuleType                   : MatchRule
```

Create a CustomRule Object