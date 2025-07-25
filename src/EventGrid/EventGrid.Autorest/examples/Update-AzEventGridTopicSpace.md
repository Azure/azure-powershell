### Example 1: Create a topic space with the specified parameters.
```powershell
Update-AzEventGridTopicSpace -Name azps-topicspace -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicTemplate "filter1"
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

Create a topic space with the specified parameters.

### Example 2: Create a topic space with the specified parameters.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridTopicSpace -Name azps-topicspace -NamespaceInputObject $namespace -TopicTemplate "filter1"
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

Create a topic space with the specified parameters.

### Example 3: Create a topic space with the specified parameters.
```powershell
$topicspace = Get-AzEventGridTopicSpace -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-topicspace
Update-AzEventGridTopicSpace -InputObject $topicspace -TopicTemplate "filter1"
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

Create a topic space with the specified parameters.