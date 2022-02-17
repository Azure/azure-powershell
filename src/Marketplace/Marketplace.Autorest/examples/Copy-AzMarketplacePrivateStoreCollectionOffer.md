### Example 1: Copy offers from source collection to target collections.
```powershell
PS C:\> $payload = @{OfferIdsList = "aumatics.azure_managedservices"; Operation = "Copy"; TargetCollection = "3ac32d8c-e888-4dc6-b4ff-be4d755af13a"}
PS C:\>  Copy-AzMarketplacePrivateStoreCollectionOffer -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -Payload $payload

Failed Succeeded
------ ---------
{}     {DefaultCollection}
```

This command copy offers from source collection to target collections.
