### Example 1: Asynchronously updates a system topic with the specified parameters.
```powershell
Update-AzEventGridSystemTopic -Name azps-systopic -ResourceGroupName azps_test_group_eventgrid -Tag @{"abc"="123"}
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

Asynchronously updates a system topic with the specified parameters.

### Example 2: Asynchronously updates a system topic with the specified parameters.
```powershell
$systemtopic = Get-AzEventGridSystemTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-systopic
Update-AzEventGridSystemTopic -InputObject $systemtopic -Tag @{"abc"="123"}
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

Asynchronously updates a system topic with the specified parameters.