### Example 1: Get properties of a nested event subscription for a domain topic.
```powershell
Get-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 2: Get properties of a nested event subscription for a domain topic.
```powershell
Get-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 3: Get properties of a nested event subscription for a domain topic.
```powershell
$domainTopicObj = Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Get-AzEventGridDomainTopicEventSubscription -TopicInputObject $domainTopicObj -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 4: Get properties of a nested event subscription for a domain topic.
```powershell
$domainObj = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainTopicEventSubscription -DomainInputObject $domainObj -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.