### Example 1: Update an expansion job
```powershell
Update-AzStorageCacheExpansionJob -AmlFilesystemName 'fs1' -Name 'expansionjob1' -ResourceGroupName 'scgroup' -Tag @{'Dept' = 'ContosoFinance'}
```

```output
Name                Location      ProvisioningState NewStorageCapacityTiB StatusState
----                --------      ----------------- --------------------- -----------
expansionjob1       eastus        Succeeded         16                    Completed
```

Updates the tags of the specified expansion job.

