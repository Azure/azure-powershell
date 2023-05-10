### Example 1: Delete storage for a managedEnvironment.
```powershell
Remove-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp -StorageName azpstestsa
```

Delete storage for a managedEnvironment.

### Example 2: Delete storage for a managedEnvironment.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp -StorageName azpstestsa | Remove-AzContainerAppManagedEnvStorage
```

Delete storage for a managedEnvironment.