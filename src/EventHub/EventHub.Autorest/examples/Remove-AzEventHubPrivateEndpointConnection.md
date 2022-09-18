### Example 1: Remove a private endpoint connection from an eventhub namespace
```powershell
Remove-AzEventHubPrivateEndpointConnection -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name 00000000000
```

Deletes private endpoint connection `00000000000` from an event hub namespace `myNamespace`.
