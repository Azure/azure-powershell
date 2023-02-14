### Example 1: ManagedDisk object 
```powershell
<<<<<<< HEAD
New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
```

```output
DataAccountType SharePassword ResourceGroupId                                                StagingStorageAccountId                                                                                                      
--------------- ------------- ---------------                                                -----------------------                                                                                                      
ManagedDisk                   /subscriptions/SubscriptionId/resourceGroups/resourceGroupName /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName
```
=======
PS C:\> $managedDiskAccount=New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
```

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Creates a in-memory managed disk object 

