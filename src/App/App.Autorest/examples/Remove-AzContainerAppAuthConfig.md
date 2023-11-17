### Example 1: Delete a Container App AuthConfig.
```powershell
Remove-AzContainerAppAuthConfig -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app -Name current
```

Delete a Container App AuthConfig.

### Example 2: Delete a Container App AuthConfig.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-2

Remove-AzContainerAppAuthConfig -ContainerAppInputObject $containerapp -Name current
```

Delete a Container App AuthConfig.

### Example 3: Delete a Container App AuthConfig.
```powershell
$authconfig = Get-AzContainerAppAuthConfig -Name current -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app

Remove-AzContainerAppAuthConfig -InputObject $authconfig
```

Delete a Container App AuthConfig.