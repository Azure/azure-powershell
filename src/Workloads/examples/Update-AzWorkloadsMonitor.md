### Example 1: Update AMS Monitor Instance
```powershell
Update-AzWorkloadsMonitor -MonitorName suha-160323-ams7 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -Tag @{name="tagValue"}
```

```output
Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams7 suha-0802-rg1     mrg-16037                             eastus2euap Succeeded
```

Update AMS Monitor Instance

### Example 2: Update AMS Monitor Instance by Id
```powershell
Update-AzWorkloadsMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-160323-ams7" -Tag @{name="tagValue"}
```

```output

Name             ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----             ----------------- ------------------------------------- --------    -----------------
suha-160323-ams7 suha-0802-rg1     mrg-16037                             eastus2euap Succeeded
```

Update AMS Monitor Instance by Arm Id

