### Example 1: List AuthConfig of a Container App.
```powershell
Get-AzContainerAppAuthConfig -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

List AuthConfig of a Container App.

### Example 2: Get a AuthConfig of a Container App.
```powershell
Get-AzContainerAppAuthConfig -ContainerAppName azps-containerapp-2 -ResourceGroupName azps_test_group_app -Name current
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Get a AuthConfig of a Container App.

### Example 3: Get a AuthConfig of a Container App.
```powershell
$containerapp = Get-AzContainerApp -Name azps-containerapp-2 -ResourceGroupName azps_test_group_app
Get-AzContainerAppAuthConfig -ContainerAppInputObject $containerapp -Name current
```

```output
Name    PlatformEnabled ResourceGroupName
----    --------------- -----------------
current True            azps_test_group_app
```

Get a AuthConfig of a Container App.