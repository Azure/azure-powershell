### Example 1: List contains relationships in a subscription
```powershell
Get-AzRelationshipsContainsRelationship -SubscriptionId "00000000-0000-0000-0000-000000000001"
```

Lists the contains relationships in the specified subscription.

### Example 2: List contains relationships in a resource group
```powershell
Get-AzRelationshipsContainsRelationship -SubscriptionId "00000000-0000-0000-0000-000000000001" -ResourceGroupName "myRG"
```

Lists the contains relationships in the specified resource group.

