### Example 1: Get all projects under a Storage mover 
```powershell
$projectList = Get-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
Name
----
myProject1
myProject2
```

This command gets all the projects under a Storage mover.

### Example 2: Get a specific project
```powershell
$projectList = Get-AzStorageMoverProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myProject
```

```output
Name
----
myProject
```

This command gets a specific project under a Storage mover.

