### Example 1: Remove a queue from a ServiceBus namespace
```powershell
Remove-AzServiceBusQueue -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myQueue
```

Deletes a ServiceBus queue `myQueue` from ServiceBus namespace `myNamespace`.

