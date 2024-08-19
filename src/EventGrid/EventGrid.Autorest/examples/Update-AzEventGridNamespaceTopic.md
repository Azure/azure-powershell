### Example 1: Asynchronously updates a namespace topic with the specified parameters.
```powershell
Update-AzEventGridNamespaceTopic -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventRetentionInDay 1
```

```output
Name       ResourceGroupName
----       -----------------
azps-topic azps_test_group_eventgrid
```

Asynchronously updates a namespace topic with the specified parameters.

### Example 2: Asynchronously updates a namespace topic with the specified parameters.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridNamespaceTopic -NamespaceInputObject $namespace -TopicName azps-topic -EventRetentionInDay 1
```

```output
Name       ResourceGroupName
----       -----------------
azps-topic azps_test_group_eventgrid
```

Asynchronously updates a namespace topic with the specified parameters.

### Example 3: Asynchronously updates a namespace topic with the specified parameters.
```powershell
$namespaceTopic = Get-AzEventGridNamespaceTopic -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
Update-AzEventGridNamespaceTopic -InputObject $namespaceTopic -EventRetentionInDay 1
```

```output
Name       ResourceGroupName
----       -----------------
azps-topic azps_test_group_eventgrid
```

Asynchronously updates a namespace topic with the specified parameters.