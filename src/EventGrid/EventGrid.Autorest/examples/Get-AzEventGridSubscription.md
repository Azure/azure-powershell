### Example 1: Get properties of an event subscription.
```powershell
Get-AzEventGridSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription.

### Example 2: Get properties of an event subscription.
```powershell
Get-AzEventGridSubscription -Name azps-eventsub -Scope "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/topics/azps-topic"
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub azps_test_group_eventgrid
```

Get properties of an event subscription.