### Example 1: Get all protected azure disk backup instance in a given subscription
```powershell
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk

Name                                                                                                                   Type
----                                                                                                                   ----
ContosoDemoVM_DataDisk_0-ContosoDemoVM_DataDisk_0-5f7b2a1f-f1ab-4abe-aadf-e7dc48238157                                 microsoft.dataprotection/backupvaults/backupinstance
ContosoDemoVM_OsDisk_1_84b542ec38a447cea-ContosoDemoVM_OsDisk_1_84b542ec38a447cea-9bdcbd90-3555-4651-93b8-8265e1b5c07a microsoft.dataprotection/backupvaults/backupinstance
DataDisk1-DataDisk1-0c71e6bf-9289-483c-8e27-aa6c0df60078                                                               microsoft.dataprotection/backupvaults/backupinstance
rraj-StandardHDD-rraj-StandardHDD-85d0a3f4-7fa8-46c7-bf83-0dee27eac08e                                                 microsoft.dataprotection/backupvaults/backupinstance
sakaarhotfixtest_disk1_86d713f7b80e493b9-sakaarhotfixtest_disk1_86d713f7b80e493b9-be214c89-c07d-41f0-8362-b78d58d5506f microsoft.dataprotection/backupvaults/backupinstance
pracdisk-pracdisk-643fac7d-0816-4056-8908-d0ef8b63b047                                                                 microsoft.dataprotection/backupvaults/backupinstance
test1-test1-59f95871-de81-4051-95e7-ee6c4e5b30e0                                                                       microsoft.dataprotection/backupvaults/backupinstance
anubhwus-test-anubhwus-test-5fe6ce14-fbd2-4641-80d0-f8f8b254601d                                                       microsoft.dataprotection/backupvaults/backupinstance
```

This command gets all protected azure disk backup instance in a given subscription

### Example 2: Get all protected azure disk backup instance in a given resource group list
```powershell
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk -ResourceGroup @("sarath-rg", "sarath-rg2")

Name                                                           Type                                                  BackupInstanceName
----                                                           ----                                                  ------------------
sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea74df26d4a8 microsoft.dataprotection/backupvaults/backupinstances sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea7
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166     microsoft.dataprotection/backupvaults/backupinstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e59
sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6bad4305a   microsoft.dataprotection/backupvaults/backupinstances sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6b
```

This commands gets all protected azure disk backup instance in a given set of resource groups

### Example 3: Get all protected azure disk backup instance in a given resource group list with protection state 'ProtectionConfigured'
```powershell
PS C:\> Search-AzDataProtectionBackupInstanceInAzGraph -Subscription "xxxx-xxx-xxx" -DatasourceType AzureDisk -ResourceGroup @("sarath-rg", "sarath-rg2") -ProtectionStatus  ProtectionConfigured

Name                                                           Type                                                  BackupInstanceName
----                                                           ----                                                  ------------------
sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea74df26d4a8 microsoft.dataprotection/backupvaults/backupinstances sarath-disk3-sarath-disk3-dbb8c2d0-bdbf-448c-9664-ea7
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166     microsoft.dataprotection/backupvaults/backupinstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e59
sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6bad4305a   microsoft.dataprotection/backupvaults/backupinstances sarathdisk2-sarathdisk2-b0bf31ab-c9c5-407f-98a2-3ad6b
```

This commands gets all protected azure disk backup instance in a given set of resource groups with protection status as ProtectionConfigured

