### Example 1: Get all job runs with a job definition
```powershell
Get-AzStorageMoverJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
Name
----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
```

This command gets all the job runs under a specific job definition 

### Example 2: Get a specific job run
```powershell
Get-AzStorageMoverJobRun -Name myJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
Name
----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets a specific job run. 
