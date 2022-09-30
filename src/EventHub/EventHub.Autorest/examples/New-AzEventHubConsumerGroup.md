### Example 1: Create an EventHub ConsumerGroup
```powershell
New-AzEventHubConsumerGroup -Name myConsumerGroup -NamespaceName myNamespace -ResourceGroupName myResourceGroup -EventHubName myEventHub -UserMetadata "Test ConsumerGroup"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Test ConsumerGroup
```

Creates a new consumer group `myConsumerGroup` for EventHubs entity `myEventHub`.