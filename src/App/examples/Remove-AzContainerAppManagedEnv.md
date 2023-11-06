### Example 1: Delete a Container App ManagedEnv.
```powershell
Remove-AzContainerAppManagedEnv -Name azpsenv -ResourceGroupName azps_test_group_app
```

Delete a Container App ManagedEnv.

### Example 2: Delete a Container App ManagedEnv.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azpsenv -ResourceGroupName azps_test_group_app

Remove-AzContainerAppManagedEnv -InputObject $managedenv
```

Delete a Container App ManagedEnv.