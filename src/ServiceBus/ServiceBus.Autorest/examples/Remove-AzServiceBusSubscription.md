### Example 1: Remove a subscription from a ServiceBus topic
```powershell
Remove-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -Name mySubscription
```

Deletes a ServiceBus subscription `mySubscription` from ServiceBus topic `myTopic`.

