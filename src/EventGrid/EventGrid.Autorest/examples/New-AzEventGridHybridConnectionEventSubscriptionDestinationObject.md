### Example 1: Create an in-memory object for HybridConnectionEventSubscriptionDestination.
```powershell
$damObj = New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
$eventSubObj = Get-AzEventGridSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
New-AzEventGridHybridConnectionEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

```output
EndpointType
------------
HybridConnection
```

Create an in-memory object for HybridConnectionEventSubscriptionDestination.