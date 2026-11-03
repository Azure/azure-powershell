### Example 1: Reconcile the running job of a job definition
```powershell
Invoke-AzStorageMoverReconcileJobDefinition -JobDefinitionName myJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
JobRunResourceId
----------------
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJobDefinition/jobRuns/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
```

This command reconciles the job run that is currently running for a job definition and returns the resource ID of that job run.
