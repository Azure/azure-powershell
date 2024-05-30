### Example 1: Asynchronously creates a new event subscription or updates an existing event subscription based on the specified scope.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
New-AzEventGridSubscription -Name azps-eventsub -Scope "subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -Destination $obj -FilterIsSubjectCaseSensitive:$false
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub
```

Asynchronously creates a new event subscription or updates an existing event subscription based on the specified scope.

### Example 2: Asynchronously creates a new event subscription or updates an existing event subscription based on the specified scope.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
$topic = Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
New-AzEventGridSubscription -Name azps-eventsub -Scope $topic.Id -Destination $obj -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix"
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

Asynchronously creates a new event subscription or updates an existing event subscription based on the specified scope.