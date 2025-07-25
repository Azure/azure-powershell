### Example 1: Create a Storage mover
```powershell
New-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover -Location eastus -Description "Description"
```

```output
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storage
                               Movers/myStorageMover
Location                     : eastus
Name                         : myStorageMover
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 7/26/2022 5:49:02 AM
SystemDataCreatedBy          : xxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/26/2022 5:49:02 AM
SystemDataLastModifiedBy     : xxxxxxxxxx
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command creates a Storage mover for a resource group.


