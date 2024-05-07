### Example 1: Get the full endpoint URL for an event subscription of a partner topic.
```powershell
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroupName azps_test_group_eventgrid -PartnerTopicName default -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for an event subscription of a partner topic.

### Example 2: Get the full endpoint URL for an event subscription of a partner topic.
```powershell
$partnerTopicObj = Get-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid
Get-AzEventGridFullUrlForPartnerTopicEventSubscription -PartnerTopicInputObject $partnerTopicObj -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for an event subscription of a partner topic.