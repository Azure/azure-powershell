### Example 1: Create a ScaleRuleAuth object for ScaleRule.
```powershell
New-AzContainerAppScaleRuleAuthObject -SecretRef "facebook-secret" -TriggerParameter "TriggerParameter"
```

```output
SecretRef       TriggerParameter
---------       ----------------
facebook-secret TriggerParameter
```

Create a ScaleRuleAuth object for ScaleRule.