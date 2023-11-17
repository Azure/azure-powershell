### Example 1: Create storage blob destination object
```powershell
New-AzStorageBlobDestinationObject -ContainerName "my-logs" -StorageAccountResourceId /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/sa-rg/providers/Microsoft.Storage/storageAccounts/rightregion:westus:sa-name1 -Name storageAccountDestination1
```

```output
ContainerName Name                       StorageAccountResourceId
------------- ----                       ------------------------
my-logs       storageAccountDestination1 /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/sa-rg/providers/Microsoft.Storage/storageAccounts/rightregion:westus:sa-name1
```

This command creates a storage blob destination object.
