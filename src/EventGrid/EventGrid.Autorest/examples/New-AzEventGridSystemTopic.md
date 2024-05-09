### Example 1: Asynchronously creates a new system topic with the specified parameters.
```powershell
New-AzEventGridSystemTopic -Name azps-systopic -ResourceGroupName azps_test_group_eventgrid -Location eastus -Source "/subscriptions/{subId}/resourcegroups/azps_test_group_eventgrid/providers/Microsoft.Storage/storageAccounts/azpssa" -TopicType "microsoft.storage.storageaccounts"
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

Asynchronously creates a new system topic with the specified parameters.