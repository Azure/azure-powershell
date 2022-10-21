### Example 1: Get an EventHub consumer group
```powershell
Get-AzEventHubConsumerGroup -Name '$Default' -NamespaceName myNamespace -ResourceGroupName myResourceGroup -EventHubName myEventHub
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/$Default
Location                     : australiaeast
Name                         : $Default
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 :
```

Gets default consumer group of eventhub entity `myEventHub`.

### Example 2: List all consumer groups in an EventHub entity
```powershell
Get-AzEventHubConsumerGroup -NamespaceName myNamespace -ResourceGroupName myResourceGroup -EventHubName myEventHub
```

Lists all consumer groups in entity `myEventHub` from namespace `myNamespace`.