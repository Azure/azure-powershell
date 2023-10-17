### Example 1: Delete storage for a connectedEnvironment.
```powershell
Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa
```

Delete storage for a connectedEnvironment.

### Example 2: Delete storage for a connectedEnvironment.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Remove-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject $connectedenv -Name azpstestsa
```

Delete storage for a connectedEnvironment.

### Example 3: Delete storage for a connectedEnvironment.
```powershell
$connectedenvstorage = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa

Remove-AzContainerAppConnectedEnvStorage -InputObject $connectedenvstorage
```

Delete storage for a connectedEnvironment.