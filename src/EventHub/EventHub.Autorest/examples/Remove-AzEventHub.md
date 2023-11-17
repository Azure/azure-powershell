### Example 1: Remove an EventHub entity from an EventHub Namespace
```powershell
Remove-AzEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myEventHub
```

Deletes event hub entity `myEventHub` from namespace `myNamespace`.
