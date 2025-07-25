### Example 1: Get the full endpoint URL for an event subscription for topic.
```powershell
Get-AzEventGridTopicEventSubscriptionFullUrl -ResourceGroupName azps_test_group_eventgrid -EventSubscriptionName azps-eventsub -TopicName azps-topic
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription for topic.

### Example 2: Get the full endpoint URL for an event subscription for topic.
```powershell
$topic = Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Get-AzEventGridTopicEventSubscriptionFullUrl -TopicInputObject $topic -EventSubscriptionName azps-eventsub
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription for topic.