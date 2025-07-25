### Example 1: Stop a job definition
```powershell
Stop-AzStorageMoverJobDefinition -JobDefinitionName myJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJobDefinition/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
```

This command stops a job definition.
