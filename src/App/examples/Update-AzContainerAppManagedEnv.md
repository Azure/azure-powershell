### Example 1: Update a managed environment.
```powershell
Update-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app -Tag @{"abc"="123"}
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

Update a managed environment.

### Example 2: Update a managed environment.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnv -InputObject $managedenv -Tag @{"abc"="123"}
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

Update a managed environment.