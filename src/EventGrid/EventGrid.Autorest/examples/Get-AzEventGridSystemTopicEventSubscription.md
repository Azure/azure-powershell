### Example 1: Get an event subscription.
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic
```

```output
Name          ResourceGroupName
----          -----------------
azps-evnetsub azps_test_group_eventgrid
```

Get an event subscription.

### Example 2: Get an event subscription.
```powershell
Get-AzEventGridSystemTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -EventSubscriptionName azps-evnetsub
```

```output
Name          ResourceGroupName
----          -----------------
azps-evnetsub azps_test_group_eventgrid
```

Get an event subscription.