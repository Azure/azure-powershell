### Example 1: Remove Disaster Recovery Config from a ServiceBus namespace
```powershell
Remove-AzServiceBusGeoDRConfiguration -Name myAlias -ResourceGroupName myResourceGroup -NamespaceName myPrimaryNamespace
```

Deletes alias `myAlias` from ServiceBus namespace `myPrimaryNamespace`.

