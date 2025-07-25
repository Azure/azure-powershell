### Example 1: Update an existing event subscription of a partner topic.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName azps-eventsubname -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a partner topic.