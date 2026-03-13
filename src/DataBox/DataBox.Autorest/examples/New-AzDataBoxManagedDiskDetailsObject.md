### Example 1: ManagedDisk object 
```powershell
New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName"
```

```output
DataAccountType ResourceGroupId                                                SharePassword StagingStorageAccountId
--------------- ---------------                                                ------------- -----------------------
ManagedDisk     /subscriptions/SubscriptionId/resourceGroups/resourceGroupName               /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/st
```
Creates a in-memory managed disk object 