### Example 1: Get the full endpoint URL for a nested event subscription for domain topic.
```powershell
Get-AzEventGridDomainTopicEventSubscriptionFullUrl -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for a nested event subscription for domain topic.

### Example 2: Get the full endpoint URL for a nested event subscription for domain topic.
```powershell
$domainObj = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainTopicEventSubscriptionFullUrl -DomainInputObject $domainObj -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for a nested event subscription for domain topic.

### Example 3: Get the full endpoint URL for a nested event subscription for domain topic.
```powershell
$domainTopicObj = Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Get-AzEventGridDomainTopicEventSubscriptionFullUrl -TopicInputObject $domainTopicObj -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for a nested event subscription for domain topic.