### Example 1: Start a job definition
```powershell
New-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myProject -Description "description"

New-AzStorageMoverAzStorageContainerEndpoint -Name myContainerEndpoint -ResourceGroupName myResourceGroup -BlobContainerName myContainer -StorageMoverName myStorageMover -StorageAccountResourceId myAccountResourceId
New-AzStorageMoverNfsEndpoint -Name myNfsEndpoint -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Host "x.x.x.x" -Export "/" -NfsVersion NFSv3 -Description "Description"

New-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -AgentName myAgent -SourceName myNfsEndpoint -TargetName myContainerEndpoint -CopyMode Additive
Start-AzStorageMoverJobDefinition -JobDefinitionName myJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroupName/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJobDefinition/jobRuns/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
```

This command starts a job definition.
