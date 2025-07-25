### Example 1: Remove a rule from a ServiceBus subscription
```powershell
Remove-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription -Name myRule
```

Deletes a ServiceBus rule `myRule` from ServiceBus subscription `mySubscription`.

