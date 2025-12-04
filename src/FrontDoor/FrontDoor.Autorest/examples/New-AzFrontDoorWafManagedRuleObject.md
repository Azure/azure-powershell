### Example 1: Create ManagedRule Object for WAF policy creation
```powershell
$ruleOverride1 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
$ruleOverride2 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942251" -Action Log
$override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName SQLI -ManagedRuleOverride $ruleOverride1,$ruleOverride2

$ruleOverride3 = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "941280" -Action Log
$override2 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName XSS -ManagedRuleOverride $ruleOverride3

New-AzFrontDoorWafManagedRuleObject -Type DefaultRuleSet -Version "preview-0.1" -RuleGroupOverride $override1,$override2
```

```output
Exclusion         :
RuleGroupOverride : {{
                      "ruleGroupName": "SQLI",
                      "rules": [
                        {
                          "ruleId": "942250",
                          "action": "Log"
                        },
                        {
                          "ruleId": "942251",
                          "action": "Log"
                        }
                      ]
                    }, {
                      "ruleGroupName": "XSS",
                      "rules": [
                        {
                          "ruleId": "941280",
                          "action": "Log"
                        }
                      ]
                    }}
RuleSetAction     :
Type              : DefaultRuleSet
Version           : preview-0.1
```

Create a ManagedRule Object