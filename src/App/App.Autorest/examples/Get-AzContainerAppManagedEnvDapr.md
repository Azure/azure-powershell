### Example 1: List dapr component by env name.
```powershell
Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

List dapr component by env name.

### Example 2: Get a dapr component by name.
```powershell
Get-AzContainerAppManagedEnvDapr -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-dapr
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component by name.

### Example 3: Get a dapr component.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app
Get-AzContainerAppManagedEnvDapr -ManagedEnvironmentInputObject $managedenv -Name azps-dapr
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component.