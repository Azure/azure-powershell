### Example 1 

```powershell
New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
```

```output
RuleId EnabledState Action
------ ------------ ------
942250      Enabled    Log
```

Create a managed rule override object for rule 942250 (which is in SQLI group).