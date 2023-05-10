### Example 1: Remove a topic from a ServiceBus namespace
```powershell
Remove-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myTopic
```

Deletes a ServiceBus topic `myTopic` from ServiceBus namespace `myNamespace`.

