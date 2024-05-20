### Example 1: List properties of topic space.
```powershell
Get-AzEventGridTopicSpace -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

List properties of topic space.

### Example 2: List properties of topic space.
```powershell
Get-AzEventGridTopicSpace -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-topicspace
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

List properties of topic space.

### Example 3: Get properties of a topic space.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridTopicSpace -NamespaceInputObject $namespace -Name azps-topicspace
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

Get properties of a topic space.