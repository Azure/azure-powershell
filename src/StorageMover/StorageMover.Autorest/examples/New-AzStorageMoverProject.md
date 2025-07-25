### Example 1: Create a project
```powershell
New-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myProject -Description "description"
```

```output
Description                  : description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storage
                               Movers/myStorageMover/projects/myProject
Name                         : myProject
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 7/26/2022 5:50:53 AM
SystemDataCreatedBy          : xxxxxxxxxxxxxxxxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/26/2022 5:50:53 AM
SystemDataLastModifiedBy     : xxxxxxxxxxxxxxxxxxxxxxxx
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/projects
```

This command creates a project for a Storage mover.


