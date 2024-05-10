### Example 1: Asynchronously updates a namespace with the specified parameters.
```powershell
Update-AzEventGridNamespace -Name azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicSpaceConfigurationState Enabled -Tag @{"abc"="123"}
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

Asynchronously updates a namespace with the specified parameters.

### Example 2: Asynchronously updates a namespace with the specified parameters.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridNamespace -InputObject $namespace -TopicSpaceConfigurationState Enabled -Tag @{"abc"="123"}
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

Asynchronously updates a namespace with the specified parameters.