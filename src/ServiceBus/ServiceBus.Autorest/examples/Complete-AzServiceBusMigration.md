### Example 1: Complete migration from standard to premium servicebus namespace
```powershell
Complete-AzServiceBusMigration -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Completes migration to premium namespace. Start-AzServiceBusMigration must be used to configure migration before completing it.

