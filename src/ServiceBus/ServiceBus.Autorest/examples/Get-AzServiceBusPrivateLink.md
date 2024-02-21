### Example 1: Get private links associated with a ServiceBus namespace
```powershell
Get-AzServiceBusPrivateLink -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
GroupId          : namespace
Id               : subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/privateLinkResources/namespace
Name             : namespace
RequiredMember   : {namespace}
RequiredZoneName : {privatelink.servicebus.windows.net}
Type             : Microsoft.ServiceBus/namespaces/privateLinkResources
```

Gets private link resources available on ServiceBus namespace `myNamespace`.
