### Example 1: Delete a Dapr Component from a connected environment.
```powershell
Remove-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr
```

Delete a Dapr Component from a connected environment.

### Example 2: Delete a Dapr Component from a connected environment.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Remove-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvdapr
```

Delete a Dapr Component from a connected environment.

### Example 3: Delete a Dapr Component from a connected environment.
```powershell
$connectedenvdapr = Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr

Remove-AzContainerAppConnectedEnvDapr -InputObject $connectedenvdapr
```

Delete a Dapr Component from a connected environment.