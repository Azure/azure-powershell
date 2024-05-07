### Example 1: Asynchronously creates a new event subscription or updates an existing event subscription.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
New-AzEventGridDomainEventSubscription -DomainName azps-domain -EventSubscriptionName azps-eventsubname -ResourceGroupName azps_test_group_eventgrid -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Asynchronously creates a new event subscription or updates an existing event subscription.