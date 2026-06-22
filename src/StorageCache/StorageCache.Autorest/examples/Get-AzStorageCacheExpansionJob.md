### Example 1: List expansion jobs by AML file system
```powershell
Get-AzStorageCacheExpansionJob -AmlFilesystemName 'fs1' -ResourceGroupName 'scgroup'
```

Lists all expansion jobs for the specified AML file system.

### Example 2: Get a specific expansion job
```powershell
Get-AzStorageCacheExpansionJob -AmlFilesystemName 'fs1' -Name 'expansionjob1' -ResourceGroupName 'scgroup'
```

Gets the specified expansion job by name.

