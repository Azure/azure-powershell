### Example 1: Delete a Container App ManagedEnvCert.
```powershell
Remove-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert
```

Delete a Container App ManagedEnvCert.

### Example 2: Delete a Container App ManagedEnvCert.
```powershell
$managedenvcert = Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert

Remove-AzContainerAppManagedEnvCert -InputObject $managedenvcert
```

Delete a Container App ManagedEnvCert.

### Example 3: Delete a Container App ManagedEnvCert.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Remove-AzContainerAppManagedEnvCert -ManagedEnvironmentInputObject $managedenv -Name azps-env-cert
```

Delete a Container App ManagedEnvCert.