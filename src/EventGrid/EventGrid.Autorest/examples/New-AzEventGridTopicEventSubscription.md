### Example 1: Asynchronously creates a new event subscription or updates an existing event subscription.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
New-AzEventGridTopicEventSubscription -EventSubscriptionName azps-eventsub -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

Asynchronously creates a new event subscription or updates an existing event subscription.
A usable EndpointUrl can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/custom-event-quickstart-powershell