### Example 1: Delete a Dapr Component from a Managed Environment.
```powershell
Remove-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-dapr
```

Delete a Dapr Component from a Managed Environment.

### Example 2: Delete a Dapr Component from a Managed Environment.
```powershell
$managedenvdapr = Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-dapr

Remove-AzContainerAppManagedEnvDapr -InputObject $managedenvdapr
```

Delete a Dapr Component from a Managed Environment.

### Example 3: Delete a Dapr Component from a Managed Environment.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Remove-AzContainerAppManagedEnvDapr -ManagedEnvironmentInputObject $managedenv -Name azps-dapr
```

Delete a Dapr Component from a Managed Environment.