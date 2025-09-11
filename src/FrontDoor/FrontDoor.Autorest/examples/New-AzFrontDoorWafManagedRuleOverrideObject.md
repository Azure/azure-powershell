### Example 1: Create PSAzureManagedRuleOverride Object for managed WAF rule group override object creation.
Create a managed rule override object for rule 942250 (which is in SQLI group).

```powershell
New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942250" -Action Log
```

```output
RuleId EnabledState Action
------ ------------ ------
942250      Enabled    Log
```

Create PSAzureManagedRuleOverride Object for managed WAF rule group override object creation.