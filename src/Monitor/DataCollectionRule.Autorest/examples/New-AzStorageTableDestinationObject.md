### Example 1: Create storage table destination object
```powershell
New-AzStorageTableDestinationObject -TableName table1 -StorageAccountResourceId /subscriptions/ee63c5dc-9b88-42e3-8070-944a5226aea3/resourceGroups/rightregion/providers/Microsoft.Storage/storageAccounts/bar1 -Name storageAccountDestination2
```

```output
Name                       StorageAccountResourceId                                                                                                        TableName
----                       ------------------------                                                                                                        ---------
storageAccountDestination2 /subscriptions/ee63c5dc-9b88-42e3-8070-944a5226aea3/resourceGroups/rightregion/providers/Microsoft.Storage/storageAccounts/bar1 table1
```

This command creates a storage table destination object.
