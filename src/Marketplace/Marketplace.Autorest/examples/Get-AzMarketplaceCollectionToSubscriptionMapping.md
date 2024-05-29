### Example 1: Map subscriptions to collections
```powershell
$res = Get-AzMarketplaceCollectionToSubscriptionMapping -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Payload @{SubscriptionId = "53425a7b-4ac1-4729-8340-e1da5046212c"}
$res.keys
```

```output
e58535dc-1be3-4d2c-904c-1f97984ebe5d
fdb889a1-cf3e-49f0-95b8-2bb012fa01f1
```

This command For a given subscriptions list, will return a map of collections and the related subscriptions from the supplied list.