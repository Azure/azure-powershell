### Example 1: List properties of event subscription of a topic.
```powershell
Get-AzEventGridTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

List properties of event subscription of a topic.

### Example 2: Get properties of an event subscription of a topic.
```powershell
Get-AzEventGridTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventSubscriptionName azps-eventsub
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

Get properties of an event subscription of a topic.