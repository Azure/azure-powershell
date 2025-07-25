### Example 1: List properties of system topic.
```powershell
Get-AzEventGridSystemTopic
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

List properties of system topic.

### Example 2: List properties of system topic.
```powershell
Get-AzEventGridSystemTopic -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

List properties of system topic.

### Example 3: Get properties of a system topic.
```powershell
Get-AzEventGridSystemTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-systopic
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   azps-systopic azps_test_group_eventgrid
```

Get properties of a system topic.