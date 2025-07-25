### Example 1: Add the administrator for root collection

```powershell
Add-AzPurviewAccountRootCollectionAdmin -AccountName test-pa -ResourceGroupName test-rg -ObjectId xxxxxxxx-5be9-4f43-abd2-04561777c8b0
```

Add the administrator for root collection associated with the account named 'test-pa'.

### Example 2: Add the administrator for root collection by InputObject
```powershell
$got = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
Add-AzPurviewAccountRootCollectionAdmin -InputObject $got -ObjectId xxxxxxxx-5be9-4f43-abd2-04561777c8b0
```

Add the administrator for root collection associated with the account named 'test-pa' by InputObject.

