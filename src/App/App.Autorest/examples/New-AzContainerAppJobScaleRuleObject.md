### Example 1: Create an in-memory object for JobScaleRule.
```powershell
$scaleRuleAuth = New-AzContainerAppScaleRuleAuthObject -SecretRef "redis-secret" -TriggerParameter "TriggerParameter"
New-AzContainerAppJobScaleRuleObject -Auth $scaleRuleAuth -Name azps-job-scale -Type azure-servicebus
```

```output
Name
----
azps-job-scale
```

Create an in-memory object for JobScaleRule.