### Example 1: Remove an EventHub consumer group
```powershell
Remove-AzEventHubConsumerGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myConsumerGroup
```

Deletes consumer group `myConsumerGroup` from EventHub entity `myEventHub` on namespace `myNamespace`.

