### Example 1: Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.
```powershell
$damObj = New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
$eventSubObj = Get-AzEventGridSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
New-AzEventGridServiceBusTopicEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

```output
EndpointType
------------
ServiceBusTopic
```

Create an in-memory object for ServiceBusTopicEventSubscriptionDestination.