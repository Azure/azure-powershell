### Example 1: Asynchronously Create a new namespace with the specified parameters.
```powershell
New-AzEventGridNamespace -Name azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Location eastus -TopicSpaceConfigurationState Enabled
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

Asynchronously Create a new namespace with the specified parameters.