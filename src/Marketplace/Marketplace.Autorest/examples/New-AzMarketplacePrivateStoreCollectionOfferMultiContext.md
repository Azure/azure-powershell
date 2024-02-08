### Example 1: Upsert an offer with multiple contexts
```powershell
$plan1 = @{
    context = "1f58b5dd-313c-42ed-84fc-f1e351bba7fb"
    planId = "plan1"
}

$plan2 = @{
    context = "ab3de7bc-7a6e-4e9f-a34a-f6922df453e4"
    planId = "plan2"
}

$plans = @($plan1,$plan2)

New-AzMarketplacePrivateStoreCollectionOfferMultiContext -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId test_pmc2pc1.vm_4plans -PlansContext $plans
```

Upsert an offer with multiple context details.