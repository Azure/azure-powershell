### Example 1: Update an existing event subscription of a namespace topic.
```powershell
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.

### Example 2: Update an existing event subscription of a namespace topic.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -NamespaceInputObject $namespace -TopicName azps-topic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.

### Example 3: Update an existing event subscription of a namespace topic.
```powershell
$namespaceTopic = Get-AzEventGridNamespaceTopic -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -TopicInputObject $namespaceTopic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.