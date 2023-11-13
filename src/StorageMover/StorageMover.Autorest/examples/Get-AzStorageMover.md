### Example 1: Get all Storage movers in a subcription
```powershell
 Get-AzStorageMover
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers

Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup2/providers/Microsoft.StorageMover/storageMovers/myStorageMover2
Location                     : eastus
Name                         : myStorageMover2
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets all the Storage movers in a subscription.

### Example 2: Get all Storage movers in a resource group
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets all the Storage movers in a resource group. 

### Example 2: Get a specific Storage mover
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover1
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets a specific Storage mover.

