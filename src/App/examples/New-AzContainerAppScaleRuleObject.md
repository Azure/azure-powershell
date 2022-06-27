### Example 1: Create a ScaleRule object for ContainerApp.
```powershell
New-AzContainerAppScaleRuleObject -Name scaleRuleName -AzureQueueLength 30 -AzureQueueName azps_containerapp -CustomType "azure-servicebus"
```

```output
Name
----
scaleRuleName
```

Create a ScaleRule object for ContainerApp.