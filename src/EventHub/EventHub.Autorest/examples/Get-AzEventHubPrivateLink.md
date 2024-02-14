### Example 1: Get private links associated with an EventHub namespace
```powershell
Get-AzEventHubPrivateLink -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

```output
GroupId          : namespace
Id               : subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/privateLinkResources/namespace
Name             : namespace
RequiredMember   : {namespace}
RequiredZoneName : {privatelink.servicebus.windows.net}
Type             : Microsoft.EventHub/namespaces/privateLinkResources
```

Gets private link resources available on EventHubs namespace `myNamespace`.
