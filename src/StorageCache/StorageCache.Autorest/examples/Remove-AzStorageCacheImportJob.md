### Example 1: Remove an import job
```powershell
Remove-AzStorageCacheImportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myimportjob' -ResourceGroupName 'myresourcegroup' -Confirm:$false
```

Removes the specified import job from the AML filesystem.

