### Example 1: Update an existing event subscription for a topic.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridTopicEventSubscription -EventSubscriptionName azps-eventsub -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

Update an existing event subscription for a topic.