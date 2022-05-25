### Example 1: Get the Container App AuthConfigs in a given resource group.
```powershell
Get-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azpstest_gp
```

Get the Container App AuthConfigs in a given resource group.