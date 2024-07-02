### Example 1: List properties of topic.
```powershell
Get-AzEventGridTopic
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

List properties of topic.

### Example 2: List properties of topic.
```powershell
Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

List properties of topic.

### Example 3: Get properties of a topic.
```powershell
Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
```

```output
Location Name       Kind  ResourceGroupName
-------- ----       ----  -----------------
eastus   azps-topic Azure azps_test_group_eventgrid
```

Get properties of a topic.