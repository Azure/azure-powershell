### Example 1: Deletes the specified Certificate.
```powershell
Remove-AzContainerAppConnectedEnvCert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvcert
```

Deletes the specified Certificate.

### Example 2: Deletes the specified Certificate.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Remove-AzContainerAppConnectedEnvCert -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvcert
```

Deletes the specified Certificate.

### Example 3: Deletes the specified Certificate.
```powershell
$connectedenvcert = Get-AzContainerAppConnectedEnvCert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvcert

Remove-AzContainerAppConnectedEnvCert -InputObject $connectedenvcert
```

Deletes the specified Certificate.