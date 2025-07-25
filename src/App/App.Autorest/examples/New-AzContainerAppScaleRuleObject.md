### Example 1: Create an in-memory object for ScaleRule.
```powershell
New-AzContainerAppScaleRuleObject -Name "httpscalingrule" -CustomType "http" -AzureQueueLength 30 -AzureQueueName azps-containerapp
```

```output
Name
----
httpscalingrule
```

Create an in-memory object for ScaleRule.