### Example 1: List dapr component by connected env name.
```powershell
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

List dapr component by connected env name.

### Example 2: Get a dapr component by name.
```powershell
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component by name.

### Example 3: Get a dapr component.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvdapr
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component.