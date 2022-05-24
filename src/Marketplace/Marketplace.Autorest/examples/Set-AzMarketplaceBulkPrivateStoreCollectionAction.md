### Example 1: Preforms bulk action on collections 
```powershell
PS C:\> Set-AzMarketplaceBulkPrivateStoreCollectionAction -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a -Payload @{Action = "EnableCollections"; CollectionId = "3ac32d8c-e888-4dc6-b4ff-be4d755af13a", "fdb889a1-cf3e-49f0-95b8-2bb012fa01f1" }

Failed Succeeded
------ ---------
{}     {DefaultCollection, test}
```
This command Preforms bulk action on collections 