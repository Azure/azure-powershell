### Example 1: Delete a Container App ManagedEnvStorage.
```powershell
Remove-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa
```

Delete a Container App ManagedEnvStorage.

### Example 2: Delete a Container App ManagedEnvStorage.
```powershell
$managedenvstorage = Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa

Remove-AzContainerAppManagedEnvStorage -InputObject $managedenvstorage
```

Delete a Container App ManagedEnvStorage.

### Example 3: Delete a Container App ManagedEnvStorage.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Remove-AzContainerAppManagedEnvStorage -ManagedEnvironmentInputObject $managedenv -Name azpstestsa
```

Delete a Container App ManagedEnvStorage.