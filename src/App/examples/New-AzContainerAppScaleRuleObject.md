### Example 1: Create a ScaleRule object for ContainerApp.
```powershell
$scaleRule = @()
$scaleRule += New-AzContainerAppScaleRuleObject -Name scaleRuleName1 -AzureQueueLength 30 -AzureQueueName azps_containerapp -CustomType "azure-servicebus"
$scaleRule += New-AzContainerAppScaleRuleObject -Name scaleRuleName2 -AzureQueueLength 30 -AzureQueueName azps_containerapp -CustomType "azure-servicebus"
```

```output
Name
----
scaleRuleName
```

Create a ScaleRule object for ContainerApp.
The ScaleRule object as value of the `ScaleRule` parameter in the cmdlet `New-AzContainerApp`.