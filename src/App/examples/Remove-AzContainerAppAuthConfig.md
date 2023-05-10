### Example 1: Delete a Container App AuthConfig.
```powershell
Remove-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

Delete a Container App AuthConfig.

### Example 2: Delete a Container App AuthConfig.
```powershell
Get-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp | Remove-AzContainerAppAuthConfig
```

Delete a Container App AuthConfig.