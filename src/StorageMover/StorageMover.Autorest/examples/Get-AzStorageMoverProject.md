### Example 1: Get all projects under a Storage mover 
```powershell
$projectList = Get-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
Description                  : My first project
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject1
Name                         : myProject1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:23:49 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:23:49 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/projects

Description                  : My second project
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject2
Name                         : myProject2
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:48 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:48 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/projects
```

This command gets all the projects under a Storage mover.

### Example 2: Get a specific project
```powershell
$projectList = Get-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myProject1
```

```output
Description                  : My first project
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject1
Name                         : myProject1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:23:49 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:23:49 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/projects
```

This command gets a specific project under a Storage mover.

