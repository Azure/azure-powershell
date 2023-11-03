### Example 1: ManagedDisk object 
```powershell
New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
```

```output
DataAccountType SharePassword ResourceGroupId                                                StagingStorageAccountId                                                                                                      
--------------- ------------- ---------------                                                -----------------------                                                                                                      
ManagedDisk                   /subscriptions/SubscriptionId/resourceGroups/resourceGroupName /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName
```
Creates a in-memory managed disk object 

