### Example 1: Set rules on a collection
```powershell
$rule1 = @{
    Type = "PrivateProducts"
    Value = ""
}
$rule2 = @{
    Type = "TermsAndCondition"
    Value = ""
}
$rules = @($rule1, $rule2)

New-AzMarketplacePrivateStoreCollectionRule -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -Value $rules
```

Set rules for specific private store and collection.