### Example 1: Update an existing event subscription for a domain topic.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -EventSubscriptionName azps-eventsubname -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription for a domain topic.