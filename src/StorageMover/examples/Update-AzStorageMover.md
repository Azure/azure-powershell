### Example 1: Update a Storage mover
```powershell
Update-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover -Description "Update description"
```

```output
Description                  : Update description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover
Location                     : eastus
Name                         : myStorageMover
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 3:32:45 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/3/2022 3:10:31 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command updates the description of a Storage mover.
