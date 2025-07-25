### Example 1: Asynchronously Create an event subscription with the specified parameters.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net"
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName azps-evnetsub -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```

```output
Name          ResourceGroupName
----          -----------------
azps-evnetsub azps_test_group_eventgrid
```

Asynchronously Create an event subscription with the specified parameters.
Existing event subscriptions will be updated with this API.