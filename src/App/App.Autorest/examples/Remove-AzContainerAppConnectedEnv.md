### Example 1: Delete a Container App ConnectedEnv.
```powershell
Remove-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
```

Delete a Container App ConnectedEnv.

### Example 2: Delete a Container App ConnectedEnv.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Remove-AzContainerAppConnectedEnv -InputObject $connectedenv
```

Delete a Container App ConnectedEnv.