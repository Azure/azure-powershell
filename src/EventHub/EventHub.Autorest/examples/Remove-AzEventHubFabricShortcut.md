### Example 1: Remove a Fabric shortcut from an EventHub entity
```powershell
Remove-AzEventHubFabricShortcut -ResourceGroupName contoso-rg -NamespaceName contoso-eventhub -EventHubName orders -Name orders-shortcut
```

Removes the Fabric shortcut `orders-shortcut` from the EventHub entity `orders` in namespace `contoso-eventhub`. This cmdlet does not return any output.

