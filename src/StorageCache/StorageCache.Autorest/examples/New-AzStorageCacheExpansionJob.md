### Example 1: Create an expansion job
```powershell
New-AzStorageCacheExpansionJob -AmlFilesystemName 'fs1' -Name 'expansionjob1' -ResourceGroupName 'scgroup' -Location 'eastus' -NewStorageCapacityTiB 16
```

Creates a new expansion job for the specified AML file system.

```output
Name                Location      ProvisioningState NewStorageCapacityTiB StatusState
----                --------      ----------------- --------------------- -----------
expansionjob1       eastus        Succeeded         16                    Completed
```

Creates a new expansion job to expand the AML file system storage capacity to 16 TiB.

