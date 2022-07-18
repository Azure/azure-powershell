### Example 1: Get all job definitions under a Storage mover
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover 
```

```output
Name
----
myJob1
myJob2
```

This command gets all the job definitions under a specific Storage mover.

### Example 2: Get a specific job definition
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myJob1
```

```output
Name
----
myJob1
```

This command gets a specific job definition. 

