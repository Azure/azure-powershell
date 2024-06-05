### Example 1: Get the full endpoint URL for an event subscription of a system topic.
```powershell
Get-AzEventGridFullUrlForSystemTopicEventSubscription -EventSubscriptionName azps-evnetsub -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription of a system topic.

### Example 2: Get the full endpoint URL for an event subscription of a system topic.
```powershell
$sysTopic = Get-AzEventGridSystemTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-systopic
Get-AzEventGridFullUrlForSystemTopicEventSubscription -SystemTopicInputObject $sysTopic -EventSubscriptionName azps-evnetsub
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription of a system topic.