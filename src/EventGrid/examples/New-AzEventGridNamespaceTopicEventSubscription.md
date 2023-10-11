### Example 1: Asynchronously Create an event subscription of a namespace topic with the specified parameters.
```powershell
$TimeSpan = New-TimeSpan -Hours 1 -Minutes 25
New-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -DeliveryConfigurationDeliveryMode Queue -QueueReceiveLockDurationInSecond 60 -QueueMaxDeliveryCount 4 -QueueEventTimeToLive $TimeSpan -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Asynchronously Create an event subscription of a namespace topic with the specified parameters.
Existing event subscriptions will be updated with this API.