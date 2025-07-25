### Example 1: Check the availability of a ServiceBus namespace name
```powershell
Test-AzServiceBusName -NamespaceName myNamespace
```

```output
Message                                                                                                NameAvailable Reason
-------                                                                                                ------------- ------
The specified name is not available. For more information visit https://aka.ms/eventhubsarmexceptions.         False NameInUse
```

Checks the availability of namespace name `myNamespace`.

### Example 2: Check the availability of a ServiceBus Geo Disaster Recovery Alias
```powershell
Test-AzServiceBusName -NamespaceName myNamespace -ResourceGroupName myResourceGroup -AliasName myAlias
```

```output
Message                                                                                                NameAvailable Reason
-------                                                                                                ------------- ------
The specified name is not available. For more information visit https://aka.ms/eventhubsarmexceptions.         False NameInUse
```

Checks the availability of alias name `myAlias` on namespace `myNamepace`.
