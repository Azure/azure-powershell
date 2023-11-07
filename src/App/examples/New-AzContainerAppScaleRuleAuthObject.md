### Example 1: Create a ScaleRuleAuth object for ScaleRule.
```powershell
New-AzContainerAppScaleRuleAuthObject -SecretRef "redis-secret" -TriggerParameter "TriggerParameter"
```

```output
SecretRef    TriggerParameter
---------    ----------------
redis-secret TriggerParameter
```

Create a ScaleRuleAuth object for ScaleRule.