### Example 1: List properties of event subscription of a namespace topic.
```powershell
Get-AzEventGridNamespaceTopicEventSubscription -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

List properties of event subscription of a namespace topic.

### Example 2: Get properties of an event subscription of a namespace topic.
```powershell
Get-AzEventGridNamespaceTopicEventSubscription -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a namespace topic.

### Example 3: Get properties of an event subscription of a namespace topic.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridNamespaceTopicEventSubscription -NamespaceInputObject $namespace -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a namespace topic.