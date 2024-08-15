### Example 1: Get properties of an event subscription of a partner topic.
```powershell
Get-AzEventGridPartnerTopic -ResourceGroupName azps_test_group_eventgrid
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a partner topic.

### Example 2: Get properties of an event subscription of a partner topic.
```powershell
Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a partner topic.

### Example 3: Get properties of an event subscription of a partner topic.
```powershell
$partnerTopicObj = Get-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid
Get-AzEventGridPartnerTopicEventSubscription -PartnerTopicInputObject $partnerTopicObj -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a partner topic.