### Example 1: Update EventHub Consumer Group
```powershell
Set-AzEventHubConsumerGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myConsumerGroup -UserMetadata "Example Metadata"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Example Metadata
```

Updates consumer group `myConsumerGroup` created under EventHub entity `myEventHub`.

### Example 2: Update EventHub Consumer Group using InputObject parameter set
```powershell
$consumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myConsumerGroup
Set-AzEventHubConsumerGroup -InputObject $consumerGroup -UserMetadata "Example Metadata"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Example Metadata
```

Updates consumer group `myConsumerGroup` created under EventHub entity `myEventHub`.

